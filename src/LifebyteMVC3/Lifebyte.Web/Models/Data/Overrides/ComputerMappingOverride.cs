using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using Lifebyte.Web.Models.Core.Entities;

namespace Lifebyte.Web.Models.Data.Overrides
{
    public class ComputerMappingOverride : IAutoMappingOverride<Computer>
    {
        public void Override(AutoMapping<Computer> mapping)
        {
            mapping.Map(c => c.ManifestHtml).Length(4001);
            mapping.Map(c => c.Notes).Length(4000);
            mapping.Map(s => s.CreateDate).Not.Nullable();
            mapping.Map(s => s.Active).Not.Nullable();
            mapping.Map(s => s.Active).Default("1");
        }
    }
}