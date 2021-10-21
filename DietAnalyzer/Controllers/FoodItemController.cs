using DietAnalyzer.Models.Domains;
using DietAnalyzer.Models.Extensions;
using DietAnalyzer.Models.ViewModels;
using DietAnalyzer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            var currentFoods = _service.GetCustom(userId);
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
                _logger.LogError("Failed to delete food item: " + exc.Message +
                    "with inner exception: " + exc.InnerException);
                return Json(new
                {
                    success = false,
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
                    Nutrition = new NutritionFood(),
                    Restrictions = new RestrictionFood(),
                };
                foodToManage.Nutrition.FoodItem = foodToManage;
                foodToManage.Restrictions.FoodItem = foodToManage;
                var availableMeasures = _measureService.Get(userId);
                foreach (Measure measure in availableMeasures)
                {
                    foodToManage.Measures.Add(new FoodMeasure
                    {
                        IsCurrentlyLinked = false,
                        FoodItemId = 0,
                        Measure = measure,
                        MeasureId = measure.Id,
                    });
                }
            }
            else foodToManage = _service.Get(userId, id);
            var vm = new FoodItemViewModel
            {
                IsAdd = id == 0,
                FoodItem = foodToManage,
                AvailableMeasures = ReloadMeasures(foodToManage.Measures.ToList()),
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ManageFood(FoodItemViewModel vm)
        {
            if (!ModelState.IsValid) return View("ManageFood", vm);
            var userId = User.GetUserId();
            vm.FoodItem.UserId = userId; 
            vm.FoodItem.Measures = ReloadMeasures(vm.AvailableMeasures.ToList());
            if (vm.IsAdd) _service.Add(vm.FoodItem);
            else _service.Update(vm.FoodItem, userId);
            return RedirectToAction("FoodList", "FoodItem");
        }

        private List<FoodMeasure> ReloadMeasures(List<FoodMeasure> foodMeasures)
        {
            // I was hoping Entity would do this automatically, but apparently it doesn't
            // Maybe it's because I added a new field to the join FoodMeasure class?
            for (int i = 0; i < foodMeasures.Count; i++)
            {
                foodMeasures[i].Measure = _measureService.Get(foodMeasures[i].MeasureId);
            }
            return foodMeasures;
        }

    }
}
