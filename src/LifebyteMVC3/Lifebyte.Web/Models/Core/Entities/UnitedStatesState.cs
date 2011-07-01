using Lifebyte.Web.Models.Core.Interfaces;
namespace Lifebyte.Web.Models.Core.Entities
{
    public class UnitedStatesState : ICoreEntity
    {
        public virtual string Id { get; set; }

        public virtual string FullName { get; set; }
    }
}