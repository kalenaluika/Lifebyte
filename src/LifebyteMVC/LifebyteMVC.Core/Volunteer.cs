using System;

namespace LifebyteMVC.Core
{
    public class Volunteer
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

        /// <summary>
        /// We do not delete from the website. We only set records to be inactive and 
        /// filter them out of search results.
        /// </summary>
        public virtual bool Active { get; set; }
    }
}
