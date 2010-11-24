using System;
using System.Web.Mvc;
using LifebyteMVC.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LifebyteMVC.Web.Test.Controllers
{
    /// <summary>
    /// Summary description for InventoryControllerTest
    /// </summary>
    [TestClass]
    public class InventoryControllerTest
    {
        private InventoryController controller;
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
            controller = new InventoryController();
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

        [TestMethod]
        public void InventoryController_Index_Test()
        {
            //Act
            ViewResult result = (ViewResult)controller.Index();

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void InventoryController_Edit_Test()
        {
            Guid inventoryID = Guid.NewGuid();
            ViewResult result = (ViewResult)controller.Edit(inventoryID);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void InventoryController_Belarc_Test()
        {
            Guid inventoryID = Guid.NewGuid();
            ViewResult result = (ViewResult)controller.Manifest(inventoryID);

            Assert.IsNotNull(result);
        }
    }
}
