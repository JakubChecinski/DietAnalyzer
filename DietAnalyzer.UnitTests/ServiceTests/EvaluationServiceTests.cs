using DietAnalyzer.Data;
using DietAnalyzer.Services.Utilities;
using DietAnalyzer.Models.Domains;
using DietAnalyzer.UnitTests.Extensions;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietAnalyzer.Services;

namespace DietAnalyzer.UnitTests.ServiceTests
{
    class EvaluationServiceTests
    {
        private EvaluationService service;
        private Mock<IFoodItemService> mockFoodService;
        private Diet testDiet;
        private float nutr1A, nutr1B, nutr2A, nutr2B, quantity1, quantity2, grams1, grams2;

        private void Init()
        {
            mockFoodService = new Mock<IFoodItemService>();
            service = new EvaluationService(mockFoodService.Object);

            nutr1A = 1.1F; nutr1B = 1.2F; nutr2A = 2.1F; nutr2B = 2.2F;
            quantity1 = 1.0F; quantity2 = 2.0F;
            grams1 = 10.0F; grams2 = 20.0F;
        }

        private void InitDiet()
        {
            testDiet = new Diet
            {
                Id = 1,
                DietItems = new List<DietItem>
                {
                    new DietItem
                    {
                        Quantity = quantity1,
                        Measure = new Measure { Grams = grams1 },
                        FoodItem = new FoodItem { Nutrition = new NutritionFood
                        {
                            CalciumPer100g = nutr1A,
                            CaloriesPer100g = nutr1B
                        }}
                    },
                    new DietItem
                    {
                        Quantity = quantity2,
                        Measure = new Measure { Grams = grams2 },
                        FoodItem = new FoodItem { Nutrition = new NutritionFood
                        {
                            CalciumPer100g = nutr2A,
                            CaloriesPer100g = nutr2B
                        }}
                    }
                },
                Nutritions = new NutritionDiet
                {
                    CalciumPer100g = (quantity1 * grams1 * nutr1A + quantity2 * grams2 * nutr2A) / 100.0F,
                    CaloriesPer100g = (quantity1 * grams1 * nutr1B + quantity2 * grams2 * nutr2B) / 100.0F
                }
            };
        }

        [Test]
        public void GetNutritions_DietIsSupplied_CalculateTotalNutritions()
        {
            Init();
            InitDiet();

            var result = service.GetNutritions(testDiet);

            result.CalciumPer100g.Should()
                .Be((quantity1 * grams1 * nutr1A + quantity2 * grams2 * nutr2A) / 100.0F);
            result.CaloriesPer100g.Should()
                .Be((quantity1 * grams1 * nutr1B + quantity2 * grams2 * nutr2B) / 100.0F);
        }

        [Test]
        public void GetNutritions_DietIsNull_ThrowArgumentNullException()
        {
            Init();
            Action action = () => service.GetNutritions(null);
            action.Should().Throw<ArgumentNullException>();
        }


        [Test]
        public void GetSummary_StandardScenario_ReturnCorrectValueAndUnit()
        {
            Init();
            InitDiet();

            var result = service.GetSummary(testDiet);

            result.First(x => x.NutrientName.Contains("Calcium")).Value
                .Should().Be(testDiet.Nutritions.CalciumPer100g);
            result.First(x => x.NutrientName.Contains("Calories")).Value
                .Should().Be(testDiet.Nutritions.CaloriesPer100g);
            result.First(x => x.NutrientName.Contains("Calcium")).Unit
                .Should().Contain("RDI");
            result.First(x => x.NutrientName.Contains("Calories")).Unit
                .Should().Contain("kcal");
        }

        [Test]
        public void GetSummary_RatedNutrientIsLow_ReturnLevelLow()
        {
            Init();
            quantity1 = 0F; quantity2 = 0F;
            InitDiet();

            var result = service.GetSummary(testDiet);

            result.First(x => x.NutrientName.Contains("Calcium")).Level
                .Should().Be(Level.Low);
            result.First(x => x.NutrientName.Contains("Calcium")).Suggestions
                .Should().Contain("doesn't meet your dietary requirements");
        }

        [Test]
        public void GetSummary_RatedNutrientIsNormal_ReturnLevelNormal()
        {
            Init();
            nutr1A = 100F; nutr2A = 0F;
            quantity1 = 1F; quantity2 = 0F;
            grams1 = 100F; grams2 = 0F;
            InitDiet();

            var result = service.GetSummary(testDiet);

            result.First(x => x.NutrientName.Contains("Calcium")).Level
                .Should().Be(Level.Normal);
            result.First(x => x.NutrientName.Contains("Calcium")).Suggestions
                .Should().Contain("no problem with this nutrient");
        }

        [Test]
        public void GetSummary_RatedNutrientIsHigh_ReturnLevelHigh()
        {
            Init();
            quantity1 = 1000F; quantity2 = 1000F;
            InitDiet();

            var result = service.GetSummary(testDiet);

            result.First(x => x.NutrientName.Contains("Calcium")).Level
                .Should().Be(Level.High);
            result.First(x => x.NutrientName.Contains("Calcium")).Suggestions
                .Should().Contain("higher than the recommended upper limit");
        }

        [Test]
        public void GetSummary_UnratedNutrient_ReturnLevelUnrated()
        {
            Init();
            InitDiet();

            var result = service.GetSummary(testDiet);
            result.First(x => x.NutrientName.Contains("Calories")).Level
                .Should().Be(Level.Unrated);
        }

        [Test]
        public void GetSummary_DietIsNull_ThrowArgumentNullException()
        {
            Init();

            Action action = () => service.GetSummary(null);
            action.Should().Throw<ArgumentNullException>();
        }

    }
}
