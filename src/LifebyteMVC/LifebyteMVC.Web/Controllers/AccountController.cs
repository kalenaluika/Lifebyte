using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using DotNetOpenAuth.OpenId.RelyingParty;
using DotNetOpenAuth.OpenId;
using DotNetOpenAuth.Messaging;
using System.Web.Security;

namespace LifebyteMVC.Web.Controllers
{
    public class AccountController : Controller
    {
        private static OpenIdRelyingParty openid = new OpenIdRelyingParty();

        public ActionResult LogOn()
        {
            return View();
        }

        public ActionResult Index()
        {
            return RedirectToAction("LogOn");
        }

        public ActionResult Authenticate(string returnUrl) {
			var response = openid.GetResponse();

            if (response == null)
            {
                // Stage 2: user submitting Identifier
                Identifier id;
                if (Identifier.TryParse(Request.Form["openid_identifier"], out id))
                {
                    try
                    {
                        return openid.CreateRequest(Request.Form["openid_identifier"]).RedirectingResponse.AsActionResult();
                    }
                    catch (ProtocolException ex)
                    {
                        ViewData["Message"] = ex.Message;
                        return View("LogOn");
                    }
                }
                else
                {
                    ViewData["Message"] = "Invalid identifier";
                    return View("LogOn");
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
                        if (!string.IsNullOrEmpty(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    case AuthenticationStatus.Canceled:
                        ViewData["Message"] = "Canceled at provider";
                        return View("LogOn");
                    case AuthenticationStatus.Failed:
                        ViewData["Message"] = response.Exception.Message;
                        return View("LogOn");
                }
            }
            return new EmptyResult();
        }
    }
}
