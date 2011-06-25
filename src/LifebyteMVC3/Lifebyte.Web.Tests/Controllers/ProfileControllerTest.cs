using System;
using System.Linq;
using System.Web.Mvc;
using Lifebyte.Web.Controllers;
using Lifebyte.Web.Models.Core.Entities;
using Lifebyte.Web.Models.Core.Interfaces;
using Moq;
using NUnit.Framework;
using System.Security.Principal;
using System.Linq.Expressions;

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
            volunteerDataService.Setup(v => v.SelectOne(It.IsAny<Expression<Func<Volunteer, bool>>>()))
                .Returns(new Volunteer());

            var profileController = new ProfileController(volunteerDataService.Object,
                                                          new Mock<IFormsAuthenticationService>().Object);

            ActionResult result = profileController.Index();

            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void Edit_ReturnsView()
        {            
            var formsAuthenticationService = new Mock<IFormsAuthenticationService>();
            formsAuthenticationService.Setup(f => f.GetVolunteerID((IPrincipal)null))
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
    }
}