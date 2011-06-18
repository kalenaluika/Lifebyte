using System;
using System.Linq;
using System.Web.Mvc;
using Lifebyte.Web.Controllers;
using Lifebyte.Web.Models.Core.Entities;
using Lifebyte.Web.Models.Core.Interfaces;
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
        public void Index_ReturnsView()
        {
            var volunteerDataService = new Mock<IDataService<Volunteer>>();
            volunteerDataService.Setup(v => v.FindOne(vol => vol.Id == It.IsAny<Guid>()))
                .Returns(new Volunteer());

            var profileController = new ProfileController(volunteerDataService.Object,
                                                          new Mock<IFormsAuthenticationService>().Object);

            ActionResult result = profileController.Index();

            Assert.IsInstanceOf<ViewResult>(result);
        }
    }
}