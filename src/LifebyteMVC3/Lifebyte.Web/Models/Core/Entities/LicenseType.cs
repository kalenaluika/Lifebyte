using Lifebyte.Web.Models.Core.Interfaces;

namespace Lifebyte.Web.Models.Core.Entities
{
    public class LicenseType : ICoreEntity
    {
        public virtual string Id { get; set; }

        public virtual string Description { get; set; }
    }
}