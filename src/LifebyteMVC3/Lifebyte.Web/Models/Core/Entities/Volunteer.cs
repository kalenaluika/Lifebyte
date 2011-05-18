using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Lifebyte.Web.Models.Core.Entities
{
    public class Volunteer
    {
        [ScaffoldColumn(false)]
        public virtual Guid Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public virtual string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public virtual string LastName { get; set; }

        public virtual string Address { get; set; }

        public virtual string City { get; set; }

        public virtual string State { get; set; }

        public virtual string Zip { get; set; }

        [Required]
        [Display(Name = "Primary Phone")]
        public virtual string PrimaryPhone { get; set; }

        [Display(Name = "Secondary Phone")]
        public virtual string SecondaryPhone { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        public virtual string Email { get; set; }

        [Required]
        public virtual string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public virtual string Password { get; set; }


        [ScaffoldColumn(false)]
        public virtual DateTime LastSignInDate { get; set; }

        /// <summary>
        /// We do not delete from the website. We only set records to be inactive and 
        /// filter them out of search results.
        /// </summary>        
        [ScaffoldColumn(false)]
        public virtual bool Active { get; set; }
    }
}
