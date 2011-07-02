using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Routing;
using Lifebyte.Web.Controllers;
using Lifebyte.Web.Models.Core.Entities;
using Lifebyte.Web.Models.Core.Interfaces;
using Lifebyte.Web.Models.ViewModels;
using Lifebyte.Web.Tests.TestHelpers;
using Moq;
using NUnit.Framework;

namespace Lifebyte.Web.Tests.Controllers
{
    [TestFixture]
    public class ComputerControllerTest
    {
        [Test]
        public void AddActionRoute_ReturnsView()
        {
            RouteData routeData = RouteTestHelper.GetRouteData("~/Computer/Add");

            Assert.IsNotNull(routeData, "The Computer/Add route was null.");
            Assert.AreEqual("Computer", routeData.Values["Controller"]);
            Assert.AreEqual("Add", routeData.Values["Action"]);
            Assert.IsEmpty(routeData.Values["id"].ToString());
        }

        [Test]
        public void Add_ReturnsView()
        {
            var controller = new ComputerController(new Mock<IDataService<Computer>>().Object,
                                                    new Mock<IFormsAuthenticationService>().Object,
                                                    new Mock<IDataService<WindowsLicense>>().Object,
                                                    new Mock<IDataService<Volunteer>>().Object,
                                                    new Mock<IDataService<Recipient>>().Object);

            ActionResult result = controller.Add();

            Assert.IsInstanceOf<ViewResult>(result);

            var view = (ViewResult) result;
            Assert.IsInstanceOf<Computer>(view.Model);
        }

        [Test]
        public void Add_ValidModelLicenseTypeWithResultPost_ReturnsRedirect()
        {
            var computerFake = new Computer
                                   {
                                       LicenseType = "WinXP",
                                   };

            var computerDataService = new Mock<IDataService<Computer>>();
            computerDataService.Setup(c => c.Insert(It.IsAny<Computer>(), It.IsAny<Guid>())).Verifiable();

            var windowsLicenseDataServiceMock = new Mock<IDataService<WindowsLicense>>();
            windowsLicenseDataServiceMock.Setup(w => w.SelectOne(It.IsAny<Expression<Func<WindowsLicense, bool>>>()))
                .Returns(new WindowsLicense
                             {
                                 Id = "123456",
                                 LicenseType = computerFake.LicenseType,
                             });

            var controller = new ComputerController(computerDataService.Object,
                                                    new Mock<IFormsAuthenticationService>().Object,
                                                    windowsLicenseDataServiceMock.Object,
                                                    new Mock<IDataService<Volunteer>>().Object,
                                                    new Mock<IDataService<Recipient>>().Object);

            ActionResult result = controller.Add(computerFake);

            Assert.IsInstanceOf<RedirectToRouteResult>(result);
            computerDataService.VerifyAll();
        }

        [Test]
        public void Add_ValidModelNoLicenseTypePost_ReturnsRedirect()
        {
            var computerDataService = new Mock<IDataService<Computer>>();
            computerDataService.Setup(c => c.Insert(It.IsAny<Computer>(), It.IsAny<Guid>())).Verifiable();

            var controller = new ComputerController(computerDataService.Object,
                                                    new Mock<IFormsAuthenticationService>().Object,
                                                    new Mock<IDataService<WindowsLicense>>().Object,
                                                    new Mock<IDataService<Volunteer>>().Object,
                                                    new Mock<IDataService<Recipient>>().Object);

            ActionResult result = controller.Add(new Computer());

            Assert.IsInstanceOf<RedirectToRouteResult>(result);
            computerDataService.VerifyAll();
        }

