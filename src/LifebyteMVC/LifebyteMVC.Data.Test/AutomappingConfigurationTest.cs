using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using LifebyteMVC.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System.IO;
using System.Linq;

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
            Assert.IsTrue(automapConfig.ShouldMap(typeof(Computer)));
        }

        [TestMethod, Ignore]
        public void AutomappingConfiguration_IsComponent_Test()
        {
            Assert.IsTrue(automapConfig.IsComponent(typeof(ComputerStatus)));
        }

        /// <summary>
        /// Unignore to generate the hbm.xml mapping files.
        /// </summary>
        [TestMethod]
        public void AutomappingConfiguration_Mapping_File_Export_Test() 
        { 
            var test = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString("server=windows7-imac\\sqlexpress;database=LifebyteDB;trusted_connection=true;"))
                .Mappings(m => m.AutoMappings
                    .Add(CreateAutomappings)
                    .ExportTo(exportPath))
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory(); 
        }

         private AutoPersistenceModel CreateAutomappings()        
         {            
             return AutoMap.AssemblyOf<Computer>(new AutomappingConfiguration())
                 .Conventions.Add<CascadeConvention>();        
         }

         private void BuildSchema(Configuration config)        
         {
             //string[] ddl = config.GenerateSchemaCreationScript(NHibernate.Dialect.MsSql2008Dialect.GetDialect());

             //using (StreamWriter sw = new StreamWriter(exportPath + @"\ddl.txt", false))
             //{
             //    ddl.ToList().ForEach(d => sw.WriteLine(d));                 
             //}

             new SchemaExport(config)
                .SetOutputFile(exportPath + @"\ddl.txt")
                .Create(false, false);
             
         }
    }
}
