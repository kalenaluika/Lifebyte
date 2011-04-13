using System.Web.Mvc;
using Lifebyte.Web.Controllers;
using NUnit.Framework;

namespace Lifebyte.Web.Tests.Controllers
{
[TestFixture]
    public class HomeControllerTest
    {
        /// <summary>
        /// This is a test of the Index action on the HomeController.
        /// </summary>
        [Test]
        public void HomeController_Index_ReturnsView()
        {
            var controller = new HomeController();
            ActionResult result = controller.Index();

            Assert.IsInstanceOf(typeof(ViewResult), result);
        }
    }
}
