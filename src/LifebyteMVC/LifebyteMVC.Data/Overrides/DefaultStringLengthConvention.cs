using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace LifebyteMVC.Data.Overrides
{
    public class DefaultStringLengthConvention : IPropertyConvention
    {
        public void Apply(IPropertyInstance instance)
        {
            instance.Length(50);
        }
    }
}
