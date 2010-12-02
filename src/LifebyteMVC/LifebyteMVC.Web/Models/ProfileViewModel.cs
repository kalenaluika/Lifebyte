using LifebyteMVC.Core;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System;

namespace LifebyteMVC.Web.Models
{
    public class ProfileViewModel
    {
        [DisplayName("First Name")]
        [StringLength(50)]
        [Required(ErrorMessage="First Name is required")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [StringLength(50)]
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }
                
        [StringLength(50)]
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }

        [DisplayName("Zip Code")]
        [StringLength(50)]
        [Required(ErrorMessage = "Zip Code is required")]
        public string Zip { get; set; }

        [DisplayName("Primary Phone Number")]
        [StringLength(50)]
        [Required(ErrorMessage = "Primary Phone Number is required")]
        public string PrimaryPhone { get; set; }

        [DisplayName("Secondary Phone Number")]
        [StringLength(50)]
        public string SecondaryPhone { get; set; }

        [DisplayName("Email Address")]
        [StringLength(50)]
        [Required(ErrorMessage = "Email Address is required")]
        public string Email { get; set; }
               
    }
}
