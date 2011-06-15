using System.Web.Mvc;
using Lifebyte.Web.Controllers;
using NUnit.Framework;

namespace Lifebyte.Web.Tests.Controllers
{
    [TestFixture]
    public class ComputerControllerTest
    {        
        [Test]
        public void Index_ReturnsView()
        {
            var controller = new ComputerController();
            ActionResult result = controller.Index();

            Assert.IsInstanceOf<ViewResult>( result);
        }
    }
}
