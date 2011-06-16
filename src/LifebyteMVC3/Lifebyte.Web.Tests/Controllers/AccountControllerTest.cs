using System.Web.Mvc;
using Lifebyte.Web.Controllers;
using Lifebyte.Web.Models.Core.Entities;
using Lifebyte.Web.Models.Core.Interfaces;
using Lifebyte.Web.Models.ViewModels;
using Moq;
using NUnit.Framework;
using System;

namespace Lifebyte.Web.Tests.Controllers
{
    [TestFixture]
    public class AccountControllerTest
    {
        [Test]
        public void Constructor_Is_Valid()
        {
            var accountController = new AccountController(
                new Mock<IFormsAuthenticationService>().Object,
                new Mock<IDataService<Volunteer>>().Object);

            Assert.IsInstanceOf<Controller>(accountController);
        }

        [Test]
        public void LogOff_Returns_View()
        {
            var accountController = new AccountController(
                new Mock<IFormsAuthenticationService>().Object,
                new Mock<IDataService<Volunteer>>().Object);

            ActionResult result = accountController.LogOff();

            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void LogOnPost_InvalidModelState_ReturnsView()
        {
            var accountController = new AccountController(
                new Mock<IFormsAuthenticationService>().Object,
                new Mock<IDataService<Volunteer>>().Object);

            accountController.ModelState.AddModelError("test", "error");

            var model = new LogOnViewModel();

            ActionResult result = accountController.LogOn(model, "home/index");

            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void LogOnPost_ValidUser_Redirects()
        {
            var model = new LogOnViewModel
                            {
                                Username = "dstewart",
                                Password = "p@ssw0rd",
                                RememberMe = false,
                            };

            var fakeVolunteer = new Volunteer
                                    {
                                        Username = model.Username,
                                        Password = model.Password,
                                    };

            var formsAuthenticationServiceMock = new Mock<IFormsAuthenticationService>();
            
            formsAuthenticationServiceMock.Setup(f => f.SetAuthCookie(It.IsAny<string>(), It.IsAny<bool>()))
                .Verifiable();

            var volunteerDataServiceMock = new Mock<IDataService<Volunteer>>();

            volunteerDataServiceMock.Setup(v => v.FindOne(vol => vol.Username == It.IsAny<string>()))
                .Returns(fakeVolunteer);

            volunteerDataServiceMock.Setup(v => v.EncryptPassword(It.IsAny<string>(), It.IsAny<Guid>()))
                .Returns(model.Password);

            var accountController = new AccountController(
                formsAuthenticationServiceMock.Object,
                new Mock<IDataService<Volunteer>>().Object);            

            ActionResult result = accountController.LogOn(model, "home/index");

            Assert.IsInstanceOf<RedirectResult>(result);
        }

        [Test]
        public void LogOn_ReturnsView()
        {
            var accountController = new AccountController(
                new Mock<IFormsAuthenticationService>().Object,
                new Mock<IDataService<Volunteer>>().Object);

            ActionResult result = accountController.LogOn();

            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void Register_ReturnsView()
        {
            var accountController = new AccountController(
                new Mock<IFormsAuthenticationService>().Object,
                new Mock<IDataService<Volunteer>>().Object);

            ActionResult result = accountController.Register();

            Assert.IsInstanceOf<ViewResult>(result);
            var view = (ViewResult) result;
            Assert.IsNotNull(view.ViewData.Model);
            Assert.IsInstanceOf<Volunteer>(view.ViewData.Model);
        }

        [Test]
        public void Register_FailedSave_ReturnsRedirect()
        {
            // arrange
            var accountController = new AccountController(
                new Mock<IFormsAuthenticationService>().Object,
                new Mock<IDataService<Volunteer>>().Object);

            accountController.ModelState.AddModelError("testRequired", "dummy required field missing");

            var fakeVolunteer = new Volunteer
                                    {
                                        FirstName = "Firstname",
                                        LastName = "LNameTest",
                                        Username = "TestUser",
                                        Password = "p@SSw0rd"
                                    };


            ActionResult result = accountController.Register(fakeVolunteer);

            Assert.IsInstanceOf<ViewResult>(result);

            var view = (ViewResult) result;

            Assert.IsInstanceOf<Volunteer>(view.Model);
        }

        [Test]
        public void Register_Save_ReturnsRedirect()
        {
            var fakeVolunteer = new Volunteer
                                    {
                                        FirstName = "Firstname",
                                        LastName = "LNameTest",
                                        Username = "TestUser",
                                        Password = "p@SSw0rd",
                                        PrimaryPhone = "3334445555",
                                        Email = "user@email.com"
                                    };

            var dataService = new Mock<IDataService<Volunteer>>();

            dataService.Setup(d => d.Save(fakeVolunteer)).Verifiable("Save was not called.");

            var accountController = new AccountController(
                new Mock<IFormsAuthenticationService>().Object,
                dataService.Object);

            ActionResult result = accountController.Register(fakeVolunteer);

            dataService.VerifyAll();

            Assert.IsInstanceOf<RedirectResult>(result);
        }
    }
}