using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.Messaging;
using DotNetOpenAuth.OpenId;
using DotNetOpenAuth.OpenId.RelyingParty;
using LifebyteMVC.Web.Models;

// TODO Test this before release!
namespace LifebyteMVC.Web.Controllers
{
    /// <summary>
    /// We use Open ID as the way to authenticate a volunteer.
    /// </summary>
    public class AccountController : Controller
    {
        private static OpenIdRelyingParty openid = new OpenIdRelyingParty();
        
        /// <summary>
        /// This view contains the fields needed to sign into the site.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// This is the post action to the index view.
        /// This action will set session variables and make a 
        /// get call to the Authenticate action result.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(SignInViewModel model)
        {
            Session["OpenIdUrl"] = model.OpenIdUrl;
            return Redirect("Authenticate/?returnUrl=" + model.ReturnUrl);
        }

        /// <summary>
        /// This is the post from the Index view.
        /// It is also the get request from the provider.
        /// </summary>
        /// <param name="returnUrl">The URL to return the volunteer to after a 
        /// successful sign in.</param>
        /// <returns></returns>
        public ActionResult Authenticate(string returnUrl) {
            SignInViewModel model = new SignInViewModel
            {
                ReturnUrl = returnUrl
            };

            if (!ModelState.IsValid || Session["OpenIdUrl"] == null)
            {
                return View("Index", model);
            }

            model.OpenIdUrl = Session["OpenIdUrl"].ToString();

            var response = openid.GetResponse();

            if (response == null)
            {
                // Stage 2: user submitting Identifier
                Identifier id;
                if (Identifier.TryParse(model.OpenIdUrl, out id))
                {
                    try
                    {
                        return openid.CreateRequest(model.OpenIdUrl)
                            .RedirectingResponse.AsActionResult();
                    }
                    catch (ProtocolException ex)
                    {
                        ModelState.AddModelError("ProtocolException", ex.Message);
                    }
                }
                else
                {
                    ModelState.AddModelError("OpenIdUrl", "Invalid identifier");
                }
            }
            else
            {
                // Stage 3: OpenID Provider sending assertion response
                switch (response.Status)
                {
                    case AuthenticationStatus.Authenticated:
                        Session["FriendlyIdentifier"] = response.FriendlyIdentifierForDisplay;
                        FormsAuthentication.SetAuthCookie(response.ClaimedIdentifier, false);
                        if (!string.IsNullOrEmpty(model.ReturnUrl))
                        {
                            return Redirect(model.ReturnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    case AuthenticationStatus.Canceled:
                        ModelState.AddModelError("OpenIdUrl", "The sign in was canceled.");
                        break;
                    case AuthenticationStatus.Failed:
                        ModelState.AddModelError("OpenIdUrl", response.Exception.Message);
                        break;
                }
            }

            return View("Index", model);
        }
    }
}
