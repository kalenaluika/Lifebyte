using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace Lifebyte.Web.Models.Data
{
    /// <summary>    
    /// We do not allow the website to delete data. 
    /// Instead we update the record to make it inactive.
    /// </summary>    
    public class CascadeConvention : IReferenceConvention, IHasManyConvention, IHasManyToManyConvention
    {
        public void Apply(IManyToOneInstance instance)
        {
            instance.Cascade.SaveUpdate();
        }

        public void Apply(IOneToManyCollectionInstance instance)
        {
            instance.Cascade.SaveUpdate();
        }

        public void Apply(IManyToManyCollectionInstance instance)
        {
            instance.Cascade.SaveUpdate();
        }
    }
}