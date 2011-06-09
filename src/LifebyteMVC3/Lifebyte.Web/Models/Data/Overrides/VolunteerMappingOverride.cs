using FluentNHibernate.Automapping.Alterations;
using FluentNHibernate.Automapping;
using Lifebyte.Web.Models.Core.Entities;

namespace Lifebyte.Web.Models.Data.Overrides
{
    public class VolunteerMappingOverride : IAutoMappingOverride<Volunteer>
    {
        public void Override(AutoMapping<Volunteer> mapping)
        {
            mapping.Map(v => v.Company).Length(100);
            mapping.Map(v => v.Address).Length(200); 
            mapping.Map(v => v.State).Length(2);
            mapping.Map(v => v.Zip).Length(10);
            mapping.Map(v => v.PrimaryPhone).Length(10);
            mapping.Map(v => v.SecondaryPhone).Length(10);
            mapping.Map(v => v.Email).Length(200);
        }
    }
}