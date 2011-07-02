using System;
using System.ComponentModel.DataAnnotations;
using Lifebyte.Web.Models.Core.Interfaces;

namespace Lifebyte.Web.Models.Core.Entities
{
    public class Computer : ICoreEntity
    {
        [ScaffoldColumn(false)]
        public virtual Guid Id { get; set; }

        public virtual Recipient Recipient { get; set; }

        [Required]
        [UIHint("_ComputerStatusDropdownList")]
        public virtual string ComputerStatus { get; set; }

        // same as above
        [Display(Name = "Lifebyte Number")]
        public virtual string LifebyteNumber { get; set; }

        public virtual string Notes { get; set; }

        [Display(Name = "Belarc HTML File")]
        [UIHint("_ManifestHtmlFileUpload")]
        public virtual string ManifestHtml { get; set; }

        [Display(Name = "License")]
        public virtual string WindowsLicense { get; set; }

        [Display(Name = "License Type")]
        [UIHint("_LicenseTypeDropdownList")]
        public virtual string LicenseType { get; set; }

        [ScaffoldColumn(false)]
        public virtual Volunteer CreateByVolunteer { get; set; }

        [ScaffoldColumn(false)]
        public virtual DateTime CreateDate { get; set; }

        [ScaffoldColumn(false)]
        public virtual Volunteer LastModByVolunteer { get; set; }

        [ScaffoldColumn(false)]
        public virtual DateTime LastModDate { get; set; }

        /// <summary>
        /// We do not delete from the website. We only set records to be inactive and 
        /// filter them out of search results.  how do we default it to true
        /// </summary>        
        [ScaffoldColumn(false)]
        public virtual bool Active { get; set; }
    }
}