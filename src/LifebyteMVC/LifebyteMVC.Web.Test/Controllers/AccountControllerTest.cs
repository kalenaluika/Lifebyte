using System.Web.Mvc;
using LifebyteMVC.Web.Controllers;
using LifebyteMVC.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LifebyteMVC.Web.Test.Controllers
{
    /// <summary>
    /// Test for the AccountController
    /// </summary>
    [TestClass]
    public class AccountControllerTest
    {
        private AccountController controller;
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        /// <summary>
        /// Use TestInitialize to run code before running each test 
        /// </summary>
        [TestInitialize()]
        public void MyTestInitialize()
        {
            controller = new AccountController();
        }

        /// <summary>
        /// Use TestCleanup to run code after each test has run
        /// </summary>
        [TestCleanup()]
        public void MyTestCleanup()
        {
            controller = null;
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        #endregion

        /// <summary>
        /// These tests are not working.
        /// </summary>
        [TestMethod]
        public void AccountController_Index_Test()
        {
            ViewResult result = (ViewResult)controller.Index();
            
            Assert.IsInstanceOfType(result.ViewData.Model, typeof(SignInViewModel));
        }

        [TestMethod]
        public void AccountController_Index_Post_Test()
        {
            RedirectResult result = (RedirectResult)controller.Index(new SignInViewModel
                {
                    OpenIdUrl = "test"
                });

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void AccountController_Index_Post_Invalid_Model_Test()
        {
            RedirectResult result = (RedirectResult)controller.Index(new SignInViewModel());

            Assert.IsNotNull(result);
        }
    }
}
