using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using FluentAssertions;
using Moq;
using DietAnalyzer.Controllers;
using DietAnalyzer.Models.Domains;
using DietAnalyzer.Models.ViewModels;
using DietAnalyzer.Services;
using DietAnalyzer.UnitTests.Extensions;
using Microsoft.AspNetCore.Mvc;
using DietAnalyzer.Services.Utilities;

namespace DietAnalyzer.IntegrationTests.CrossDomain
{
    class DietAndFoodTests : IntegrationTests
    {
        private DietController dietController;
        private FoodItemController foodController;
        public void Init()
        {
            dietController = controllerFactory.GetDietController();
            foodController = controllerFactory.GetFoodController();
        }

        [Test]
        public void NewFoddAdded_ShowOnNewDietPage()
        {
            Init();
            var viewModel = ((foodController.ManageFood(0) as ViewResult).Model as FoodItemViewModel);
            viewModel.FoodItem.Name = "abc";

            foodController.ManageFood(viewModel);
            var result = dietController.ManageDiet(0) as ViewResult;

            var foodsShownToUser = (result.Model as DietViewModel).AvailableFoods;
            foodsShownToUser.Where(x => x.Name == "abc").Should().HaveCount(1);
        }

        [Test]
        public void NewFoddAdded_ShowOnExistingDietPage()
        {
            Init();
            var viewModel = ((foodController.ManageFood(0) as ViewResult).Model as FoodItemViewModel);
            viewModel.FoodItem.Name = "abc";

            foodController.ManageFood(viewModel);
            var result = dietController.ManageDiet(chocolateDietId) as ViewResult;

            var foodsShownToUser = (result.Model as DietViewModel).AvailableFoods;
            foodsShownToUser.Where(x => x.Name == "abc").Should().HaveCount(1);
        }

        [Test]
        public void FoodDeleted_DontShowOnNewDietPage()
        {
            Init();

            foodController.Delete(carrotId);
            var result = dietController.ManageDiet(0) as ViewResult;

            var foodsShownToUser = (result.Model as DietViewModel).AvailableFoods;
            foodsShownToUser.Where(x => x.Name.Contains("carrot")).Should().HaveCount(0);
        }

        [Test]
        public void FoodDeleted_DontShowOnExistingDietPage()
        {
            Init();

            foodController.Delete(carrotId);
            var result = dietController.ManageDiet(chocolateDietId) as ViewResult;

            var foodsShownToUser = (result.Model as DietViewModel).AvailableFoods;
            foodsShownToUser.Where(x => x.Name.Contains("carrot")).Should().HaveCount(0);
        }

        [Test]
        public void FoodDeleted_SpecialCaseIfFoodWasUsedInAnExistingDiet()
        {
            // note: we can't use chocolate here, because it's library food that can't be deleted normally
            Init();

            foodController.Delete(orangeJuiceId);
            var result = dietController.ManageDiet(medDietId) as ViewResult;

            var dietItems = (result.Model as DietViewModel).DietItems;
            dietItems.Where(x => x.FoodItemId == orangeJuiceId).Should().HaveCount(0);
        }

        [Test]
        public void EvaluatedNutrientLow_SuggestThreeBestFoodsFromDatabase()
        {
            Init();

            var result = (dietController.Evaluate(chocolateDietId) as PartialViewResult).Model as Diet;

            var lowNutrient = result.Summary.Single(x => x.NutrientName == "Vitamin A");
            if (lowNutrient.Level != Level.Low)
                throw new Exception("Test assumptions failed! Please check low nutrients for this diet again.");
            var bestFoods = foodService.Get(userId, true)
                .OrderByDescending(x => x.Nutrition.VitaminAPer100g).Take(3);
            foreach (var bestFood in bestFoods)
            {
                lowNutrient.Suggestions.Should().Contain(bestFood.Name);
            }
        }

        [Test]
        public void EvaluatedNutrientHigh_SuggestThreeWorstFoodsToRemoveFromDiet()
        {
            Init();

            var result = (dietController.Evaluate(chocolateDietId) as PartialViewResult).Model as Diet;

            var highNutrient = result.Summary.Single(x => x.NutrientName == "Sodium");
            if (highNutrient.Level != Level.High)
                throw new Exception("Test assumptions failed! Please check high nutrients for this diet again.");
            var worstFoods = result.DietItems
                .OrderByDescending(x => x.FoodItem.Nutrition.SodiumPer100g).Take(3);
            foreach (var worstFood in worstFoods)
            {
                highNutrient.Suggestions.Should().Contain(worstFood.FoodItem.Name);
            }
        }

    }
}
