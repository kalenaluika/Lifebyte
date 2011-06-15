using FluentNHibernate.Automapping.Alterations;
using FluentNHibernate.Automapping;
using Lifebyte.Web.Models.Core.Entities;

namespace Lifebyte.Web.Models.Data.Overrides
{
    public class ComputerMappingOverride : IAutoMappingOverride<Computer>
    {
        public void Override(AutoMapping<Computer> mapping)
        {
            mapping.Map(c => c.ManifestHtml).Length(4001);
            mapping.Map(c => c.Notes).Length(4000);

      //      mapping.Map(c => c.CreateByVolunteer).Column("CreateByVolunteerId");
      //      mapping.Map(c => c.LastModByVolunteer.Id).Column("LastModByVolunteerId");
       //     mapping.Map(c => c.LicenceType).Column("LicenceTypeCode");
            //None of these mappings work
         //        mapping.Map(s => s.CreateByVolunteer).Not.Nullable();
                 mapping.Map(s => s.CreateDate).Not.Nullable();
                 mapping.Map(s => s.Active).Not.Nullable();
               mapping.Map(s => s.Active).Default("1");
        }
    }

    public class ComputerStatusMappingOverride : IAutoMappingOverride<ComputerStatus>
    {
        public void Override(AutoMapping<ComputerStatus> mapping)
        {
            mapping.Map(s => s.Name).Not.Nullable(); 
            mapping.Map(s => s.Description).Length(200);
            //mapping.Map(s => s.CreateByVolunteer).Not.Nullable();
            //mapping.Map(s => s.CreateDate).Not.Nullable();
            mapping.Map(s => s.Active).Default("1");
            mapping.Map(s => s.Active).Not.Nullable();
        }
    }

    public class LicenseTypeMappingOverride : IAutoMappingOverride<LicenceType>
    {
        public void Override(AutoMapping<LicenceType> mapping)
        {
            // guessing on how might designate something than ID
            // to be the primary key
            mapping.Id(l => l.Code).Length(10);
         //   mapping.Id(l=> l.Code)
         //   mapping.Map(l => l.Code).Length(10);
            //mapping.Map(l => l.CreateByVolunteer).Not.Nullable();
            mapping.Map(s => s.CreateDate).Not.Nullable();
            mapping.Map(s => s.Active).Default("1");
        }
    }
}