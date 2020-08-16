using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    public class OAuthController : Controller
    {
        [HttpPost]
        public IActionResult Authorize(
            string response_type, // authorization flow type
            string client_id,     // client id
            string redirect_uri,
            string scope,         // what info I want = email, grandma, tel
            string state)         // random string gernerated to ensure we are going back to the same client
        {
            // ?a=foo&b=bar
            var query = new QueryBuilder();
            query.Add("redirectUri", redirect_uri);
            query.Add("state", state);

            return View(model: query.ToString());
        }

        [HttpPost]
        public IActionResult Authorize(
            string username, 
            string redirect_uri,
            string state)
        {
            const string code = "BABABABABBABABAB";

            return Redirect($"{redirect_uri}");
        }

        [HttpPost]
        public IActionResult Token()
        {
            return View();
        }
    }
}