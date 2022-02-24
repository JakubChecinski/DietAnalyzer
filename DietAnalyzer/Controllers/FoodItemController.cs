using DietAnalyzer.Models.Domains;
using DietAnalyzer.Models.Extensions;
using DietAnalyzer.Models.ViewModels;
using DietAnalyzer.Services;
using DietAnalyzer.Services.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DietAnalyzer.Controllers.ActionAttributes;
using System;
using System.Linq;


namespace DietAnalyzer.Controllers
{
    /// <summary>
    /// 
    /// A controller for FoodItems 
    /// 
    /// Notable methods:
    /// FoodList() - gets the list of all FoodItems belonging to the current user
    /// ManageFood(int id) - gets/posts a single FoodItem by id
    /// Delete(int id) - deletes a single FoodItem by id
    /// 
    /// </summary>
    
    [Authorize]
    public class FoodItemController : Controller
    {
        private readonly ILogger<FoodItemController> _logger;
        private IFoodItemService _service;
        private IMeasureService _measureService;
        private ImageHelper _imageHelper;
        public FoodItemController(ILogger<FoodItemController> logger,
            IFoodItemService service, IMeasureService measureService, ImageHelper imageHelper)
        {
            _logger = logger;
            _service = service;
            _measureService = measureService;
            _imageHelper = imageHelper;
        }

        [HttpGet]
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

        [HttpGet]
        public IActionResult ManageFood(int id = 0)
        {
            var userId = User.GetUserId();
            FoodItem foodToManage;
            if (id == 0) foodToManage = _service.PrepareNewFood(userId);
            else foodToManage = _service.Get(userId, id);
            var vm = new FoodItemViewModel
            {
                IsAdd = id == 0,
                HasImageProblem = false,
                HasMeasureProblem = false,
                FoodItem = foodToManage,
                AvailableMeasures = _measureService.ReloadMeasures(foodToManage.Measures.ToList()),
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ManageFood(FoodItemViewModel vm)
        {
            if (!ModelState.IsValid) return View("ManageFood", vm);
            if (vm.AvailableMeasures == null || !vm.AvailableMeasures.Any(x => x.IsCurrentlyLinked))
            {
                vm.HasMeasureProblem = true;
                return View("ManageFood", vm);
            }
            if (vm.ImageFile != null)
            {
                var formFileContent = _imageHelper.ValidateFile(vm.ImageFile, ModelState);
                if (!ModelState.IsValid)
                {
                    vm.HasImageProblem = true;
                    return View("ManageFood", vm);
                }
                else vm.FoodItem.ImageFromUser = formFileContent;
            }
            var userId = User.GetUserId();
            _service.AssignFoodItemData(vm, userId);
            if (vm.IsAdd) _service.Add(vm.FoodItem);
            else _service.Update(vm.FoodItem, userId);
            return RedirectToAction("FoodList", "FoodItem");
        }

        [HttpDelete]
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
                    " with inner exception: " + exc.InnerException);
                return Json(new
                {
                    success = false,
                });
            }
            return Json(new { success = true, redirectToUrl = Url.Action("FoodList", "FoodItem") });
        }

        [AjaxOnly]
        [HttpGet]
        public IActionResult GetDeleteConfirmMessage(int id)
        {
            var userId = User.GetUserId();
            var dietsWithThisFood = String.Empty;
            try
            {
                dietsWithThisFood = _service.GetDietsWithThisFood(id, userId);
            }
            catch (Exception exc)
            {
                _logger.LogError("Failed to verify diets connected to the food item: " + id 
                    + ". Exception: " + exc.Message + " with inner exception: " + exc.InnerException);
                return Json(new 
                { 
                    message = "Are you sure you want to delete this position?" 
                });
            }
            if (String.IsNullOrEmpty(dietsWithThisFood))
                return Json(new
                {
                    message = "Are you sure you want to delete this position?"
                });
            else
                return Json(new
                {
                    message = "Are you sure you want to delete this position? " +
                    "This food is currently used in the following diets: " + dietsWithThisFood
                });
        }

    }
}
