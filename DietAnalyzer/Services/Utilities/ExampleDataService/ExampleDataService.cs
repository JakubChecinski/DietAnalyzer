using DietAnalyzer.Data;
using DietAnalyzer.Models.Domains;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Services.Utilities
{
    /// <summary>
    /// 
    /// A standard implementation of IExampleDataService
    /// See also Data -> DataSeeder for more discussion
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

        List<Diet> dietsToAdd;
        List<FoodItem> foodsToAdd;
        List<Measure> measuresToAdd;

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

        public void InsertExampleData(string userId)
        {
            InsertExampleMeasures(userId);
            InsertExampleFoods(userId);
            InsertExampleDiets(userId);
        }
        public async Task InsertExampleDataAsync(string userId)
        {
            await InsertExampleMeasuresAsync(userId);
            await InsertExampleFoodsAsync(userId);
            await InsertExampleDietsAsync(userId);
        }
        

        // sync versions
        private void InsertExampleDiets(string userId)
        {
            PrepareDietData(userId);
            _unitOfWork.Diets.Add(dietsToAdd[0]);
            _unitOfWork.Diets.Add(dietsToAdd[1]);
            _unitOfWork.Save();
        }
        private void InsertExampleFoods(string userId)
        {
            PrepareFoodData(userId);
            _unitOfWork.Foods.Add(foodsToAdd[0]);
            _unitOfWork.Foods.Add(foodsToAdd[1]);
            _unitOfWork.NutritionFoods.Add(foodsToAdd[0].Nutrition);
            _unitOfWork.NutritionFoods.Add(foodsToAdd[0].Nutrition);
            _unitOfWork.RestrictionFoods.Add(foodsToAdd[0].Restrictions);
            _unitOfWork.RestrictionFoods.Add(foodsToAdd[0].Restrictions);
            _unitOfWork.Save();
        }
        private void InsertExampleMeasures(string userId)
        {
            PrepareMeasureData(userId);
            foreach (Measure measure in measuresToAdd)
            {
                _unitOfWork.Measures.AddAsync(measure);
                _unitOfWork.Save();
                foreach (var foodItem in _unitOfWork.Foods.Get(userId))
                {
                    _unitOfWork.FoodMeasures.AddAsync(measure.Id, foodItem.Id);
                }
            }
            _unitOfWork.Save();
        }


        // async versions
        private async Task InsertExampleDietsAsync(string userId)
        {
            PrepareDietData(userId);
            await _unitOfWork.Diets.AddAsync(dietsToAdd[0]);
            await _unitOfWork.Diets.AddAsync(dietsToAdd[1]);
            _unitOfWork.Save();
        }
        private async Task InsertExampleFoodsAsync(string userId)
        {
            PrepareFoodData(userId);
            await _unitOfWork.Foods.AddAsync(foodsToAdd[0]);
            await _unitOfWork.Foods.AddAsync(foodsToAdd[1]);
            await _unitOfWork.NutritionFoods.AddAsync(foodsToAdd[0].Nutrition);
            await _unitOfWork.NutritionFoods.AddAsync(foodsToAdd[0].Nutrition);
            await _unitOfWork.RestrictionFoods.AddAsync(foodsToAdd[0].Restrictions);
            await _unitOfWork.RestrictionFoods.AddAsync(foodsToAdd[0].Restrictions);
            _unitOfWork.Save();
        }
        private async Task InsertExampleMeasuresAsync(string userId)
        {
            PrepareMeasureData(userId);
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
