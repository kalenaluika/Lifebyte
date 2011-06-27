using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Routing;
using Lifebyte.Web.Controllers;
using Lifebyte.Web.Models.Core.Entities;
using Lifebyte.Web.Models.Core.Interfaces;
using Lifebyte.Web.Tests.TestHelpers;
using Moq;
using NUnit.Framework;

namespace Lifebyte.Web.Tests.Controllers
{
    [TestFixture]
    public class ProfileControllerTest
    {
        [Test]
        public void Class_Is_Authorized()
        {
            Assert.IsTrue(typeof (ProfileController)
                              .GetCustomAttributes(false)
                              .Any(c => c.GetType() == typeof (AuthorizeAttribute)));
        }

        [Test]
        public void Constructor_IsValid()
        {
            var profileController = new ProfileController(new Mock<IDataService<Volunteer>>().Object,
                                                          new Mock<IFormsAuthenticationService>().Object);

            Assert.IsInstanceOf<Controller>(profileController);
        }

        [Test]
        public void EditActionRoute_ReturnsView()
        {
            RouteData routeData = RouteTestHelper.GetRouteData("~/Profile/Edit");

            Assert.IsNotNull(routeData, "The Profile/Edit route was null.");
            Assert.AreEqual("Profile", routeData.Values["Controller"]);
            Assert.AreEqual("Edit", routeData.Values["Action"]);
            Assert.IsEmpty(routeData.Values["id"].ToString());
        }

        [Test]
        public void Edit_ReturnsView()
        {
            var formsAuthenticationService = new Mock<IFormsAuthenticationService>();
            formsAuthenticationService.Setup(f => f.GetVolunteerID(null))
                .Returns(Guid.NewGuid());

            var volunteerDataService = new Mock<IDataService<Volunteer>>();

            // http://stackoverflow.com/questions/5196669/moqing-methods-where-expressionfunct-bool-are-passed-in-as-parameters
            volunteerDataService.Setup(v => v.SelectOne(It.IsAny<Expression<Func<Volunteer, bool>>>()))
                .Returns(new Volunteer());

            var profileController = new ProfileController(volunteerDataService.Object,
                                                          formsAuthenticationService.Object);

            ActionResult result = profileController.Edit();

            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void IndexActionRoute_ReturnsView()
        {
            RouteData routeData = RouteTestHelper.GetRouteData("~/Profile/Index");

            Assert.IsNotNull(routeData, "The Profile/Index route was null.");
            Assert.AreEqual("Profile", routeData.Values["Controller"]);
            Assert.AreEqual("Index", routeData.Values["Action"]);
            Assert.IsEmpty(routeData.Values["id"].ToString());
        }

        [Test]
        public void Index_ReturnsView()
        {
            var volunteerDataService = new Mock<IDataService<Volunteer>>();
            volunteerDataService.Setup(v => v.SelectOne(It.IsAny<Expression<Func<Volunteer, bool>>>()))
                .Returns(new Volunteer());

            var profileController = new ProfileController(volunteerDataService.Object,
                                                          new Mock<IFormsAuthenticationService>().Object);

            ActionResult result = profileController.Index();

            Assert.IsInstanceOf<ViewResult>(result);
        }
    }
}