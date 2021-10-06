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
    public class MeasureController : Controller
    {
        private readonly ILogger<MeasureController> _logger;
        private IMeasureService _service;
        public MeasureController(ILogger<MeasureController> logger, IMeasureService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Manage()
        {
            var userId = User.GetUserId();
            var currentMeasures = _service.Get(userId);
            var vm = new MeasureViewModel
            {
                Measures = currentMeasures,
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Manage(MeasureViewModel vm)
        {
            if (!ModelState.IsValid) return View("Manage", vm);
            var userId = User.GetUserId();
            _service.Update(vm.Measures, userId);
            return RedirectToAction("Index", "Home");
        }

    }
}
