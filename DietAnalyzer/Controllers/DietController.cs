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
    public class DietController : Controller
    {
        private readonly ILogger<DietController> _logger;
        private IDietService _service;
        private IFoodItemService _foodService;
        public DietController(ILogger<DietController> logger, 
            IDietService service, IFoodItemService foodService)
        {
            _logger = logger;
            _service = service;
            _foodService = foodService;
        }

        // actions for the entire diet list
        [HttpGet]
        [Authorize]
        public IActionResult DietList()
        {
            var userId = User.GetUserId();
            var currentDiets = _service.Get(userId);
            var vm = new DietListViewModel
            {
                Diets = currentDiets,
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var userId = User.GetUserId();
            try
            {
                _service.Delete(id, userId);
            }
            catch (Exception exc)
            {
                // logowanie
                return Json(new
                {
                    success = false,
                    message = exc.Message
                });
            }
            return Json(new { success = true, redirectToUrl = Url.Action("DietList", "Diet") });
        }

        // actions for individual diet items
        [HttpGet]
        [Authorize]
        public IActionResult ManageDiet(int id = 0)
        {
            var userId = User.GetUserId();
            Diet dietToManage;
            if (id == 0)
            {
                dietToManage = new Diet
                {
                    Name = "",
                    UserId = userId,
                    Nutritions = new NutritionInfo(),
                };
                dietToManage.Nutritions.Diet = dietToManage;
            }
            else dietToManage = _service.Get(userId, id);
            var vm = new DietViewModel
            {
                IsAdd = id == 0,
                Diet = dietToManage,
                AvailableFoods = _foodService.Get(userId),
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ManageDiet(DietViewModel vm)
        {
            if (!ModelState.IsValid) return View("ManageDiet", vm);
            var userId = User.GetUserId();
            if (vm.IsAdd) _service.Add(vm.Diet);
            else _service.Update(vm.Diet, userId);
            return RedirectToAction("DietList", "Diet");
        }

    }
}
