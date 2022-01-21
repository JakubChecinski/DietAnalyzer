using DietAnalyzer.Controllers;
using DietAnalyzer.Models.Domains;
using DietAnalyzer.Models.ViewModels;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DietAnalyzer.IntegrationTests.CrossDomain
{
    class FoodAndMeasureTests : IntegrationTests
    {
        private FoodItemController foodController;
        private MeasureController measureController;
        private List<Measure> measures;
        private void Init()
        {
            foodController = controllerFactory.GetFoodController();
            measureController = controllerFactory.GetMeasureController();
            measures = measureService.GetCustom(userId).ToList();
        }

        [Test]
        public void NewMeasureAdded_ShowOnManageNewFoodPage()
        {
            Init();
            var measureToAdd = new Measure { Name = "abc" };
            measures.Add(measureToAdd);

            measureController.Manage(new MeasureViewModel() { Measures = measures });
            var result = foodController.ManageFood(0) as ViewResult;

            var foodReturnedToUser = (result.Model as FoodItemViewModel).FoodItem;
            foodReturnedToUser.Measures.Where(x => x.Measure.Name == "abc").Count().Should().Be(1);
            foodReturnedToUser.Measures.Single(x => x.Measure.Name == "abc")
                .IsCurrentlyLinked.Should().BeFalse();
        }

        [Test]
        public void NewMeasureAdded_ShowOnManageExistingFoodPage()
        {
            Init();
            var measureToAdd = new Measure { Name = "abc" };
            measures.Add(measureToAdd);

            measureController.Manage(new MeasureViewModel() { Measures = measures });
            var result = foodController.ManageFood(carrotId) as ViewResult;

            var foodReturnedToUser = (result.Model as FoodItemViewModel).FoodItem;
            foodReturnedToUser.Measures.Where(x => x.Measure.Name == "abc").Count().Should().Be(1);
            foodReturnedToUser.Measures.Single(x => x.Measure.Name == "abc")
                .IsCurrentlyLinked.Should().BeFalse();
        }

        [Test]
        public void MeasureDeleted_DontShowOnManageNewFoodPage()
        {
            Init();
            var measureToDelete = measures.Where(x => x.Name == "liters").First();
            measures.Remove(measureToDelete);

            measureController.Manage(new MeasureViewModel() { Measures = measures });
            var result = foodController.ManageFood(0) as ViewResult;

            var foodReturnedToUser = (result.Model as FoodItemViewModel).FoodItem;
            foodReturnedToUser.Measures.Where(x => x.Measure.Name == "liters").Count().Should().Be(0);
        }

        [Test]
        public void MeasureDeleted_DontShowOnManageExistingFoodPage()
        {
            Init();
            var measureToDelete = measures.Where(x => x.Name == "liters").First();
            measures.Remove(measureToDelete);

            measureController.Manage(new MeasureViewModel() { Measures = measures });
            var result = foodController.ManageFood(carrotId) as ViewResult;

            var foodReturnedToUser = (result.Model as FoodItemViewModel).FoodItem;
            foodReturnedToUser.Measures.Where(x => x.Measure.Name == "liters").Count().Should().Be(0);
        }

        [Test]
        public void MeasureDeleted_SpecialCaseIfFoodWasPreviouslyLinked()
        {
            Init();
            // juice is linked with liters
            var juiceId = context.FoodItems.Single(x => x.Name.Contains("juice")).Id;
            var measureToDelete = measures.Where(x => x.Name == "liters").First();
            measures.Remove(measureToDelete);

            measureController.Manage(new MeasureViewModel() { Measures = measures });
            var result = foodController.ManageFood(juiceId) as ViewResult;

            var foodReturnedToUser = (result.Model as FoodItemViewModel).FoodItem;
            foodReturnedToUser.Measures.Where(x => x.Measure.Name == "liters").Count().Should().Be(0);
        }

    }
}
