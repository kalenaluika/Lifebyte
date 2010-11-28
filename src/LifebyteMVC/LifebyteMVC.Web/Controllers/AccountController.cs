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
        /// <summary>
        /// This view contains the fields needed to sign into the site.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(new SignInViewModel());
        }

        /// <summary>
        /// This is the post action to the index view.
        /// This action will validate the model and redirect to the Authenticate action result 
        /// passing in the query string parameters.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(SignInViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return Redirect(string.Format("/Account/Authenticate/?returnUrl={0}&openIdUrl={1}",
                model.ReturnUrl, model.OpenIdUrl));
        }

        /// <summary>
        /// This is the post from the Index view.
        /// It is also the get request from the provider.
        /// </summary>
        /// <param name="returnUrl">The URL to return the volunteer to after a 
        /// successful sign in.</param>
        /// <returns></returns>
        public ActionResult Authenticate(string returnUrl, string openIdUrl)
        {
            SignInViewModel model = new SignInViewModel
            {
                ReturnUrl = returnUrl
            };

            OpenIdRelyingParty openid = new OpenIdRelyingParty();

            var response = openid.GetResponse();

            if (response == null)
            {
                model.OpenIdUrl = openIdUrl;                

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
                    ModelState.AddModelError("OpenIdUrl", "Invalid Open ID URL");
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

        /// <summary>
        /// Signs out the volunteer and redirects back to the home page.
        /// </summary>
        /// <returns></returns>
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}
