using DietAnalyzer.Controllers;
using DietAnalyzer.Models.Domains;
using DietAnalyzer.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietAnalyzer.UnitTests.ControllerTests
{
    /// <summary>
    /// Helper class producing objects for controller unit tests
    /// </summary>
    public static class TestObjects
    {
        public static DietViewModel GetDietViewModelForInvalidState(int foodId)
        {
            return new DietViewModel()
            {
                DietItems = new List<DietItem>
                {
                    new DietItem { Id = 1, FoodItemId = foodId }
                }
            };
        }

        public static DietViewModel GetValidDietViewModel(bool isAdd)
        {
            return new DietViewModel()
            {
                DietItems = new List<DietItem>
                {
                    new DietItem { Id = 1, FoodItemId = 1, FoodItem = new FoodItem() }
                },
                Diet = new Diet(),
                IsAdd = isAdd
            };
        }

        public static FoodItemViewModel GetValidFoodViewModel(bool hasMeasureProblem, bool isAdd = true)
        {
            return new FoodItemViewModel()
            {
                AvailableMeasures = new List<FoodMeasure>()
                {
                    new FoodMeasure() { IsCurrentlyLinked = !hasMeasureProblem }
                },
                FoodItem = new FoodItem(),
                IsAdd = isAdd,
            };
        }


    }
}
