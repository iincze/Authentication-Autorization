using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MeloManager.Controllers
{
    public class ErrorController : Controller
    {
        // If there is 404 status code, the route path will become Error/404
        //[Route("Error/{statusCode}")]
        //public IActionResult HttpStatusCodeHandler(int statusCode)
        //{
        //    switch (statusCode)
        //    {
        //        case 404:
        //            ViewBag.ErrorMessage = "Sorry, the resource you requested could not be found";
        //            break;
        //        case 500:
        //            ViewBag.ErrorMessage = "Sorry";
        //            break;
        //    }

        //    return View("NotFound");
        //}

        //[Route("Error/{statusCode}")]
        public IActionResult Error(int? statusCode = null)
        {
            if (statusCode.HasValue)
            {
                if (statusCode == 404 || statusCode == 500)
                {
                    var viewName = statusCode.ToString();
                    return View("NotFound");
                }
            }
            return View("NotFound");
            //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}