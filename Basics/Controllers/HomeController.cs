using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

namespace Basics.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }

        [Authorize(Policy = "Claim.DoB")]
        public IActionResult SecretPolicy()
        {
            return View("Secret");
        }

        public IActionResult Authenticate()
        {
            var grandmaClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "Pistike"),
                new Claim(ClaimTypes.Email, "SolenzaBigDaddy@gmail.com"),
                new Claim(ClaimTypes.DateOfBirth, "11/11/2000"),
                new Claim("Grandma.Says", "Pistike is the best")
            };

            var licenseClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "Incze Pisti"),
                new Claim("DrivingLicense", "A,B")
            };

            var grandmaIdentity = new ClaimsIdentity(grandmaClaims, "Grandma Identity");
            var licensIdentity = new ClaimsIdentity(licenseClaims, "License Identity");

            var userPrincipal = new ClaimsPrincipal(new[] { grandmaIdentity, licensIdentity });

            /************************************************************************/

            HttpContext.SignInAsync(userPrincipal);

            return RedirectToAction("Index");
        }
    }
}
