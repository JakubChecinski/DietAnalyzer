using DietAnalyzer.Models.Domains;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Services.Utilities
{
    public partial class ExampleDataService
    {
        private void PrepareDietData(string userId)
        {
            dietsToAdd = new List<Diet>();
            dietsToAdd.Add(_dietService.PrepareNewDiet(userId));
            dietsToAdd.Add(_dietService.PrepareNewDiet(userId));
            dietsToAdd[0].Name = "Mediterranean diet";
            dietsToAdd[1].Name = "Chicken, cheese & chocolate";
            AddDietItems(dietsToAdd, userId);
        }

        private void PrepareFoodData(string userId)
        {
            foodsToAdd = new List<FoodItem>();
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
        }

        private void PrepareMeasureData(string userId)
        {
            measuresToAdd = new List<Measure>()
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
        }
    }

}
