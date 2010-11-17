using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LifebyteMVC.Data;
using LifebyteMVC.Core;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Automapping;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace LifebyteMVC.Data.Test
{
    /// <summary>
    /// Tests for AutomappingConfiguration
    /// </summary>
    [TestClass]
    public class AutomappingConfigurationTest
    {
        private AutomappingConfiguration automapConfig;
        private TestContext testContextInstance;
        private string exportPath;

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
            automapConfig = new AutomappingConfiguration();
            string localPath = System.Environment.CurrentDirectory;
            localPath = localPath.Substring(0, localPath.IndexOf("LifebyteMVC") + 11);
            exportPath = localPath + @"\LifebyteMVC.Data.Test";
        }

        /// <summary>
        /// Use TestCleanup to run code after each test has run
        /// </summary>
        [TestCleanup()]
        public void MyTestCleanup()
        {
            automapConfig = null;
            exportPath = null;
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
        public void AutomappingConfiguration_ShouldMap_Test()
        {
            Assert.IsTrue(automapConfig.ShouldMap(typeof(Inventory)));
        }

        [TestMethod]
        public void AutomappingConfiguration_IsComponent_Test()
        {
            Assert.IsTrue(automapConfig.IsComponent(typeof(InventoryStatus)));
        }

        /// <summary>
        /// Unignore to generate the hbm.xml mapping files.
        /// </summary>
        [TestMethod, Ignore]
        public void AutomappingConfiguration_Mapping_File_Export_Test() 
        { 
            var test = Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.InMemory())
                .Mappings(m => m.AutoMappings
                    .Add(CreateAutomappings)
                    .ExportTo(exportPath))
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory(); 
        }

         private AutoPersistenceModel CreateAutomappings()        
         {            
             return AutoMap.AssemblyOf<Inventory>(new AutomappingConfiguration())
                 .Conventions.Add<CascadeConvention>();        
         }

         private void BuildSchema(Configuration config)        
         {
             new SchemaExport(config)
                 .Create(false, true);
         }
    }
}
