using System.Web.Mvc;
using System.Web.Routing;
using Lifebyte.Web.Controllers;
using Lifebyte.Web.Tests.TestHelpers;
using NUnit.Framework;

namespace Lifebyte.Web.Tests.Controllers
{
    [TestFixture]
    public class RecipientControllerTest
    {
        [Test]
        public void Index_ReturnsView()
        {
            var controller = new RecipientController();
            ActionResult result = controller.Index();

            Assert.IsInstanceOf(typeof (ViewResult), result);
        }

        [Test]
        public void IndexActionRoute_ReturnsView()
        {
            RouteData routeData = RouteTestHelper.GetRouteData("~/Recipient/Index");

            Assert.IsNotNull(routeData, "The Recipient/Index route was null.");
            Assert.AreEqual("Recipient", routeData.Values["Controller"]);
            Assert.AreEqual("Index", routeData.Values["Action"]);
            Assert.IsEmpty(routeData.Values["id"].ToString());
        }

        [Test]
        public void Add_ReturnsView()
        {
            var controller = new RecipientController();
            ActionResult result = controller.Add();

            Assert.IsInstanceOf(typeof(ViewResult), result);
        }

        [Test]
        public void AddActionRoute_ReturnsView()
        {
            RouteData routeData = RouteTestHelper.GetRouteData("~/Recipient/Add");

            Assert.IsNotNull(routeData, "The Recipient/Add route was null.");
            Assert.AreEqual("Recipient", routeData.Values["Controller"]);
            Assert.AreEqual("Add", routeData.Values["Action"]);
            Assert.IsEmpty(routeData.Values["id"].ToString());
        }
    }
}