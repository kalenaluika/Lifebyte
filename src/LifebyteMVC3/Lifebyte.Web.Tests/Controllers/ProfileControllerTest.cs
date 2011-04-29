using System.Linq;
using NUnit.Framework;
using Lifebyte.Web.Controllers;
using System.Web.Mvc;

namespace Lifebyte.Web.Tests.Controllers
{
    [TestFixture]
    public class ProfileControllerTest
    {
        [Test]
        public void ProfileController_Constructor_Is_Valid()
        {
            var profileController = new ProfileController();

            Assert.IsInstanceOf<Controller>(profileController);
        }

        [Test]
        public void ProfileController_Class_Is_Authorized()
        {
            Assert.IsTrue(typeof(ProfileController)
                .GetCustomAttributes(false)
                .Any(c => c.GetType() == typeof(AuthorizeAttribute)));
        }

        [Test]
        public void ProfileController_Index_Returns_View()
        {
            var profileController = new ProfileController();

            ActionResult result = profileController.Index();

            Assert.IsInstanceOf<ViewResult>(result);
        }
    }
}
