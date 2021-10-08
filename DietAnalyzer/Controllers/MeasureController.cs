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
            var currentMeasures = _service.GetCustom(userId);
            var vm = new MeasureViewModel
            {
                Measures = currentMeasures.ToList(),
                PositionsToDelete = "",
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Manage(MeasureViewModel vm)
        {
            if(vm.PositionsToDelete != null)
            {
                vm.PositionsToDelete = vm.PositionsToDelete.Remove(vm.PositionsToDelete.Length - 1);
                var positionsToDelete = vm.PositionsToDelete.Split(',').ToList()
                    .Select(x => Convert.ToInt32(x))
                    .OrderByDescending(x => x);
                if (vm.Measures != null)
                    foreach (var position in positionsToDelete)
                    {
                        vm.Measures.RemoveAt(position);
                        ModelState["Measures[" + position + "].Name"].Errors.Clear();
                        ModelState["Measures[" + position + "].Grams"].Errors.Clear();
                        ModelState["Measures[" + position + "].Name"].ValidationState =
                            Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid;
                        ModelState["Measures[" + position + "].Grams"].ValidationState =
                            Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid;
                    }
            }
            if (!ModelState.IsValid) return View("Manage", vm);
            var userId = User.GetUserId();
            if (vm.Measures != null)
                foreach (Measure measure in vm.Measures) measure.UserId = userId;
            _service.Update(vm.Measures, userId);
            return RedirectToAction("Index", "Home");
        }


        // helper action to dynamically update measures table in the view
        // see also: https://stackoverflow.com/questions/36317362/how-to-add-an-item-to-a-list-in-a-viewmodel-using-razor-and-net-core
        public ActionResult AddNewUnit(int index, MeasureViewModel vm)
        {
            return PartialView("_NewUnitRow", index);
        }

    }
}
