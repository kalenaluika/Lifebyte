using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LifebyteMVC.Core
{
    public class Recipient
    {
        /// <summary>
        /// (the unique ID of the recipient)
        /// </summary>
        public Guid ID { get; set; } 

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        /// <summary>
        /// (a primary contact number and a secondary one)
        /// </summary>
        public string Phone { get; set; }
 
        /// <summary>
        /// (notes that the volunteer entered about the recipient)
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// (either new, needs computer, needs repair, completed, scheduled)
        /// </summary>
        public RecipientStatus RecipientStatus { get; set; }

        /// <summary>
        /// (the date the recipient was scheduled to receive the equipment)
        /// </summary>
        public DateTime ScheduleDate { get; set; }

        /// <summary>
        ///  (either delivery or pick-up)
        /// </summary>        
        public ScheduleType ScheduleType { get; set; }

        /// <summary>
        ///  (the organization that is receiving the donation if applicable)
        /// </summary>        
        public string Organization { get; set; }

        /// <summary>
        ///  (the e-mail address of the recipient)
        /// </summary>        
        public string Email { get; set; }

        /// <summary>
        ///  (the date the recipient contacted us. We try to help people in the order that they contacted us.)
        /// </summary>
        public DateTime ContactDate { get; set; }

        /// <summary>
        ///  (the date the record was created)
        /// </summary>        
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// (the volunteer who created the record)
        /// </summary>
        public Volunteer CreatedByVolunteer { get; set; }

        /// <summary>
        /// (the date the record was last modified)
        /// </summary>
        public DateTime LastModifiedDate { get; set; } 

        /// <summary>
        /// (the volunteer who last modified the record)
        /// </summary>
        public Volunteer LastModifiedByVolunteer { get; set; } 

    }
}
