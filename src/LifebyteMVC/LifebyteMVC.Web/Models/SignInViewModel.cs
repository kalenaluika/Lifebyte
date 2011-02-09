using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.OpenId.RelyingParty;
using LifebyteMVC.Core;
using LifebyteMVC.Data.Repositories;
using System.Web;
using LifebyteMVC.Core.Model;
using System;

namespace LifebyteMVC.Web.Models
{
    public class SignInViewModel
    {
        private string returnUrl;

        /// <summary>
        /// The URL to return the volunteer to after a successful sign in.
        /// </summary>
        public string ReturnUrl
        {
            get
            {
                // Source: NerdDinner account controller
                // Make sure we only follow relative returnUrl parameters to protect against 
                // having an open redirector
                Uri returnUri;
                if (!String.IsNullOrEmpty(returnUrl)
                    && Uri.TryCreate(returnUrl, UriKind.Relative, out returnUri))
                {
                    return returnUrl;
                }

                return "/home/index";
            }
            set
            {
                returnUrl = value;
            }
        }

        /// <summary>
        /// The URL of the Open ID provider.
        /// </summary>
        [Required(ErrorMessage = "An Open ID URL is required.")]
        public string OpenIdUrl { get; set; }

        /// <summary>
        /// The response from the Open ID provider.
        /// </summary>
        public IAuthenticationResponse AuthenticationResponse { get; set; }

        /// <summary>
        /// Authenticates the volunteer using Open ID.
        /// </summary>
        /// <param name="modelState">The current ModelState dictionary.</param>
        /// <returns>The authenticated volunteer.</returns>
        public Volunteer Authenticate(ModelStateDictionary modelState)
        {
            Volunteer volunteer = null;

            // Guard against a canceled response.
            if (AuthenticationResponse.Status == AuthenticationStatus.Canceled)
            {
                modelState.AddModelError("OpenIdUrl", "The sign in was canceled.");
                return volunteer;
            }

            // Guard against a failed response.
            if (AuthenticationResponse.Status == AuthenticationStatus.Failed)
            {
                modelState.AddModelError("OpenIdUrl", AuthenticationResponse.Exception.Message);
                return volunteer;
            }

            if (AuthenticationResponse.Status == AuthenticationStatus.Authenticated)
            {
                volunteer = new VolunteerRepository()
                    .GetVolunteerByClaimedIdentifier(AuthenticationResponse.ClaimedIdentifier);

                // Guard against a new volunteer authenticating, but they are not 
                // in the database yet.
                if (volunteer == null)
                {
                    HttpContext.Current.Response.Cookies.Set(CreateCookie("New Volunteer",
                        AuthenticationResponse.ClaimedIdentifier));
                    return volunteer;
                }

                string volunteerName = MvcHtmlString.Create(volunteer.FirstName + " " + volunteer.LastName).ToHtmlString();
                HttpContext.Current.Response.Cookies.Set(CreateCookie(volunteerName.Trim(),
                    AuthenticationResponse.ClaimedIdentifier));

                return volunteer;
            }

            // TODO Log how we ended up here.
            modelState.AddModelError("OpenIdUrl", "An unknown error occurred.");
            return volunteer;
        }

        private HttpCookie CreateCookie(string name, string userData)
        {
            var cookie = FormsAuthentication.GetAuthCookie(FormsAuthentication.FormsCookieName, false);
            cookie.Value = FormsAuthentication.Encrypt(new FormsAuthenticationTicket(
                        1,
                        name,
                        DateTime.Now,
                        DateTime.Now.AddTicks(FormsAuthentication.Timeout.Ticks),
                        false,
                        userData,
                        FormsAuthentication.FormsCookiePath));
            cookie.Expires = DateTime.Now.AddTicks(FormsAuthentication.Timeout.Ticks);
            cookie.HttpOnly = true;

            return cookie;
        }
    }
}