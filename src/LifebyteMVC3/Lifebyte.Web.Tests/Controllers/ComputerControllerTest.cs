using System.Web.Mvc;
using Lifebyte.Web.Controllers;
using NUnit.Framework;
using Lifebyte.Web.Models.Core.Entities;
using Lifebyte.Web.Models.Core.Interfaces;
using Lifebyte.Web.Models.ViewModels;
using Moq;


namespace Lifebyte.Web.Tests.Controllers
{
    [TestFixture]
    public class ComputerControllerTest
    {        
        [Test]
        public void Index_ReturnsView()
        {
            var controller = new ComputerController();
            ActionResult result = controller.Index();

            Assert.IsInstanceOf<ViewResult>( result);
        }


        [Test]
        public void Index_Computer_ReturnsView()
        {
            var computerController = new ComputerController();
         //       new Mock<IFormsAuthenticationService>().Object,
         //       new Mock<IDataService<Computer>>().Object);

            ActionResult result = computerController.Index();

            Assert.IsInstanceOf<ViewResult>(result);
            var view = (ViewResult)result;
            Assert.IsNotNull(view.ViewData.Model);
            Assert.IsInstanceOf<Computer>(view.ViewData.Model);
        }
    }
}
