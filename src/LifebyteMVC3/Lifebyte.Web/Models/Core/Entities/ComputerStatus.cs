using Lifebyte.Web.Models.Core.Interfaces;

namespace Lifebyte.Web.Models.Core.Entities
{
    public class ComputerStatus : ICoreEntity
    {
        public virtual int Id { get; set; }

        public virtual string Description { get; set; }
    }
}