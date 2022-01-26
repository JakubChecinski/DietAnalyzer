using DietAnalyzer.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace DietAnalyzer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return RedirectToAction("DietList", "Diet");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            try
            {
                var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
                if (exceptionFeature != null)
                {
                    string routeWhereExceptionOccurred = exceptionFeature.Path;
                    Exception exceptionThatOccurred = exceptionFeature.Error;
                    _logger.LogError(100, "Global error handler caught an exception: " + exceptionThatOccurred
                    + " path: " + routeWhereExceptionOccurred);
                }
            }
            catch (Exception exc)
            {
                try
                {
                    _logger.LogError("ShowError exception caught: " + exc.Message);
                }
                finally
                {
                    // something went really wrong and we can't even access the logger
                    // so we have to die in silence
                }
            }
            return RedirectToAction("ShowError", new { message = "Please see logs for more info" });
        }

        /*
            For some reason, the line:
            return View("Error", new ErrorViewModel() { ExceptionMessage = message });
            doesn't work when I put it in the Error() action. All I get is a blank page and "An exception 
            was thrown attempting to execute the error handler" in logs (no further explanation and no exception
            details, just the request ID). Debug confirms that the problem is caused by the View call and not by
            anything else in Error(), but again offers no further clues.
       
            I spent a long time trying to trace the root of the issue and I still don't know what it is. 
            Google/Stack Overflow seem to have barely heard about it and only suggest meaningless corrections 
            like adding [AllowAnonymous] to the Error action (tried it, doesn't change anything). Perhaps 
            I wasn't asking them the right questions.
        
            In any case, I was able to discover that simply wrapping the View call in another action and 
            redirecting to it fixes the issue. I still don't know why, but I'm leaving this here as a workaround.
        */
        public IActionResult ShowError(string message)
        {
            return View("Error", new ErrorViewModel() { ExceptionMessage = message });
        }

    }
}
