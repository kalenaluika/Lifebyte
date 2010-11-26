using System.ComponentModel.DataAnnotations;

namespace LifebyteMVC.Web.Models
{
    public class SignInViewModel
    {
        /// <summary>
        /// The URL to return the volunteer to after a successful sign in.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        /// The URL of the Open ID provider.
        /// </summary>
        [Required(ErrorMessage="An Open ID URL is required.")]
        public string OpenIdUrl { get; set; }
    }
}