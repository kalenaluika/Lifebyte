using System;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using Lifebyte.Web.Models.Core.Entities;
using Lifebyte.Web.Models.Core.Interfaces;

namespace Lifebyte.Web.Models.Services
{
    public class FormsAuthenticationService : IFormsAuthenticationService
    {
        #region IFormsAuthenticationService Members

        public void SetAuthCookie(Volunteer volunteer, bool createPersistentCookie)
        {
            FormsAuthentication.SetAuthCookie(getUserName(volunteer), createPersistentCookie);

            BakeCookie(volunteer,
                       FormsAuthentication.GetAuthCookie(FormsAuthentication.FormsCookieName, false),
                       createPersistentCookie);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }

        public Guid GetVolunteerID(IPrincipal user)
        {
            var identity = (FormsIdentity) user.Identity;
            return new Guid(identity.Ticket.UserData);
        }

        #endregion

        /// <summary>
        /// Baking the cookie involves adding the volunteer ID and encrypting it.
        /// </summary>
        /// <param name="volunteer"></param>
        /// <param name="cookie"></param>
        /// <param name="createPersistentCookie"></param>
        private void BakeCookie(Volunteer volunteer, HttpCookie cookie, bool createPersistentCookie)
        {
            cookie.Value = FormsAuthentication.Encrypt(new FormsAuthenticationTicket(
                                                           1,
                                                           getUserName(volunteer),
                                                           DateTime.Now,
                                                           DateTime.Now.AddTicks(FormsAuthentication.Timeout.Ticks),
                                                           createPersistentCookie,
                                                           volunteer.Id.ToString(),
                                                           FormsAuthentication.FormsCookiePath));
            cookie.Expires = DateTime.Now.AddTicks(FormsAuthentication.Timeout.Ticks);
            cookie.HttpOnly = true;

            HttpContext.Current.Response.Cookies.Set(cookie);
        }

        private string getUserName(Volunteer volunteer)
        {
            return string.Format("{0} {1}", volunteer.FirstName ?? "", volunteer.LastName ?? "").Trim();
        }
    }
}