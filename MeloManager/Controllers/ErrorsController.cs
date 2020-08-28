using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MeloManager.Controllers
{
    public class ErrorsController : Controller
    {
        private readonly ILogger<ErrorsController> _logger;


        public ErrorsController(ILogger<ErrorsController> logger)
        {
            _logger = logger;
        }


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
            var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

            if (statusCode.HasValue)
            {
                if (statusCode == 404 || statusCode == 500)
                {
                   // var viewName = statusCode.ToString();
                   // return View("SharedError");

                    _logger.LogWarning($"404 error occured. Path = " +
                                        $"{statusCodeResult.OriginalPath} and QueryString = " +
                                        $"{statusCodeResult.OriginalQueryString}");
                }
            }
            return View("SharedError");
            //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [AllowAnonymous]
        public IActionResult Exception()
        {
            // Retrieve the exception Details
            var exceptionHandlerPathFeature =
                    HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            // LogError() method logs the exception under Error category in the log
            _logger.LogError($"The path {exceptionHandlerPathFeature.Path} " +
                $"threw an exception {exceptionHandlerPathFeature.Error}");

            //ViewBag.ExceptionPath = exceptionHandlerPathFeature.Path;
            //ViewBag.ExceptionMessage = exceptionHandlerPathFeature.Error.Message;
            //ViewBag.StackTrace = exceptionHandlerPathFeature.Error.StackTrace;

            return View("Exception");
        }
    }
}