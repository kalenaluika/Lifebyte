using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Lifebyte.Web.Models.Core.Entities;
using Lifebyte.Web.Models.Data;
using Lifebyte.Web.Models.Data.Overrides;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace Lifebyte.Web.Tests.Models.Data
{
    /// <summary>
    /// Tests for AutomappingConfiguration.
    /// These tests generate extra files such as HBM.XML and DDL files if enabled.
    /// </summary>
    [TestFixture]
    public class AutomappingConfigurationTest
    {
        private string exportPath;
        private string connectionString;

        /// <summary>
        /// Use TestInitialize to run code before running each test.
        /// </summary>
        [TestFixtureSetUp]
        public void MyTestInitialize()
        {
            exportPath = getExportPath();

            // This string might vary depending on your computer.
            // If you change this, be sure to set it back.
            connectionString = "server=localhost;database=LifebyteDevDB;trusted_connection=true;";
        }

        /// <summary>    
        /// Matches the automapping to the database.
        /// If this fails, unignore the test below to generate the DDL script.
        /// </summary>
        /// <remarks>http://ayende.com/Blog/archive/2006/08/09/NHibernateMappingCreatingSanityChecks.aspx</remarks>
        [Test]
        public void AutomappingConfiguration_Mapping_Confirmation()
        {
            ISessionFactory sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(connectionString))
                .Mappings(m => m.AutoMappings.Add(CreateAutomappings))
                .BuildSessionFactory();

            using (ISession session = sessionFactory.OpenSession())
            {
                var allClassMetadata = session.SessionFactory.GetAllClassMetadata();

                foreach (var entry in allClassMetadata)
                {
                    session.CreateCriteria(entry.Value.GetMappedClass(EntityMode.Poco))
                        .SetMaxResults(0).List();
                }
            }
        }

        /// <summary>
        /// Unignore to generate the hbm.xml mapping files and DDL script.
        /// </summary>
        [Test]
        public void Generate_Mapping_File_Export()
        {
            Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(connectionString))
                .Mappings(m => m.AutoMappings
                                   .Add(CreateAutomappings)
                                   .ExportTo(exportPath))
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();
        }

        /// <summary>
        /// The Volunteer entity should be mapped.
        /// </summary>
        [Test]
        public void Volunteer_ShouldMap_Test()
        {
            var automapConfig = new AutomappingConfiguration();

            Assert.IsTrue(automapConfig.ShouldMap(typeof (Volunteer)));
        }
        
        /// <summary>
        /// The Computer entity should be mapped.
        /// </summary>
        [Test]
        public void Computer_ShouldMap_Test()
        {
            var automapConfig = new AutomappingConfiguration();

            Assert.IsTrue(automapConfig.ShouldMap(typeof(Computer)));
        }

        /// <summary>
        /// The ComputerStatus entity should be mapped.
        /// </summary>
        [Test]
        public void ComputerStatus_ShouldMap_Test()
        {
            var automapConfig = new AutomappingConfiguration();

            Assert.IsTrue(automapConfig.ShouldMap(typeof(ComputerStatus)));
        }

        /// <summary>
        /// The LicenseType entity should be mapped.
        /// </summary>
        [Test]
        public void LicenseType_ShouldMap_Test()
        {
            var automapConfig = new AutomappingConfiguration();

            Assert.IsTrue(automapConfig.ShouldMap(typeof(LicenceType)));
        }

        private AutoPersistenceModel CreateAutomappings()
        {
            return AutoMap.AssemblyOf<Volunteer>(new AutomappingConfiguration())
                .Conventions.Add<CascadeConvention>()
                .UseOverridesFromAssemblyOf<VolunteerMappingOverride>()
                .Conventions.AddFromAssemblyOf<DefaultStringLengthConvention>();
        }

        private void BuildSchema(Configuration config)
        {
            new SchemaExport(config)
                .SetOutputFile(exportPath + @"\ddl.sql")
                .Create(false, false);
        }

        private string getExportPath()
        {
            string localPath = System.Environment.CurrentDirectory;
            const string folderName = "LifebyteMVC3";
            int length = localPath.IndexOf(folderName) + folderName.Length;
            localPath = localPath.Substring(0, length);

            return localPath + @"\Lifebyte.Web.Tests";
        }
    }
}