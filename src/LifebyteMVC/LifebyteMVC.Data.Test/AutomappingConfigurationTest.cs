using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using LifebyteMVC.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace LifebyteMVC.Data.Test
{
    /// <summary>
    /// Tests for AutomappingConfiguration.
    /// These tests generate extra files such as HBM.XML and DDL files if enabled.
    /// </summary>
    [TestClass]
    public class AutomappingConfigurationTest
    {
        private AutomappingConfiguration automapConfig;
        private TestContext testContextInstance;
        private string exportPath;
        private string connectionString;

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
        /// Use TestInitialize to run code before running each test.
        /// </summary>
        [TestInitialize()]
        public void MyTestInitialize()
        {
            automapConfig = new AutomappingConfiguration();
            exportPath = getExportPath();

            // This string might vary depending on your computer.
            // If you change this, be sure to set it back.
            connectionString = "server=localhost;database=LifebyteDB;trusted_connection=true;";
        }

        /// <summary>
        /// Use TestCleanup to run code after each test has run.
        /// </summary>
        [TestCleanup()]
        public void MyTestCleanup()
        {
            automapConfig = null;
            exportPath = null;
            connectionString = null;
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
        /// The Computer entity should be mapped.
        /// </summary>
        [TestMethod]
        public void AutomappingConfiguration_ShouldMap_Test()
        {
            Assert.IsTrue(automapConfig.ShouldMap(typeof(Computer)));
        }

        /// <summary>
        /// Unignore to generate the hbm.xml mapping files and DDL script.
        /// </summary>
        [TestMethod, Ignore]
        public void AutomappingConfiguration_Mapping_File_Export_Test()
        {
            var test = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(connectionString))
                .Mappings(m => m.AutoMappings
                    .Add(CreateAutomappings)
                    .ExportTo(exportPath))
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();

            test.Close();
        }

        /// <summary>    
        /// Matches the automapping to the database.
        /// </summary>
        /// <remarks>http://ayende.com/Blog/archive/2006/08/09/NHibernateMappingCreatingSanityChecks.aspx</remarks>
        [TestMethod]
        public void AutomappingConfiguration_Mapping_Confirmation_Test()
        {
            var nHibernateSession = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(connectionString))
                .Mappings(m => m.AutoMappings
                    .Add(CreateAutomappings))
                .BuildSessionFactory();

            using (ISession session = nHibernateSession.OpenSession())
            {
                var allClassMetadata = session.SessionFactory.GetAllClassMetadata();

                foreach (var entry in allClassMetadata)
                {
                    session.CreateCriteria(entry.Value.GetMappedClass(EntityMode.Poco))
                         .SetMaxResults(0).List();
                }
            }
        }

        private AutoPersistenceModel CreateAutomappings()
        {
            return AutoMap.AssemblyOf<Computer>(new AutomappingConfiguration())
                .Conventions.Add<CascadeConvention>();
        }

        private void BuildSchema(Configuration config)
        {
            new SchemaExport(config)
               .SetOutputFile(exportPath + @"\ddl.txt")
               .Create(false, false);
        }

        private string getExportPath()
        {
            string localPath = System.Environment.CurrentDirectory;
            string folderName = "LifebyteMVC";
            int length = localPath.IndexOf(folderName) + folderName.Length;
            localPath = localPath.Substring(0, length);

            return localPath + @"\LifebyteMVC.Data.Test";
        }
    }
}
