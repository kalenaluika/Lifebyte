using System;
using LifebyteMVC.Core.Interfaces;

namespace LifebyteMVC.Core.Model
{
    public class Volunteer : ICoreEntity
    {
        public virtual Guid Id { get; set; }
        
        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual string Address { get; set; }

        public virtual string City { get; set; }

        public virtual string State { get; set; }

        public virtual string Zip { get; set; }

        public virtual string PrimaryPhone { get; set; }

        public virtual string SecondaryPhone { get; set; }

        public virtual string Email { get; set; }

        public virtual DateTime LastSignInDate { get; set; }

        /// <summary>
        /// The Open ID provider information.
        /// We will use this value to find the volunteer's record.
        /// </summary>
        public virtual string ClaimedIdentifier { get; set; }

        /// <summary>
        /// We do not delete from the website. We only set records to be inactive and 
        /// filter them out of search results.
        /// </summary>
        public virtual bool Active { get; set; }
    }
}
