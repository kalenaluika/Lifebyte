using System.ComponentModel.DataAnnotations;
using Lifebyte.Web.Models.Core.Interfaces;

namespace Lifebyte.Web.Models.Core.Entities
{
    public class LicenceType : ICoreEntity
    {
        [ScaffoldColumn(false)]
        public virtual int Id { get; set; }

        [Required]
        public virtual string Code { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public virtual string FullName { get; set; }

        [ScaffoldColumn(false)]
        public virtual int? SortOrder { get; set; }

        /// <summary>
        /// We do not delete from the website. We only set records to be inactive and 
        /// filter them out of search results.
        /// </summary>        
        [ScaffoldColumn(false)]
        public virtual bool Active { get; set; }
    }
}