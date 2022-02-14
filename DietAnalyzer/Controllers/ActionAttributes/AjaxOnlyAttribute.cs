using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Controllers.ActionAttributes
{

    /// <summary>
    /// An attribute for controller actions that should be only called from Ajax and not from anywhere else
    /// </summary>
    /// <remarks>
    /// This is essentially a [NonAction] attribute, but modified to allow Ajax calls
    /// </remarks>
     
    [AttributeUsage(AttributeTargets.Method)]
    public class AjaxOnlyAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            bool isAjax = filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest";
            if (!isAjax)
            {
                filterContext.Result = new BadRequestResult();
            }
            else
            {
                base.OnActionExecuting(filterContext);
            }
        }
    }
}
