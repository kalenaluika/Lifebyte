using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace LifebyteMVC.Data
{
    /// <summary>    
    /// This is a convention that will be applied to all entities.
    /// </summary>    
    public class CascadeConvention : IReferenceConvention, IHasManyConvention, IHasManyToManyConvention
    {
        public void Apply(IManyToOneInstance instance)
        {
            instance.Cascade.All();
        }

        public void Apply(IOneToManyCollectionInstance instance)
        {
            instance.Cascade.All();
        }

        public void Apply(IManyToManyCollectionInstance instance)
        {
            instance.Cascade.All();
        }
    }
}
