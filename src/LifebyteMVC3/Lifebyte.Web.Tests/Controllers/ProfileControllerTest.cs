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
        public void Constructor_IsValid()
        {
            var profileController = new ProfileController();

            Assert.IsInstanceOf<Controller>(profileController);
        }

        [Test]
        public void Class_Is_Authorized()
        {
            Assert.IsTrue(typeof(ProfileController)
                .GetCustomAttributes(false)
                .Any(c => c.GetType() == typeof(AuthorizeAttribute)));
        }

        [Test]
        public void Index_ReturnsView()
        {
            var profileController = new ProfileController();

            ActionResult result = profileController.Index();

            Assert.IsInstanceOf<ViewResult>(result);
        }
    }
}
