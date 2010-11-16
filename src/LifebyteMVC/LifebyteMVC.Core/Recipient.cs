using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace LifebyteMVC.Core
{
    public class Recipient
    {
        /// <summary>
        /// (the unique ID of the recipient)
        /// </summary>
        public virtual Guid ID { get; private set; } 

        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual string Address { get; set; }

        public virtual string City { get; set; }

        public virtual string State { get; set; }

        public virtual string Zip { get; set; }

        /// <summary>
        /// (a primary contact number and a secondary one)
        /// </summary>
        public virtual string Phone { get; set; }
 
        /// <summary>
        /// (notes that the volunteer entered about the recipient)
        /// </summary>
        public virtual string Notes { get; set; }

        /// <summary>
        /// (either new, needs computer, needs repair, completed, scheduled)
        /// </summary>
        public virtual RecipientStatus RecipientStatus { get; set; }

        /// <summary>
        /// (the date the recipient was scheduled to receive the equipment)
        /// </summary>
        public virtual DateTime ScheduleDate { get; set; }

        /// <summary>
        ///  (either delivery or pick-up)
        /// </summary>        
        public virtual ScheduleType ScheduleType { get; set; }

        /// <summary>
        ///  (the organization that is receiving the donation if applicable)
        /// </summary>        
        public virtual string Organization { get; set; }

        /// <summary>
        ///  (the e-mail address of the recipient)
        /// </summary>        
        public virtual string Email { get; set; }

        /// <summary>
        ///  (the date the recipient contacted us. We try to help people in the order that they contacted us.)
        /// </summary>
        public virtual DateTime ContactDate { get; set; }

        /// <summary>
        ///  (the date the record was created)
        /// </summary>        
        public virtual DateTime CreateDate { get; set; }

        /// <summary>
        /// (the volunteer who created the record)
        /// </summary>
        public virtual Volunteer CreatedByVolunteer { get; set; }

        /// <summary>
        /// (the date the record was last modified)
        /// </summary>
        public virtual DateTime LastModifiedDate { get; set; } 

        /// <summary>
        /// (the volunteer who last modified the record)
        /// </summary>
        public virtual Volunteer LastModifiedByVolunteer { get; set; }

        /// <summary>
        /// The inventory items that a recipient has received.
        /// </summary>
        public virtual IList<Inventory> InventoryItems { get; set; }

        public Recipient()
        {
            InventoryItems = new List<Inventory>();
        }
    }
}