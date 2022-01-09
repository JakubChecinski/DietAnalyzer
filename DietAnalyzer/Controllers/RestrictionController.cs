using DietAnalyzer.Models.Domains;
using DietAnalyzer.Models.Extensions;
using DietAnalyzer.Models.ViewModels;
using DietAnalyzer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Controllers
{
    /// <summary>
    /// 
    /// A controller for Restrictions
    /// 
    /// Notable methods:
    /// Manage() - gets/posts the table of Restrictions belonging to the current user
    /// 
    /// </summary>
    public class RestrictionController : Controller
    {
        private readonly ILogger<RestrictionController> _logger;
        private IRestrictionService _service;
        public RestrictionController(ILogger<RestrictionController> logger, IRestrictionService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Manage()
        {
            var userId = User.GetUserId();
            var currentRestrictions = _service.Get(userId);
            var vm = new RestrictionViewModel
            {
                RestrictionInfo = currentRestrictions,
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Manage(RestrictionViewModel vm)
        {
            if (!ModelState.IsValid) return View("Manage", vm);
            _service.Update(vm.RestrictionInfo);
            return RedirectToAction("DietList", "Diet");
        }

    }
}
