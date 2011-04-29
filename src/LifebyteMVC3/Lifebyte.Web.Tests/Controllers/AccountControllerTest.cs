using System.Web.Mvc;
using Lifebyte.Web.Controllers;
using Lifebyte.Web.Models.ViewModels;
using NUnit.Framework;

namespace Lifebyte.Web.Tests.Controllers
{
    [TestFixture]
    public class AccountControllerTest
    {
        [Test]
        public void AccountController_Constructor_Is_Valid()
        {
            var accountController = new AccountController();

            Assert.IsInstanceOf<Controller>(accountController);
        }

        [Test]
        public void AccountController_LogOn_Post_Returns_View()
        {
            var accountController = new AccountController();

            var model = new LogOnViewModel
                            {
                                Username = "dstewart",
                                Password = "p@ssw0rd",
                                RememberMe = true,
                            };

            ActionResult result = accountController.LogOn(model, "home/index");

            Assert.IsInstanceOf<RedirectResult>(result);
        }

        [Test]
        public void AccountController_LogOn_Returns_View()
        {
            var accountController = new AccountController();

            ActionResult result = accountController.LogOn();

            Assert.IsInstanceOf<ViewResult>(result);
        }
    }
}