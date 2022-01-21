using DietAnalyzer.Models.Domains;

namespace DietAnalyzer.Data
{

    /// See DataSeeder.cs for more comments on data seeding classes

    public static partial class MeasureSeeder
    {

        private static FoodMeasure CreateStandardLinkToMeasure(int measureId, int foodId, bool isActive = false)
        {
            return new FoodMeasure
            {
                Id = foodId + (measureId - 1) * 100,
                IsCurrentlyLinked = isActive,
                MeasureId = measureId,
                FoodItemId = foodId,
            };
        }

        private static FoodMeasure[] ConstructFoodMeasures()
        {
            return new FoodMeasure[]
            {
                CreateStandardLinkToMeasure(1,1,true),
                CreateStandardLinkToMeasure(1,2,true),
                CreateStandardLinkToMeasure(1,3,true),
                CreateStandardLinkToMeasure(1,4,true),
                CreateStandardLinkToMeasure(1,5,true),
                CreateStandardLinkToMeasure(1,6,true),
                CreateStandardLinkToMeasure(1,7,true),
                CreateStandardLinkToMeasure(1,8,true),
                CreateStandardLinkToMeasure(1,9,true),
                CreateStandardLinkToMeasure(1,10,true),
                CreateStandardLinkToMeasure(1,11,true),
                CreateStandardLinkToMeasure(1,12,true),
                CreateStandardLinkToMeasure(1,13,true),
                CreateStandardLinkToMeasure(1,14,true),
                CreateStandardLinkToMeasure(1,15,true),
                CreateStandardLinkToMeasure(1,16,true),
                CreateStandardLinkToMeasure(1,17,true),
                CreateStandardLinkToMeasure(1,18,true),
                CreateStandardLinkToMeasure(1,19,true),
                CreateStandardLinkToMeasure(1,20,true),
				//
				CreateStandardLinkToMeasure(2,1,true),
                CreateStandardLinkToMeasure(2,2),
                CreateStandardLinkToMeasure(2,3),
                CreateStandardLinkToMeasure(2,4,true),
                CreateStandardLinkToMeasure(2,5),
                CreateStandardLinkToMeasure(2,6),
                CreateStandardLinkToMeasure(2,7),
                CreateStandardLinkToMeasure(2,8),
                CreateStandardLinkToMeasure(2,9),
                CreateStandardLinkToMeasure(2,10),
                CreateStandardLinkToMeasure(2,11),
                CreateStandardLinkToMeasure(2,12),
                CreateStandardLinkToMeasure(2,13),
                CreateStandardLinkToMeasure(2,14,true),
                CreateStandardLinkToMeasure(2,15),
                CreateStandardLinkToMeasure(2,16),
                CreateStandardLinkToMeasure(2,17),
                CreateStandardLinkToMeasure(2,18),
                CreateStandardLinkToMeasure(2,19),
                CreateStandardLinkToMeasure(2,20),
				//
				CreateStandardLinkToMeasure(3,1,true),
                CreateStandardLinkToMeasure(3,2),
                CreateStandardLinkToMeasure(3,3),
                CreateStandardLinkToMeasure(3,4,true),
                CreateStandardLinkToMeasure(3,5),
                CreateStandardLinkToMeasure(3,6),
                CreateStandardLinkToMeasure(3,7),
                CreateStandardLinkToMeasure(3,8),
                CreateStandardLinkToMeasure(3,9),
                CreateStandardLinkToMeasure(3,10),
                CreateStandardLinkToMeasure(3,11),
                CreateStandardLinkToMeasure(3,12),
                CreateStandardLinkToMeasure(3,13),
                CreateStandardLinkToMeasure(3,14,true),
                CreateStandardLinkToMeasure(3,15),
                CreateStandardLinkToMeasure(3,16),
                CreateStandardLinkToMeasure(3,17),
                CreateStandardLinkToMeasure(3,18),
                CreateStandardLinkToMeasure(3,19),
                CreateStandardLinkToMeasure(3,20),
				//
				CreateStandardLinkToMeasure(4,1,true),
                CreateStandardLinkToMeasure(4,2),
                CreateStandardLinkToMeasure(4,3),
                CreateStandardLinkToMeasure(4,4,true),
                CreateStandardLinkToMeasure(4,5),
                CreateStandardLinkToMeasure(4,6),
                CreateStandardLinkToMeasure(4,7),
                CreateStandardLinkToMeasure(4,8),
                CreateStandardLinkToMeasure(4,9),
                CreateStandardLinkToMeasure(4,10),
                CreateStandardLinkToMeasure(4,11),
                CreateStandardLinkToMeasure(4,12),
                CreateStandardLinkToMeasure(4,13),
                CreateStandardLinkToMeasure(4,14,true),
                CreateStandardLinkToMeasure(4,15),
                CreateStandardLinkToMeasure(4,16),
                CreateStandardLinkToMeasure(4,17),
                CreateStandardLinkToMeasure(4,18,true),
                CreateStandardLinkToMeasure(4,19,true),
                CreateStandardLinkToMeasure(4,20,true),

				// other measures

				new FoodMeasure
                {
                    Id = 1000,
                    IsCurrentlyLinked = true,
                    MeasureId = 10,
                    FoodItemId = 2,
                },
                new FoodMeasure
                {
                    Id = 1001,
                    IsCurrentlyLinked = true,
                    MeasureId = 11,
                    FoodItemId = 3,
                },
                new FoodMeasure
                {
                    Id = 1002,
                    IsCurrentlyLinked = true,
                    MeasureId = 12,
                    FoodItemId = 7,
                },
                new FoodMeasure
                {
                    Id = 1003,
                    IsCurrentlyLinked = true,
                    MeasureId = 12,
                    FoodItemId = 11,
                },
                new FoodMeasure
                {
                    Id = 1004,
                    IsCurrentlyLinked = true,
                    MeasureId = 13,
                    FoodItemId = 12,
                },
                new FoodMeasure
                {
                    Id = 1005,
                    IsCurrentlyLinked = true,
                    MeasureId = 14,
                    FoodItemId = 15,
                },
                new FoodMeasure
                {
                    Id = 1006,
                    IsCurrentlyLinked = true,
                    MeasureId = 15,
                    FoodItemId = 16,
                }
            };
        }
    }
}
