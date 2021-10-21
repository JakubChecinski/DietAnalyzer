using DietAnalyzer.Models.Domains;
using DietAnalyzer.Models.Extensions;
using DietAnalyzer.Models.ViewModels;
using DietAnalyzer.Services;
using DietAnalyzer.Services.Utilities;
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
        private IEvaluationService _evaluationService;
        public DietController(ILogger<DietController> logger, 
            IDietService service, IFoodItemService foodService, IEvaluationService evaluationService)
        {
            _logger = logger;
            _service = service;
            _foodService = foodService;
            _evaluationService = evaluationService;
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
                _logger.LogError("Failed to delete diet: " + exc.Message + 
                    "with inner exception: " + exc.InnerException);
                return Json(new
                {
                    success = false,
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
                    Nutritions = new NutritionDiet(),
                };
                dietToManage.Nutritions.Diet = dietToManage;
            }
            else dietToManage = _service.Get(userId, id);
            var vm = new DietViewModel
            {
                IsAdd = id == 0,
                Diet = dietToManage,
                DietItems = dietToManage.DietItems.ToList(),
                AvailableFoods = _foodService.Get(userId, true).ToList(),
                AvailableMeasuresForEachFood = PrepareAvailableMeasures(dietToManage.DietItems),
                CurrentFoodId = 0,
            };
            return View(vm);
        }
        private List<List<Tuple<int, string>>> PrepareAvailableMeasures(ICollection<DietItem> fromDietItems)
        {
            var availableMeasures = new List<List<Tuple<int, string>>>();
            for (int i = 0; i < fromDietItems.Count; i++)
            {
                availableMeasures.Add(PrepareAvailableMeasuresForFood
                    (fromDietItems.ElementAt(i).FoodItemId));
            }
            return availableMeasures;
        }
        private List<Tuple<int, string>> PrepareAvailableMeasuresForFood(int foodId)
        {
            var availableMeasures = new List<Tuple<int, string>>();
            var userId = User.GetUserId();
            var currentFood = _foodService.Get(userId, foodId);
            foreach (var measure in currentFood.Measures)
            {
                if (measure.IsCurrentlyLinked)
                    availableMeasures.Add
                        (new Tuple<int, string>(measure.MeasureId, measure.Measure.Name));
            }
            return availableMeasures;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ManageDiet(DietViewModel vm)
        {
            if(vm.DietItems == null) return RedirectToAction("DietList", "Diet");
            if (!ModelState.IsValid)
            {
                vm.AvailableMeasuresForEachFood = PrepareAvailableMeasures(vm.DietItems);
                return View("ManageDiet", vm);
            }
            foreach (var dietItem in vm.DietItems) dietItem.FoodItem = null;
            vm.Diet.DietItems = vm.DietItems;
            var userId = User.GetUserId();
            if (vm.IsAdd) _service.Add(vm.Diet);
            else _service.Update(vm.Diet, userId);
            return RedirectToAction("DietList", "Diet");
        }

        // helper action to dynamically update table in the view
        // see also: https://stackoverflow.com/questions/36317362/how-to-add-an-item-to-a-list-in-a-viewmodel-using-razor-and-net-core
        public ActionResult AddNewPosition(int index, int dietId, int foodId)
        {
            var userId = User.GetUserId();
            var vm = new DietItemRowViewModel
            {
                Index = index,
                DietId = dietId,
                FoodItemId = foodId,
                FoodItemName = _foodService.Get(userId, foodId).Name,
                AvailableMeasuresForThisFood = PrepareAvailableMeasuresForFood(foodId),
            };
            return PartialView("_NewDietItemRow", vm);
        }

        public ActionResult Evaluate(int id)
        {
            var userId = User.GetUserId();
            var dietToEvaluate = _service.GetWithDietItemChildren(userId, id);
            dietToEvaluate.Nutritions = _evaluationService.GetNutritions(dietToEvaluate);
            dietToEvaluate.Summary = _evaluationService.GetSummary(dietToEvaluate);
            _service.Update(dietToEvaluate, userId, false);
            return PartialView("_DietSummary", dietToEvaluate);
        }

    }
}
