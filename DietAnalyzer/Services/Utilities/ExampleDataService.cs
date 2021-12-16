using DietAnalyzer.Data;
using DietAnalyzer.Models.Domains;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Services.Utilities
{
    /// <summary>
    /// 
    /// A standard implementation of IExampleDataService
    /// 
    /// </summary>
    public partial class ExampleDataService : IExampleDataService
    {
        private IUnitOfWork _unitOfWork;
        private IMeasureService _measureService;
        private IFoodItemService _foodService;
        private IDietService _dietService;
        private IWebHostEnvironment _webHost;
        private readonly ILogger<ExampleDataService> _logger;
        public ExampleDataService(IUnitOfWork unitOfWork, IDietService dietService,
            IFoodItemService foodService, 
            IMeasureService measureService,
            IWebHostEnvironment webHost,
            ILogger<ExampleDataService> logger)
        {
            _unitOfWork = unitOfWork;
            _foodService = foodService;
            _measureService = measureService;
            _dietService = dietService;
            _webHost = webHost;
            _logger = logger;
        }
        public async Task InsertExampleDataAsync(string userId)
        {
            await InsertExampleMeasures(userId);
            await InsertExampleFoods(userId);
            await InsertExampleDiets(userId);
        }

        private async Task InsertExampleDiets(string userId)
        {
            var dietsToAdd = new List<Diet>();
            dietsToAdd.Add(_dietService.PrepareNewDiet(userId));
            dietsToAdd.Add(_dietService.PrepareNewDiet(userId));
            dietsToAdd[0].Name = "Mediterranean diet";
            dietsToAdd[1].Name = "Chicken, cheese & chocolate";
            AddDietItems(dietsToAdd, userId);
            await _unitOfWork.Diets.AddAsync(dietsToAdd[0]);
            await _unitOfWork.Diets.AddAsync(dietsToAdd[1]);
            _unitOfWork.Save();
        }

        private async Task InsertExampleFoods(string userId)
        {
            var foodsToAdd = new List<FoodItem>();
            foodsToAdd.Add(_foodService.PrepareNewFood(userId));
            foodsToAdd.Add(_foodService.PrepareNewFood(userId));
            foodsToAdd[0].Name = "carrots";
            foodsToAdd[0].ImageFromUser = File.ReadAllBytes(_webHost.WebRootPath + "/images/example/carrot.png");
            foodsToAdd[0].Measures = _measureService.ReloadMeasures(new List<FoodMeasure>()
            {
                new FoodMeasure()
                {
                    IsCurrentlyLinked = true,
                    MeasureId = 1,
                },
                new FoodMeasure()
                {
                    IsCurrentlyLinked = false,
                    MeasureId = 2,
                },
                new FoodMeasure()
                {
                    IsCurrentlyLinked = false,
                    MeasureId = 3,
                },
                new FoodMeasure()
                {
                    IsCurrentlyLinked = false,
                    MeasureId = 4,
                },
                new FoodMeasure()
                {
                    IsCurrentlyLinked = true,
                    MeasureId = _measureService.Get(userId)
                        .Single(x => x.Name == "large carrots" && x.UserId == userId).Id,
                },
                new FoodMeasure()
                {
                    IsCurrentlyLinked = false,
                    MeasureId = _measureService.Get(userId)
                        .Single(x => x.Name == "liters" && x.UserId == userId).Id,
                },
            });
            foodsToAdd[1].Name = "orange juice";
            foodsToAdd[1].ImageFromUser = File.ReadAllBytes(_webHost.WebRootPath + "/images/example/orange_juice.png");
            foodsToAdd[1].Measures = _measureService.ReloadMeasures(new List<FoodMeasure>()
            {
                new FoodMeasure()
                {
                    IsCurrentlyLinked = true,
                    MeasureId = 1,
                },
                new FoodMeasure()
                {
                    IsCurrentlyLinked = false,
                    MeasureId = 2,
                },
                new FoodMeasure()
                {
                    IsCurrentlyLinked = false,
                    MeasureId = 3,
                },
                new FoodMeasure()
                {
                    IsCurrentlyLinked = true,
                    MeasureId = 4,
                },
                new FoodMeasure()
                {
                    IsCurrentlyLinked = false,
                    MeasureId = _measureService.Get(userId)
                        .Single(x => x.Name == "large carrots" && x.UserId == userId).Id,
                },
                new FoodMeasure()
                {
                    IsCurrentlyLinked = false,
                    MeasureId = _measureService.Get(userId)
                        .Single(x => x.Name == "liters" && x.UserId == userId).Id,
                },
            });
            AddRestrictions(foodsToAdd);
            AddNutritions(foodsToAdd);
            await _unitOfWork.Foods.AddAsync(foodsToAdd[0]);
            await _unitOfWork.Foods.AddAsync(foodsToAdd[1]);
            await _unitOfWork.NutritionFoods.AddAsync(foodsToAdd[0].Nutrition);
            await _unitOfWork.NutritionFoods.AddAsync(foodsToAdd[0].Nutrition);
            await _unitOfWork.RestrictionFoods.AddAsync(foodsToAdd[0].Restrictions);
            await _unitOfWork.RestrictionFoods.AddAsync(foodsToAdd[0].Restrictions);
            _unitOfWork.Save();
        }

        private async Task InsertExampleMeasures(string userId)
        {
            var measuresToAdd = new List<Measure>()
            {
                new Measure
                {
                    Name = "large carrots",
                    UserId = userId,
                    Grams = 70,
                },
                new Measure
                {
                    Name = "liters",
                    UserId = userId,
                    Grams = 1000,
                },
            };
            foreach (Measure measure in measuresToAdd)
            {
                await _unitOfWork.Measures.AddAsync(measure);
                _unitOfWork.Save();
                foreach (var foodItem in _unitOfWork.Foods.Get(userId))
                {
                    await _unitOfWork.FoodMeasures.AddAsync(measure.Id, foodItem.Id);
                }
            }
            _unitOfWork.Save();
        }


    }
}
