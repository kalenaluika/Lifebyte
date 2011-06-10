using System.Web.Mvc;
using Lifebyte.Web.Controllers;
using NUnit.Framework;

namespace Lifebyte.Web.Tests.Controllers
{
    [TestFixture]
    public class RequestControllerTest
    {
        [Test]
        public void Index_ReturnsView()
        {
            var controller = new RequestController();
            ActionResult result = controller.Index();
            Assert.IsInstanceOf<ViewResult>(result);
        }
    }
}
