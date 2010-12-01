using LifebyteMVC.Core;
using System.ComponentModel;

namespace LifebyteMVC.Web.Models
{
    public class ProfileViewModel
    {
        [DisplayName("First Name")]
        public string FirstName { get; set; }
    }
}
