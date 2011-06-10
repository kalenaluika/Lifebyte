using System.Web.Mvc;
using Lifebyte.Web.Controllers;
using NUnit.Framework;

namespace Lifebyte.Web.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public void Index_ReturnsView()
        {
            var controller = new HomeController();
            ActionResult result = controller.Index();

            Assert.IsInstanceOf(typeof (ViewResult), result);
        }
    }
}