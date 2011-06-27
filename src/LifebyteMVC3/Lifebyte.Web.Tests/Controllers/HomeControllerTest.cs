using System.Web.Mvc;
using System.Web.Routing;
using Lifebyte.Web.Controllers;
using Lifebyte.Web.Tests.TestHelpers;
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

        [Test]
        public void IndexActionRoute_ReturnsView()
        {
            RouteData routeData = RouteTestHelper.GetRouteData("~/Home/Index");

            Assert.IsNotNull(routeData, "The Home/Index route was null.");
            Assert.AreEqual("Home", routeData.Values["Controller"]);
            Assert.AreEqual("Index", routeData.Values["Action"]);
            Assert.IsEmpty(routeData.Values["id"].ToString());
        }

        [Test]
        public void Privacy_ReturnsView()
        {
            var controller = new HomeController();
            ActionResult result = controller.Privacy();

            Assert.IsInstanceOf(typeof(ViewResult), result);
        }

        [Test]
        public void PrivacyActionRoute_ReturnsView()
        {
            RouteData routeData = RouteTestHelper.GetRouteData("~/Home/Privacy");

            Assert.IsNotNull(routeData, "The Home/Privacy route was null.");
            Assert.AreEqual("Home", routeData.Values["Controller"]);
            Assert.AreEqual("Privacy", routeData.Values["Action"]);
            Assert.IsEmpty(routeData.Values["id"].ToString());
        }
    }
}