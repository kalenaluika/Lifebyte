using System.Web.Mvc;
using System.Web.Routing;
using Lifebyte.Web.Controllers;
using Lifebyte.Web.Tests.TestHelpers;
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

        [Test]
        public void IndexActionRoute_ReturnsView()
        {
            RouteData routeData = RouteTestHelper.GetRouteData("~/Request/Index");

            Assert.IsNotNull(routeData, "The Request/Index route was null.");
            Assert.AreEqual("Request", routeData.Values["Controller"]);
            Assert.AreEqual("Index", routeData.Values["Action"]);
            Assert.IsEmpty(routeData.Values["id"].ToString());
        }
    }
}
