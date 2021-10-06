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
    public class FoodItemController : Controller
    {
        private readonly ILogger<FoodItemController> _logger;
        private IFoodItemService _service;
        private IMeasureService _measureService;
        public FoodItemController(ILogger<FoodItemController> logger, 
            IFoodItemService service, IMeasureService measureService)
        {
            _logger = logger;
            _service = service;
            _measureService = measureService;
        }

        // actions for the entire food list
        [HttpGet]
        [Authorize]
        public IActionResult FoodList()
        {
            var userId = User.GetUserId();
            var currentFoods = _service.Get(userId);
            var vm = new FoodListViewModel
            {
                Foods = currentFoods,
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
            return Json(new { success = true, redirectToUrl = Url.Action("FoodList", "FoodItem") });
        }


        // actions for individual food items
        [HttpGet]
        [Authorize]
        public IActionResult ManageFood(int id = 0)
        {
            var userId = User.GetUserId();
            FoodItem foodToManage;
            if (id == 0)
            {
                foodToManage = new FoodItem
                {
                    Name = "",
                    UserId = userId,
                    Nutrition = new NutritionInfo(),
                    Restrictions = new RestrictionsInfo(),
                };
                foodToManage.Nutrition.FoodItem = foodToManage;
                foodToManage.Restrictions.FoodItem = foodToManage;
            }
            else foodToManage = _service.Get(userId, id);
            var availableMeasures = _measureService.Get(userId);
            var availableMeasuresJoinTableClass = new List<FoodMeasure>(
                availableMeasures.Select(x => new FoodMeasure
                {
                    FoodItem = foodToManage,
                    FoodItemId = foodToManage.Id,
                    Measure = x,
                    MeasureId = x.Id,
                }));
            var vm = new FoodItemViewModel
            {
                IsAdd = id == 0,
                FoodItem = foodToManage,
                AvailableMeasures = availableMeasuresJoinTableClass,
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ManageFood(FoodItemViewModel vm)
        {
            if (!ModelState.IsValid) return View("ManageFood", vm);
            var userId = User.GetUserId();
            if(vm.IsAdd) _service.Add(vm.FoodItem);
            else _service.Update(vm.FoodItem, userId);
            return RedirectToAction("FoodList", "FoodItem");
        }

    }
}
