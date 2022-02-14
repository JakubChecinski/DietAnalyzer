using DietAnalyzer.Models.Domains;
using DietAnalyzer.Models.Extensions;
using DietAnalyzer.Models.ViewModels;
using DietAnalyzer.Services;
using DietAnalyzer.Services.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace DietAnalyzer.Controllers
{
    /// <summary>
    /// 
    /// A controller for Diets 
    /// 
    /// Notable methods:
    /// DietList() - gets the list of all Diets belonging to the current user
    /// ManageDiet(int id) - gets/posts a single Diet by id
    /// Delete(int id) - deletes a single Diet by id
    /// Evaluate(int id) - calls IEvaluationService to evaluate a single diet by id
    /// 
    /// </summary>
    public class DietController : Controller
    {
        private readonly ILogger<DietController> _logger;
        private IDietService _service;
        private IFoodItemService _foodService;
        private IEvaluationService _evaluationService;

        public DietController(ILogger<DietController> logger,
            IDietService service, IFoodItemService foodService,
            IEvaluationService evaluationService)
        {
            _logger = logger;
            _service = service;
            _foodService = foodService;
            _evaluationService = evaluationService;
        }


        [HttpGet]
        [Authorize]
        public IActionResult DietList()
        {
            var userId = User.GetUserId();
            var vm = new DietListViewModel
            {
                Diets = _service.Get(userId),
                IncompatibleDietIds = _service.GetIncompatibleDietIds(userId),
            };
            return View(vm);
        }

        [HttpGet]
        [Authorize]
        public IActionResult ManageDiet(int id = 0)
        {
            var userId = User.GetUserId();
            Diet dietToManage;
            if (id == 0) dietToManage = _service.PrepareNewDiet(userId);
            else dietToManage = _service.Get(userId, id);
            var vm = new DietViewModel
            {
                IsAdd = id == 0,
                NoFoodsOnList = id == 0, // the same starting condition, but will be handled differently later
                SomeDietItemsAreRestricted = false,
                Diet = dietToManage,
                DietItems = dietToManage.DietItems.ToList(),
                AvailableFoods = _foodService.Get(userId, true).ToList(),
                AvailableMeasuresForEachFood =
                    _foodService.PrepareMeasuresForFoods(userId, dietToManage.DietItems),
                CurrentFoodId = 0,
            };
            vm.AvailableFoodIds = vm.AvailableFoods.Select(x => x.Id).ToList();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ManageDiet(DietViewModel vm)
        {
            if (vm.DietItems == null) return RedirectToAction("DietList", "Diet");
            var userId = User.GetUserId();
            if (!ModelState.IsValid)
            {
                vm.AvailableMeasuresForEachFood =
                    _foodService.PrepareMeasuresForFoods(userId, vm.DietItems);
                vm.AvailableFoodIds = _foodService.Get(userId, true).Select(x => x.Id).ToList();
                foreach (var dietItem in vm.DietItems)
                    dietItem.FoodItem = _foodService.Get(userId, dietItem.FoodItemId);
                return View("ManageDiet", vm);
            }
            _service.AssignDietItems(vm);
            if (vm.IsAdd) _service.Add(vm.Diet);
            else _service.Update(vm.Diet, userId);
            return RedirectToAction("DietList", "Diet");
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

        public ActionResult Evaluate(int id)
        {
            var userId = User.GetUserId();
            var dietToEvaluate = _service.GetWithDietItemChildren(userId, id);
            try
            {
                if (dietToEvaluate == null)
                    throw new ArgumentException("Diet with this id does not exist. Id: " + id);
                dietToEvaluate.Nutritions = _evaluationService.GetNutritions(dietToEvaluate);
                dietToEvaluate.Summary = _evaluationService.GetSummary(dietToEvaluate);
                _service.Update(dietToEvaluate, userId, false);
            }
            catch(Exception e)
            {
                _logger.LogError("Error in Evaluate: " + e.Message);
                var contentResult = new ContentResult
                {
                    Content = "Our server may be overloaded. Please try again."
                };
                return contentResult;
            }
            return PartialView("_DietSummary", dietToEvaluate);
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
                FoodItemImageUrl = _foodService.Get(userId, foodId).GetImageSrc(),
                AvailableMeasuresForThisFood = _foodService.PrepareMeasuresForFood(userId, foodId),
            };
            return PartialView("_NewDietItemRow", vm);
        }

    }
}
