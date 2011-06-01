using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace Lifebyte.Web.Models.Data.Overrides
{
    public class DefaultStringLengthConvention : IPropertyConvention
    {
        public void Apply(IPropertyInstance instance)
        {
            instance.Length(50);
        }
    }
}