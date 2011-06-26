using Lifebyte.Web.Models.Core.Interfaces;

namespace Lifebyte.Web.Models.Core.Entities
{
    public class UnitedStatesState : ICoreEntity
    {
        /// <summary>
        /// This is the 2 letter abbreviation of the state.
        /// </summary>
        public virtual string Id { get; set; }

        public virtual string FullName { get; set; }
    }
}