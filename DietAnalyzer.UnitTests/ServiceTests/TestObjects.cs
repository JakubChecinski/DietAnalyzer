using DietAnalyzer.Models.Domains;
using DietAnalyzer.Models.ViewModels;
using System.Collections.Generic;

namespace DietAnalyzer.UnitTests.ServiceTests
{
    /// <summary>
    /// Helper class producing objects for service unit tests
    /// </summary>
    public static class TestObjects
    {
        public static Diet GetDiet()
        {
            return new Diet()
            {
                Id = 1,
                DietItems = new List<DietItem>
                {
                    new DietItem
                    {
                        Id = 1,
                        FoodItemId = 1,
                    },
                    new DietItem
                    {
                        Id = 2,
                        FoodItemId = 2,
                    },
                }
            };
        }

        public static DietViewModel GetDietViewModel()
        {
            return new DietViewModel()
            {
                DietItems = new List<DietItem>
                {
                    new DietItem { Id = 1, FoodItemId = 1, FoodItem = new FoodItem() }
                },
                Diet = new Diet()
            };
        }

        public static FoodItem GetFood(FoodType type)
        {
            switch (type)
            {
                case FoodType.Normal:
                    return new FoodItem { Id = 1 };
                case FoodType.Custom:
                    return new FoodItem { Id = 2, UserId = "abc" };
                case FoodType.Restricted:
                    return new FoodItem
                    {
                        Id = 3,
                        Restrictions = new RestrictionFood { Diabetes = false }
                    };
                case FoodType.CustomRestricted:
                    return new FoodItem
                    {
                        Id = 4,
                        UserId = "abc",
                        Restrictions = new RestrictionFood { Diabetes = false }
                    };
                case FoodType.NormalWithMeasures:
                    return new FoodItem
                    {
                        Id = 5,
                        Measures = new List<FoodMeasure>
                        {
                            new FoodMeasure
                            {
                                Id = 1,
                                IsCurrentlyLinked = true,
                                MeasureId = 1,
                                Measure = new Measure { Name = "linked" }
                            },
                            new FoodMeasure
                            {
                                Id = 2,
                                IsCurrentlyLinked = false,
                                MeasureId = 2,
                                Measure = new Measure { Name = "unlinked" }
                            },
                        }
                    };
                case FoodType.NormalWithAllElements:
                    return new FoodItem
                    {
                        Id = 6,
                        Nutrition = new NutritionFood { Id = 1 },
                        Restrictions = new RestrictionFood { Id = 1 },
                        Measures = new List<FoodMeasure> { new FoodMeasure { Id = 1 } },
                        DietItems = new List<DietItem> { new DietItem { Id = 1 } }
                    };
                default:
                    return null;
            }
        }

        public static FoodItemViewModel GetFoodViewModel(List<FoodMeasure> measures)
        {
            return new FoodItemViewModel()
            {
                AvailableMeasures = measures,
                FoodItem = new FoodItem(),
            };
        }

        public static Measure GetMeasureWithId(int id, string userId = null)
        {
            return new Measure
            {
                Id = id,
                UserId = userId,
                FoodItems = new List<FoodMeasure> { new FoodMeasure { Id = 1 } },
                DietItems = new List<DietItem> { new DietItem { Id = 1 } }
            };
        }

    }


    public enum FoodType
    {
        Normal,
        Custom,
        Restricted,
        CustomRestricted,
        NormalWithMeasures,
        NormalWithAllElements
    }

}
