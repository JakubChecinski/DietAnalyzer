using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DietAnalyzer.Models.Extensions
{
    /// <summary>
    /// Convenience class for obtaining the userId
    /// </summary>
    public static class ClaimsExtensions
    {
        public static string GetUserId(this ClaimsPrincipal model)
        {
            return model.FindFirstValue(ClaimTypes.NameIdentifier);
        }

    }
}
