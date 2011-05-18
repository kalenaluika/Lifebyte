using System.Web.Mvc;
using Lifebyte.Web.Controllers;
using Lifebyte.Web.Models.ViewModels;
using NUnit.Framework;
using Moq;
using Lifebyte.Web.Models.Core.Interfaces;
using Lifebyte.Web.Models.Core.Entities;

namespace Lifebyte.Web.Tests.Controllers
{
    [TestFixture]
    public class AccountControllerTest
    {
        [Test]
        public void AccountController_Constructor_Is_Valid()
        {
            var accountController = new AccountController(new Mock<IFormsAuthenticationService>().Object);

            Assert.IsInstanceOf<Controller>(accountController);
        }

        [Test]
        public void AccountController_LogOff_Returns_View()
        {
            var accountController = new AccountController(new Mock<IFormsAuthenticationService>().Object);

            ActionResult result = accountController.LogOff();

            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void AccountController_LogOn_Post_Invalid_ModelState_Returns_View()
        {
            var accountController = new AccountController(new Mock<IFormsAuthenticationService>().Object);

            accountController.ModelState.AddModelError("test", "error");

            var model = new LogOnViewModel();

            ActionResult result = accountController.LogOn(model, "home/index");

            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void AccountController_LogOn_Post_Valid_User_Redirects()
        {
            var accountController = new AccountController(new Mock<IFormsAuthenticationService>().Object);

            var model = new LogOnViewModel
                            {
                                Username = "dstewart",
                                Password = "p@ssw0rd",
                                RememberMe = false,
                            };

            ActionResult result = accountController.LogOn(model, "home/index");

            Assert.IsInstanceOf<RedirectResult>(result);
        }

        [Test]
        public void AccountController_LogOn_Returns_View()
        {
            var accountController = new AccountController(new Mock<IFormsAuthenticationService>().Object);

            ActionResult result = accountController.LogOn();

            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void AccountController_Register_Returns_View()
        {
            var accountController = new AccountController(new Mock<IFormsAuthenticationService>().Object);

            ActionResult result = accountController.Register();

            Assert.IsInstanceOf<ViewResult>(result);
            ViewResult view = (ViewResult)result;
            Assert.IsNotNull(view.ViewData.Model);
            Assert.IsInstanceOf<Volunteer>(view.ViewData.Model);
        }
    }
}