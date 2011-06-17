using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using Lifebyte.Web.Models.Core.Entities;

namespace Lifebyte.Web.Models.Data.Overrides
{
    public class LicenseTypeMappingOverride : IAutoMappingOverride<LicenceType>
    {
        public void Override(AutoMapping<LicenceType> mapping)
        {
            mapping.Id(l => l.Code).Length(10);
            mapping.Map(s => s.Active).Default("1");
        }
    }
}