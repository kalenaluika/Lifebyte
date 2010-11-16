using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LifebyteMVC.Core
{
    public class Volunteer
    {
        public string VolunteerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string PrimaryPhone { get; set; }
        public string SecondaryPhone { get; set; }
        public string Email { get; set; }
    }
}
