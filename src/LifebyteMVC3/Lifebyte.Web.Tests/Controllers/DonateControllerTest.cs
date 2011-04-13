using System.Web.Mvc;
using Lifebyte.Web.Controllers;
using NUnit.Framework;

namespace Lifebyte.Web.Tests.Controllers
{
    [TestFixture]
    public class DonateControllerTest
    {
        /// <summary>
        /// Tests the Donate/Index route result.
        /// </summary>
        [Test]
        public void DonateController_Index_GoToPage()
        {
            var controller = new DonateController();
            ActionResult result = controller.Index();

            Assert.IsInstanceOf(typeof(ViewResult), result);
        }
    }
}
