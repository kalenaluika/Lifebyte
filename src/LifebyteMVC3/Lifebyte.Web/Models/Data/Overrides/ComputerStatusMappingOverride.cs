using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using Lifebyte.Web.Models.Core.Entities;

namespace Lifebyte.Web.Models.Data.Overrides
{
    public class ComputerStatusMappingOverride : IAutoMappingOverride<ComputerStatus>
    {
        public void Override(AutoMapping<ComputerStatus> mapping)
        {
            mapping.Map(s => s.Name).Not.Nullable();
            mapping.Map(s => s.Description).Length(200);
            mapping.Map(s => s.Active).Default("1");
            mapping.Map(s => s.Active).Not.Nullable();
        }
    }
}