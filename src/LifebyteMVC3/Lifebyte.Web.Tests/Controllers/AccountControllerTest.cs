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
        public void SignOff_Returns_View()
        {
            var accountController = new AccountController(
                new Mock<IFormsAuthenticationService>().Object,
                new Mock<IDataService<Volunteer>>().Object);

            ActionResult result = accountController.SignOff();

            Assert.IsInstanceOf<RedirectToRouteResult>(result);
        }

        [Test]
        public void SignOffActionRoute_ReturnsView()
        {
            RouteData routeData = RouteTestHelper.GetRouteData("~/Account/SignOff");

            Assert.IsNotNull(routeData, "The Account/SignOff route was null.");
            Assert.AreEqual("Account", routeData.Values["Controller"]);
            Assert.AreEqual("SignOff", routeData.Values["Action"]);
            Assert.IsEmpty(routeData.Values["id"].ToString());
        }

        [Test]
        public void SignInPost_InvalidModelState_ReturnsView()
        {
            var accountController = new AccountController(
                new Mock<IFormsAuthenticationService>().Object,
                new Mock<IDataService<Volunteer>>().Object);

            accountController.ModelState.AddModelError("test", "error");

            var model = new SignInViewModel();

            ActionResult result = accountController.SignIn(model, "home/index");

            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void SignInPost_ValidUser_Redirects()
        {
            var model = new SignInViewModel
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

            volunteerDataServiceMock.Setup(v => v.HashPassword(It.IsAny<string>()))
                .Returns(model.Password);

            volunteerDataServiceMock.Setup(v => v.VerifyPassword(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(true);

            var accountController = new AccountController(
                formsAuthenticationServiceMock.Object,
                volunteerDataServiceMock.Object);

            ActionResult result = accountController.SignIn(model, "home/index");

            Assert.IsInstanceOf<RedirectResult>(result);            
        }

        [Test]
        public void SignIn_ReturnsView()
        {
            var accountController = new AccountController(
                new Mock<IFormsAuthenticationService>().Object,
                new Mock<IDataService<Volunteer>>().Object);

            ActionResult result = accountController.SignIn();

            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void SignInActionRoute_ReturnsView()
        {
            RouteData routeData = RouteTestHelper.GetRouteData("~/Account/SignIn");

            Assert.IsNotNull(routeData, "The Account/SignIn route was null.");
            Assert.AreEqual("Account", routeData.Values["Controller"]);
            Assert.AreEqual("SignIn", routeData.Values["Action"]);
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

            Assert.IsInstanceOf<RedirectToRouteResult>(result);
        }

        [Test]
        public void Welcome_ReturnsView()
        {
            var accountController = new AccountController(
                 new Mock<IFormsAuthenticationService>().Object,
                 new Mock<IDataService<Volunteer>>().Object);

            ActionResult result = accountController.Welcome();

            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void WelcomeActionRoute_ReturnsView()
        {
            RouteData routeData = RouteTestHelper.GetRouteData("~/Account/Welcome");

            Assert.IsNotNull(routeData, "The Account/Welcome route was null.");
            Assert.AreEqual("Account", routeData.Values["Controller"]);
            Assert.AreEqual("Welcome", routeData.Values["Action"]);
            Assert.IsEmpty(routeData.Values["id"].ToString());
        }
    }
}