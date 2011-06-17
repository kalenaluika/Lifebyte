using System.ComponentModel.DataAnnotations;
using Lifebyte.Web.Models.Core.Interfaces;

namespace Lifebyte.Web.Models.Core.Entities
{
    public class ComputerStatus : ICoreEntity
    {
        [ScaffoldColumn(false)]
        public virtual int Id { get; set; }

        [Required]
        public virtual string Name { get; set; }

        [Required]
        public virtual string Description { get; set; }

        /// <summary>
        /// We do not delete from the website. We only set records to be inactive and 
        /// filter them out of search results.
        /// </summary>        
        [ScaffoldColumn(false)]
        public virtual bool Active { get; set; }
    }
}