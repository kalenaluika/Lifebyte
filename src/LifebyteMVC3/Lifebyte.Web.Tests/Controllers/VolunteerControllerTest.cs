using System.Web.Mvc;
using System.Web.Routing;
using Lifebyte.Web.Controllers;
using Lifebyte.Web.Tests.TestHelpers;
using NUnit.Framework;

namespace Lifebyte.Web.Tests.Controllers
{
    [TestFixture]
    public class VolunteerControllerTest
    {        
        [Test]
        public void Index_ReturnsView()
        {
            var controller = new VolunteerController();
            ActionResult result = controller.Index();

            Assert.IsInstanceOf(typeof(ViewResult), result);
        }

        [Test]
        public void IndexActionRoute_ReturnsView()
        {
            RouteData routeData = RouteTestHelper.GetRouteData("~/Volunteer/Index");

            Assert.IsNotNull(routeData, "The Volunteer/Index route was null.");
            Assert.AreEqual("Volunteer", routeData.Values["Controller"]);
            Assert.AreEqual("Index", routeData.Values["Action"]);
            Assert.IsEmpty(routeData.Values["id"].ToString());
        }
    }
}
