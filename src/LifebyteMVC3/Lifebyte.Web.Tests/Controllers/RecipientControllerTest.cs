using System;
using System.Web.Mvc;
using System.Web.Routing;
using Lifebyte.Web.Controllers;
using Lifebyte.Web.Models.Core.Entities;
using Lifebyte.Web.Models.Core.Interfaces;
using Lifebyte.Web.Tests.TestHelpers;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Lifebyte.Web.Tests.Controllers
{
    [TestFixture]
    public class RecipientControllerTest
    {
        [Test]
        public void AddActionRoute_ReturnsView()
        {
            RouteData routeData = RouteTestHelper.GetRouteData("~/Recipient/Add");

            Assert.IsNotNull(routeData, "The Recipient/Add route was null.");
            Assert.AreEqual("Recipient", routeData.Values["Controller"]);
            Assert.AreEqual("Add", routeData.Values["Action"]);
            Assert.IsEmpty(routeData.Values["id"].ToString());
        }

        [Test]
        public void AddPostInvalidModel_ReturnsView()
        {
            var controller = new RecipientController(new Mock<IDataService<Recipient>>().Object,
                                                     new Mock<IDataService<Volunteer>>().Object,
                                                     new Mock<IFormsAuthenticationService>().Object);

            controller.ModelState.AddModelError("test", "error");

            ActionResult result = controller.Add(new Recipient());

            Assert.IsInstanceOf(typeof (ViewResult), result);
        }

        [Test]
        public void AddPostValidModel_ReturnsRedirect()
        {
            var volunteerFake = new Volunteer
                                    {
                                        Id = Guid.NewGuid(),
                                    };

            var recipientFake = new Recipient
                                    {
                                        Active = true,
                                        FirstName = "Dan",
                                        Id = Guid.NewGuid(),
                                    };

            var dataServiceMock = new Mock<IDataService<Recipient>>();
            dataServiceMock.Setup(d => d.Insert(It.IsAny<Recipient>(), It.IsAny<Guid>())).Verifiable();

            var formsAuthenticationServiceMock = new Mock<IFormsAuthenticationService>();
            formsAuthenticationServiceMock.Setup(f => f.GetVolunteerID(null))
                .Returns(volunteerFake.Id);

            var controller = new RecipientController(dataServiceMock.Object,
                                                     new Mock<IDataService<Volunteer>>().Object,
                                                     formsAuthenticationServiceMock.Object);

            ActionResult result = controller.Add(recipientFake);

            dataServiceMock.VerifyAll();

            Assert.IsInstanceOf(typeof (RedirectToRouteResult), result);
        }

        [Test]
        public void Add_ReturnsView()
        {
            var controller = new RecipientController(new Mock<IDataService<Recipient>>().Object,
                                                     new Mock<IDataService<Volunteer>>().Object,
                                                     new Mock<IFormsAuthenticationService>().Object);
            ActionResult result = controller.Add();

            Assert.IsInstanceOf(typeof (ViewResult), result);
        }

        [Test]
        public void EditActionRoute_ReturnsView()
        {
            RouteData routeData = RouteTestHelper.GetRouteData("~/Recipient/Edit");

            Assert.IsNotNull(routeData, "The Recipient/Edit route was null.");
            Assert.AreEqual("Recipient", routeData.Values["Controller"]);
            Assert.AreEqual("Edit", routeData.Values["Action"]);
            Assert.IsEmpty(routeData.Values["id"].ToString());
        }

        [Test]
        public void EditPostInvalidModel_ReturnsView()
        {
            var controller = new RecipientController(new Mock<IDataService<Recipient>>().Object,
                                                     new Mock<IDataService<Volunteer>>().Object,
                                                     new Mock<IFormsAuthenticationService>().Object);

            controller.ModelState.AddModelError("test", "error");

            ActionResult result = controller.Edit(new Recipient());

            Assert.IsInstanceOf(typeof (ViewResult), result);
        }

        [Test]
        public void Edit_ReturnsView()
        {
            var controller = new RecipientController(new Mock<IDataService<Recipient>>().Object,
                                                     new Mock<IDataService<Volunteer>>().Object,
                                                     new Mock<IFormsAuthenticationService>().Object);

            Guid id = Guid.NewGuid();
            ActionResult result = controller.Edit(id);

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
        public void Index_ReturnsView()
        {
            var recipientDataServiceMock = new Mock<IDataService<Recipient>>();

            recipientDataServiceMock.Setup(r => r.SelectAll(It.IsAny<Expression<Func<Recipient, bool>>>()))
                .Returns(new List<Recipient>());

            var controller = new RecipientController(recipientDataServiceMock.Object,
                                                     new Mock<IDataService<Volunteer>>().Object,
                                                     new Mock<IFormsAuthenticationService>().Object);
            
            ActionResult result = controller.Index(null, null, null);

            Assert.IsInstanceOf(typeof (ViewResult), result);

            var view = (ViewResult) result;
            Assert.IsInstanceOf<List<Recipient>>(view.Model);
        }

        [Test]
        public void Index_WithQuery_ReturnsView()
        {
            var recipientDataServiceMock = new Mock<IDataService<Recipient>>();

            recipientDataServiceMock.Setup(r => r.SelectAll(It.IsAny<Expression<Func<Recipient, bool>>>()))
                 .Returns(new List<Recipient>
                              {
                                  new Recipient()
                              });

            var controller = new RecipientController(recipientDataServiceMock.Object,
                                                     new Mock<IDataService<Volunteer>>().Object,
                                                     new Mock<IFormsAuthenticationService>().Object);

            ActionResult result = controller.Index("New", "Dan", "Stewart");

            Assert.IsInstanceOf<ViewResult>(result);

            var view = (ViewResult)result;

            Assert.IsNotNull(view.ViewData.Model);
            Assert.IsInstanceOf<List<Recipient>>(view.ViewData.Model);
        }
    }
}