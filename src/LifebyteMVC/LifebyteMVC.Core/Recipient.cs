using System;
using System.Collections.Generic;

namespace LifebyteMVC.Core
{
    public class Recipient
    {
        public virtual Guid Id { get; private set; }

        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual string Organization { get; set; }

        public virtual string Address { get; set; }

        public virtual string City { get; set; }

        public virtual string State { get; set; }

        public virtual string Zip { get; set; }

        public virtual string Email { get; set; }

        public virtual string Phone { get; set; }

        public virtual RecipientStatus RecipientStatus { get; set; }

        /// <summary>
        /// Notes that the volunteer entered about the recipient.
        /// </summary>
        public virtual string Notes { get; set; }

        /// <summary>
        /// The date the recipient contacted us. 
        /// We try to help people in the order that they contacted us.
        /// </summary>
        public virtual DateTime ContactDate { get; set; }

        /// <summary>
        /// The date the recipient was scheduled to receive the computer.
        /// </summary>
        public virtual DateTime ScheduleDate { get; set; }

        public virtual ScheduleType ScheduleType { get; set; }

        /// <summary>
        /// The date the record was created.
        /// </summary>        
        public virtual DateTime CreateDate { get; set; }

        /// <summary>
        /// The volunteer who created the record.
        /// </summary>
        public virtual Volunteer CreatedByVolunteer { get; set; }

        /// <summary>
        /// The date the record was last modified.
        /// </summary>
        public virtual DateTime LastModifiedDate { get; set; }

        /// <summary>
        /// The volunteer who last modified the record.
        /// </summary>
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
        public virtual bool Active { get; set; }

        public Recipient()
        {
            Computers = new List<Computer>();
        }
    }
}