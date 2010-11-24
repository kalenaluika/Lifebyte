
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
        public string OpenIdUrl { get; set; }
    }
}