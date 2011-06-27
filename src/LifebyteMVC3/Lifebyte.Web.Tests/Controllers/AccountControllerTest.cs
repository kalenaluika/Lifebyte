using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Routing;
using Lifebyte.Web.Controllers;
using Lifebyte.Web.Models.Core.Entities;
using Lifebyte.Web.Models.Core.Interfaces;
using Lifebyte.Web.Models.ViewModels;
using Lifebyte.Web.Tests.TestHelpers;
using Moq;
using NUnit.Framework;

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

            Assert.IsInstanceOf<RedirectToRouteResult>(result);
        }

        [Test]
        public void LogOffActionRoute_ReturnsView()
        {
            RouteData routeData = RouteTestHelper.GetRouteData("~/Account/LogOff");

            Assert.IsNotNull(routeData, "The Account/LogOff route was null.");
            Assert.AreEqual("Account", routeData.Values["Controller"]);
            Assert.AreEqual("LogOff", routeData.Values["Action"]);
            Assert.IsEmpty(routeData.Values["id"].ToString());
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
                                        Active = true,
                                    };

            var formsAuthenticationServiceMock = new Mock<IFormsAuthenticationService>();

            formsAuthenticationServiceMock.Setup(f => f.SetAuthCookie(It.IsAny<Volunteer>(), It.IsAny<bool>()))
                .Verifiable();

            var volunteerDataServiceMock = new Mock<IDataService<Volunteer>>();

            volunteerDataServiceMock.Setup(v => v.SelectOne(It.IsAny<Expression<Func<Volunteer, bool>>>()))
                .Returns(fakeVolunteer);

            volunteerDataServiceMock.Setup(v => v.HashPassword(It.IsAny<string>(), It.IsAny<Guid>()))
                .Returns(model.Password);

            var accountController = new AccountController(
                formsAuthenticationServiceMock.Object,
                volunteerDataServiceMock.Object);

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
        public void LogOnActionRoute_ReturnsView()
        {
            RouteData routeData = RouteTestHelper.GetRouteData("~/Account/LogOn");

            Assert.IsNotNull(routeData, "The Account/LogOn route was null.");
            Assert.AreEqual("Account", routeData.Values["Controller"]);
            Assert.AreEqual("LogOn", routeData.Values["Action"]);
            Assert.IsEmpty(routeData.Values["id"].ToString());
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
        public void RegisterActionRoute_ReturnsView()
        {
            RouteData routeData = RouteTestHelper.GetRouteData("~/Account/Register");

            Assert.IsNotNull(routeData, "The Account/Register route was null.");
            Assert.AreEqual("Account", routeData.Values["Controller"]);
            Assert.AreEqual("Register", routeData.Values["Action"]);
            Assert.IsEmpty(routeData.Values["id"].ToString());
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

            dataService.Setup(d => d.Insert(fakeVolunteer, It.IsAny<Guid>())).Verifiable("Save was not called.");

            var accountController = new AccountController(
                new Mock<IFormsAuthenticationService>().Object,
                dataService.Object);

            ActionResult result = accountController.Register(fakeVolunteer);

            dataService.VerifyAll();

            Assert.IsInstanceOf<RedirectResult>(result);
        }
    }
}