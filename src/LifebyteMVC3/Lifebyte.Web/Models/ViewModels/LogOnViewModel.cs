namespace Lifebyte.Web.Models.ViewModels
{
    public class LogOnViewModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        /// <summary>
        /// Puts a cookie on the volunteer's computer so that
        /// they do not have to sign in on the next visit.
        /// </summary>
        public bool RememberMe { get; set; }
    }
}