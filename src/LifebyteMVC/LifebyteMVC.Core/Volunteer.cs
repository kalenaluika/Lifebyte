using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LifebyteMVC.Core
{
    public class Volunteer
    {
        public virtual string VolunteerID { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Company { get; set; }
        public virtual string Address { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }
        public virtual string Zip { get; set; }
        public virtual string PrimaryPhone { get; set; }
        public virtual string SecondaryPhone { get; set; }
        public virtual string Email { get; set; }
    }
}
