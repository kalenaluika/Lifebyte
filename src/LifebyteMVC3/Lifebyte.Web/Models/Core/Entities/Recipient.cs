using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Lifebyte.Web.Models.Core.Interfaces;

namespace Lifebyte.Web.Models.Core.Entities
{
    public class Recipient : ICoreEntity
    {
        public Recipient()
        {
            Computers = new List<Computer>();
        }

        [HiddenInput(DisplayValue = false)]
        [Required]
        public virtual Guid Id { get; set; }

        [Display(Name = "First Name")]
        [Required]
        public virtual string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public virtual string LastName { get; set; }

        public virtual string Organization { get; set; }

        public virtual string Address { get; set; }

        public virtual string City { get; set; }

        [UIHint("_StateDropdownList")]
        public virtual string State { get; set; }

        public virtual string Zip { get; set; }

        public virtual string Email { get; set; }

        [Required]
        public virtual string Phone { get; set; }

        [UIHint("_RecipientStatusDropdownList")]
        [Display(Name = "Status")]
        public virtual string RecipientStatus { get; set; }

        /// <summary>
        /// Notes that the volunteer entered about the recipient.
        /// </summary>
        public virtual string Notes { get; set; }

        /// <summary>
        /// The date the recipient contacted us. 
        /// We try to help people in the order that they contacted us.
        /// </summary>
        [Display(Name = "Contact Date")]
        public virtual DateTime ContactDate { get; set; }

        /// <summary>
        /// The date the recipient was scheduled to receive the computer.
        /// </summary>
        [Display(Name = "Schedule Date")]
        public virtual DateTime ScheduleDate { get; set; }

        [UIHint("_ScheduleTypeDropdownList")]
        [Display(Name = "Schedule Type")]
        public virtual string ScheduleType { get; set; }

        /// <summary>
        /// The date the record was created.
        /// </summary>
        [ScaffoldColumn(false)]
        public virtual DateTime CreateDate { get; set; }

        /// <summary>
        /// The volunteer who created the record.
        /// </summary>
        [ScaffoldColumn(false)]
        public virtual Volunteer CreatedByVolunteer { get; set; }

        /// <summary>
        /// The date the record was last modified.
        /// </summary>
        [ScaffoldColumn(false)]
        public virtual DateTime LastModifiedDate { get; set; }

        /// <summary>
        /// The volunteer who last modified the record.
        /// </summary>
        [ScaffoldColumn(false)]
        public virtual Volunteer LastModifiedByVolunteer { get; set; }

        /// <summary>
        /// The computers that a recipient has received.
        /// This is needed by the ORM to link to a computer.
        /// </summary>
        public virtual IList<Computer> Computers { get; set; }

        /// <summary>
        /// We do not delete from the website. We only set records to be inactive and 
        /// filter them out of search results.
        /// </summary>
        [ScaffoldColumn(false)]
        public virtual bool Active { get; set; }
    }
}