        /// <summary>
        /// This occurs when a volunteer enters a license type that we are out of.
        /// A model state error should occur and the volunteer should be sent back to the 
        /// page. This is not a very good user experience. We need to prevent this from 
        /// happening.
        /// </summary>
        [Test]
        public void Add_ValidModelWithLicenseTypeNoResultsPost_ReturnsView()
        {
            var controller = new ComputerController(new Mock<IDataService<Computer>>().Object,
                                                    new Mock<IFormsAuthenticationService>().Object,
                                                    new Mock<IDataService<WindowsLicense>>().Object,
                                                    new Mock<IDataService<Volunteer>>().Object,
                                                    new Mock<IDataService<Recipient>>().Object);

            ActionResult result = controller.Add(new Computer
                                                     {
                                                         LicenseType = "WinXP",
                                                     });

            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void DeliverActionRoute_ReturnsView()
        {
            Guid id = Guid.NewGuid();
            RouteData routeData = RouteTestHelper.GetRouteData("~/Computer/Deliver/" + id);

            Assert.IsNotNull(routeData, "The Computer/Deliver route was null.");
            Assert.AreEqual("Computer", routeData.Values["Controller"]);
            Assert.AreEqual("Deliver", routeData.Values["Action"]);
            Assert.AreEqual(id.ToString(), routeData.Values["id"].ToString());
        }

        [Test]
        public void Deliver_ReturnsView()
        {
            var computerDataServiceMock = new Mock<IDataService<Computer>>();
            computerDataServiceMock.Setup(c => c.SelectOne(It.IsAny<Expression<Func<Computer, bool>>>()))
                .Returns(new Computer());

            var recipientDataServiceMock = new Mock<IDataService<Recipient>>();
            recipientDataServiceMock.Setup(r => r.SelectAll(It.IsAny<Expression<Func<Recipient, bool>>>()))
                .Returns(new List<Recipient>());

            var controller = new ComputerController(computerDataServiceMock.Object,
                                                    new Mock<IFormsAuthenticationService>().Object,
                                                    new Mock<IDataService<WindowsLicense>>().Object,
                                                    new Mock<IDataService<Volunteer>>().Object,
                                                    recipientDataServiceMock.Object);

            ActionResult result = controller.Deliver(Guid.NewGuid());

            Assert.IsInstanceOf<ViewResult>(result);

            var view = (ViewResult) result;

            Assert.IsInstanceOf<DeliverComputerViewModel>(view.Model);
        }

        [Test]
        public void EditActionRoute_ReturnsView()
        {
            RouteData routeData = RouteTestHelper.GetRouteData("~/Computer/Edit");

            Assert.IsNotNull(routeData, "The Computer/Edit route was null.");
            Assert.AreEqual("Computer", routeData.Values["Controller"]);
            Assert.AreEqual("Edit", routeData.Values["Action"]);
            Assert.IsEmpty(routeData.Values["id"].ToString());
        }

        [Test]
        public void Edit_InvalidModel_ReturnsView()
        {
            var controller = new ComputerController(new Mock<IDataService<Computer>>().Object,
                                                    new Mock<IFormsAuthenticationService>().Object,
                                                    new Mock<IDataService<WindowsLicense>>().Object,
                                                    new Mock<IDataService<Volunteer>>().Object,
                                                    new Mock<IDataService<Recipient>>().Object);

            controller.ModelState.AddModelError("test", "error");

            ActionResult result = controller.Edit(new Computer());

            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void Edit_ReturnsView()
        {
            var computerDataServiceMock = new Mock<IDataService<Computer>>();
            computerDataServiceMock.Setup(c => c.SelectOne(It.IsAny<Expression<Func<Computer, bool>>>()))
                .Returns(new Computer());

            var controller = new ComputerController(computerDataServiceMock.Object,
                                                    new Mock<IFormsAuthenticationService>().Object,
                                                    new Mock<IDataService<WindowsLicense>>().Object,
                                                    new Mock<IDataService<Volunteer>>().Object,
                                                    new Mock<IDataService<Recipient>>().Object);

            ActionResult result = controller.Edit(Guid.NewGuid());

            Assert.IsInstanceOf<ViewResult>(result);

            var view = (ViewResult) result;
            Assert.IsInstanceOf<Computer>(view.Model);
        }

        [Test]
        public void Edit_ValidModel_ReturnsRedirect()
        {
            var computerFake = new Computer
                                   {
                                       WindowsLicense = "1234",
                                   };

            var computerDataServiceMock = new Mock<IDataService<Computer>>();
            computerDataServiceMock.Setup(c => c.Update(It.IsAny<Computer>())).Verifiable();
            computerDataServiceMock.Setup(c => c.SelectOne(It.IsAny<Expression<Func<Computer, bool>>>()))
                .Returns(computerFake);

            var formsAuthenticationServiceMock = new Mock<IFormsAuthenticationService>();
            formsAuthenticationServiceMock.Setup(f => f.GetVolunteerID(null))
                .Returns(Guid.NewGuid());

            var volunterDataServiceMock = new Mock<IDataService<Volunteer>>();
            volunterDataServiceMock.Setup(v => v.SelectOne(It.IsAny<Expression<Func<Volunteer, bool>>>()))
                .Returns(new Volunteer());

            var windowsLicenseFake = new WindowsLicense();
            var windowsLicenseDataServiceMock = new Mock<IDataService<WindowsLicense>>();
            windowsLicenseDataServiceMock.Setup(w => w.SelectOne(It.IsAny<Expression<Func<WindowsLicense, bool>>>()))
                .Returns(windowsLicenseFake);
            windowsLicenseDataServiceMock.Setup(w => w.Update(windowsLicenseFake)).Verifiable();

            var controller = new ComputerController(computerDataServiceMock.Object,
                                                    formsAuthenticationServiceMock.Object,
                                                    windowsLicenseDataServiceMock.Object,
                                                    volunterDataServiceMock.Object,
                                                    new Mock<IDataService<Recipient>>().Object);

            ActionResult result = controller.Edit(computerFake);

            Assert.IsInstanceOf<RedirectToRouteResult>(result);
            computerDataServiceMock.VerifyAll();
            windowsLicenseDataServiceMock.VerifyAll();
        }

        [Test]
        public void IndexActionRoute_ReturnsView()
        {
            RouteData routeData = RouteTestHelper.GetRouteData("~/Computer/Index");

            Assert.IsNotNull(routeData, "The Computer/Index route was null.");
            Assert.AreEqual("Computer", routeData.Values["Controller"]);
            Assert.AreEqual("Index", routeData.Values["Action"]);
            Assert.IsEmpty(routeData.Values["id"].ToString());
        }

        [Test]
        public void Index_ReturnsView()
        {
            var computerDataService = new Mock<IDataService<Computer>>();

            computerDataService.Setup(c => c.SelectAll(It.IsAny<Expression<Func<Computer, bool>>>()))
                .Returns(new List<Computer>
                             {
                                 new Computer()
                             });

            var controller = new ComputerController(computerDataService.Object,
                                                    new Mock<IFormsAuthenticationService>().Object,
                                                    new Mock<IDataService<WindowsLicense>>().Object,
                                                    new Mock<IDataService<Volunteer>>().Object,
                                                    new Mock<IDataService<Recipient>>().Object);

            ActionResult result = controller.Index(null);

            Assert.IsInstanceOf<ViewResult>(result);

            var view = (ViewResult) result;

            Assert.IsNotNull(view.ViewData.Model);
            Assert.IsInstanceOf<List<Computer>>(view.ViewData.Model);
        }

        [Test]
        public void Index_WithQuery_ReturnsView()
        {
            var computerDataService = new Mock<IDataService<Computer>>();

            computerDataService.Setup(c => c.SelectAll(It.IsAny<Expression<Func<Computer, bool>>>()))
                .Returns(new List<Computer>
                             {
                                 new Computer()
                             });

            var controller = new ComputerController(computerDataService.Object,
                                                    new Mock<IFormsAuthenticationService>().Object,
                                                    new Mock<IDataService<WindowsLicense>>().Object,
                                                    new Mock<IDataService<Volunteer>>().Object,
                                                    new Mock<IDataService<Recipient>>().Object);

            ActionResult result = controller.Index("LB0123");

            Assert.IsInstanceOf<ViewResult>(result);

            var view = (ViewResult) result;

            Assert.IsNotNull(view.ViewData.Model);
            Assert.IsInstanceOf<List<Computer>>(view.ViewData.Model);
        }


        [Test]
        public void ManifestActionRoute_ReturnsView()
        {
            Guid id = Guid.NewGuid();
            RouteData routeData = RouteTestHelper.GetRouteData("~/Computer/Manifest/" + id);

            Assert.IsNotNull(routeData, "The Computer/Manifest route was null.");
            Assert.AreEqual("Computer", routeData.Values["Controller"]);
            Assert.AreEqual("Manifest", routeData.Values["Action"]);
            Assert.AreEqual(id.ToString(), routeData.Values["id"].ToString());
        }

        [Test]
        public void Manifest_ReturnsView()
        {
            var fakeComputer = new Computer
                                   {
                                       Id = Guid.NewGuid(),
                                       ManifestHtml =
                                           @"
                                                <html>
                                                    <head><title>LB0124</title></head>
                                                    <body>
                                                        <p>Hello World LB0124</p>
                                                    </body>
                                                </html>"
                                   };

            var computerDataService = new Mock<IDataService<Computer>>();

            computerDataService.Setup(c => c.SelectOne(It.IsAny<Expression<Func<Computer, bool>>>()))
                .Returns(fakeComputer);

            var controller = new ComputerController(computerDataService.Object,
                                                    new Mock<IFormsAuthenticationService>().Object,
                                                    new Mock<IDataService<WindowsLicense>>().Object,
                                                    new Mock<IDataService<Volunteer>>().Object,
                                                    new Mock<IDataService<Recipient>>().Object);

            ActionResult result = controller.Manifest(fakeComputer.Id);

            Assert.IsInstanceOf<ViewResult>(result);
        }


        [Test]
        public void Deliver_ValidPost_ReturnsRedirect()
        {
            var controller = new ComputerController(new Mock<IDataService<Computer>>().Object,
                                                      new Mock<IFormsAuthenticationService>().Object,
                                                      new Mock<IDataService<WindowsLicense>>().Object,
                                                      new Mock<IDataService<Volunteer>>().Object,
                                                      new Mock<IDataService<Recipient>>().Object);

            var result = controller.Deliver(new DeliverComputerViewModel());

            Assert.IsInstanceOf<RedirectToRouteResult>(result);
        }
    }
}