using DietAnalyzer.Models.Domains;
using System.Collections.Generic;
using System.Linq;

namespace DietAnalyzer.Services.Utilities
{
    public partial class ExampleDataService
    {
        private void AddDietItems(List<Diet> diets, string userId)
        {
            if (diets == null || diets.Count < 2) return;
            diets[0].DietItems = new List<DietItem>
            {
                new DietItem
                {
                    FoodItemId = _foodService.GetCustom(userId)
                        .Single(x => x.Name == "orange juice"  && x.UserId == userId).Id,
                    MeasureId = 4,
                    Quantity = 1.0F,
                },
                new DietItem
                {
                    FoodItemId = 4,
                    MeasureId = 4,
                    Quantity = 1.0F,
                },
                new DietItem
                {
                    FoodItemId = 7,
                    MeasureId = 12,
                    Quantity = 10.0F,
                },
                new DietItem
                {
                    FoodItemId = 9,
                    MeasureId = 2,
                    Quantity = 2.0F,
                },
                new DietItem
                {
                    FoodItemId = 12,
                    MeasureId = 13,
                    Quantity = 12.0F,
                },
                new DietItem
                {
                    FoodItemId = 14,
                    MeasureId = 2,
                    Quantity = 4.0F,
                },
                new DietItem
                {
                    FoodItemId = 15,
                    MeasureId = 14,
                    Quantity = 3.0F,
                },
                new DietItem
                {
                    FoodItemId = 16,
                    MeasureId = 15,
                    Quantity = 0.25F,
                },
                new DietItem
                {
                    FoodItemId = 17,
                    MeasureId = 1,
                    Quantity = 200.0F,
                },
                new DietItem
                {
                    FoodItemId = 20,
                    MeasureId = 4,
                    Quantity = 0.5F,
                },
            };
            diets[1].DietItems = new List<DietItem>
            {
                new DietItem
                {
                    FoodItemId = 5,
                    MeasureId = 1,
                    Quantity = 400.0F,
                },
                new DietItem
                {
                    FoodItemId = 9,
                    MeasureId = 1,
                    Quantity = 200.0F,
                },
                new DietItem
                {
                    FoodItemId = 10,
                    MeasureId = 1,
                    Quantity = 150.0F,
                },
                new DietItem
                {
                    FoodItemId = 11,
                    MeasureId = 12,
                    Quantity = 4.0F,
                },
            };

        }

    }
}
