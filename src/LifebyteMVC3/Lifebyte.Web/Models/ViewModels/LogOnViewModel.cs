using System.ComponentModel.DataAnnotations;

namespace Lifebyte.Web.Models.ViewModels
{
    public class LogOnViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>        
        /// Puts a cookie on the volunteer's computer so that        
        /// they do not have to sign in on the next visit.        
        /// </summary>        
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}