using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Lifebyte.Web.Controllers;
using Lifebyte.Web.Models.ViewModels;
using Moq;
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
        public void AccountController_LogOff_Returns_View()
        {
            var accountController = new AccountController();

            ActionResult result = accountController.LogOff();

            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void AccountController_LogOn_Post_Invalid_User_Returns_View()
        {
            //var accountController = new AccountController();

            //var model = new LogOnViewModel();

            //ActionResult result = accountController.LogOn(model, "home/index");

            //Assert.IsInstanceOf<ViewResult>(result);
            Assert.Inconclusive("Cannot make the ModelState.IsValid = false");
        }

        [Test]
        public void AccountController_LogOn_Post_Valid_User_Redirects()
        {
            var httpContextMock = new Mock<HttpContextBase>();

            httpContextMock.Setup(h => h.Request)
                .Returns(new Mock<HttpRequestBase>().Object);

            httpContextMock.Setup(h => h.Response)
                .Returns(new Mock<HttpResponseBase>().Object);

            httpContextMock.Setup(h => h.Session)
                .Returns(new Mock<HttpSessionStateBase>().Object);

            httpContextMock.Setup(h => h.Server)
                .Returns(new Mock<HttpServerUtilityBase>().Object);

            httpContextMock.Setup(h => h.Cache)
                .Returns(HttpRuntime.Cache);

            var accountController = new AccountController();

            accountController.ControllerContext = new ControllerContext(httpContextMock.Object,
                                                                        new RouteData(), 
                                                                        accountController);

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
            var accountController = new AccountController();

            ActionResult result = accountController.LogOn();

            Assert.IsInstanceOf<ViewResult>(result);
        }
    }
}