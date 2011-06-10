using System.Web.Mvc;
using Lifebyte.Web.Controllers;
using NUnit.Framework;

namespace Lifebyte.Web.Tests.Controllers
{
    [TestFixture]
    public class DonateControllerTest
    {
        [Test]
        public void Index_ReturnsView()
        {
            var controller = new DonateController();
            ActionResult result = controller.Index();

            Assert.IsInstanceOf(typeof(ViewResult), result);
        }
    }
}
