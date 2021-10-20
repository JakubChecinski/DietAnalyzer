﻿using DietAnalyzer.Models.Domains;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DietAnalyzer.Services.Utilities
{
    public class EvaluationService : IEvaluationService
    {
        private const float CarbProtToFatCalorieRatio = 2.25F;
        private IFoodItemService _foodService;
        public EvaluationService(IFoodItemService foodService)
        {
            _foodService = foodService;
        }
        public NutritionDiet GetNutritions(Diet diet)
        {
            var totalNutrition = new NutritionDiet
            {
                DietId = diet.Id,
            };
            totalNutrition.CaloriesPer100g = 0.0F;
            totalNutrition.FiberPer100g = 0.0F;
            totalNutrition.SugarPer100g = 0.0F;
            totalNutrition.CarbohydratesPer100g = 0.0F;
            totalNutrition.SaturatedFatPer100g = 0.0F;
            totalNutrition.FatsPer100g = 0.0F;
            totalNutrition.ProteinsPer100g = 0.0F;
            totalNutrition.VitaminAPer100g = 0.0F;
            totalNutrition.VitaminCPer100g = 0.0F;
            totalNutrition.VitaminDPer100g = 0.0F;
            totalNutrition.VitaminEPer100g = 0.0F;
            totalNutrition.VitaminKPer100g = 0.0F;
            totalNutrition.VitaminB1Per100g = 0.0F;
            totalNutrition.VitaminB2Per100g = 0.0F;
            totalNutrition.VitaminB3Per100g = 0.0F;
            totalNutrition.VitaminB6Per100g = 0.0F;
            totalNutrition.VitaminB9Per100g = 0.0F;
            totalNutrition.VitaminB12Per100g = 0.0F;
            totalNutrition.CalciumPer100g = 0.0F;
            totalNutrition.IronPer100g = 0.0F;
            totalNutrition.MagnesiumPer100g = 0.0F;
            totalNutrition.PhosphorusPer100g = 0.0F;
            totalNutrition.PotassiumPer100g = 0.0F;
            totalNutrition.SodiumPer100g = 0.0F;
            totalNutrition.ZincPer100g = 0.0F;
            totalNutrition.CopperPer100g = 0.0F;
            totalNutrition.ManganesePer100g = 0.0F;
            totalNutrition.SeleniumPer100g = 0.0F;
            foreach (var item in diet.DietItems)
            {
                totalNutrition.CaloriesPer100g += item.FoodItem.Nutrition.CaloriesPer100g * item.Quantity * item.Measure.Grams / 100.0F;
                totalNutrition.FiberPer100g += item.FoodItem.Nutrition.FiberPer100g * item.Quantity * item.Measure.Grams / 100.0F;
                totalNutrition.SugarPer100g += item.FoodItem.Nutrition.SugarPer100g * item.Quantity * item.Measure.Grams / 100.0F;
                totalNutrition.CarbohydratesPer100g += item.FoodItem.Nutrition.CarbohydratesPer100g * item.Quantity * item.Measure.Grams / 100.0F;
                totalNutrition.SaturatedFatPer100g += item.FoodItem.Nutrition.SaturatedFatPer100g * item.Quantity * item.Measure.Grams / 100.0F;
                totalNutrition.FatsPer100g += item.FoodItem.Nutrition.FatsPer100g * item.Quantity * item.Measure.Grams / 100.0F;
                totalNutrition.ProteinsPer100g += item.FoodItem.Nutrition.ProteinsPer100g * item.Quantity * item.Measure.Grams / 100.0F;
                totalNutrition.VitaminAPer100g += item.FoodItem.Nutrition.VitaminAPer100g * item.Quantity * item.Measure.Grams / 100.0F;
                totalNutrition.VitaminCPer100g += item.FoodItem.Nutrition.VitaminCPer100g * item.Quantity * item.Measure.Grams / 100.0F;
                totalNutrition.VitaminDPer100g += item.FoodItem.Nutrition.VitaminDPer100g * item.Quantity * item.Measure.Grams / 100.0F;
                totalNutrition.VitaminEPer100g += item.FoodItem.Nutrition.VitaminEPer100g * item.Quantity * item.Measure.Grams / 100.0F;
                totalNutrition.VitaminKPer100g += item.FoodItem.Nutrition.VitaminKPer100g * item.Quantity * item.Measure.Grams / 100.0F;
                totalNutrition.VitaminB1Per100g += item.FoodItem.Nutrition.VitaminB1Per100g * item.Quantity * item.Measure.Grams / 100.0F;
                totalNutrition.VitaminB2Per100g += item.FoodItem.Nutrition.VitaminB2Per100g * item.Quantity * item.Measure.Grams / 100.0F;
                totalNutrition.VitaminB3Per100g += item.FoodItem.Nutrition.VitaminB3Per100g * item.Quantity * item.Measure.Grams / 100.0F;
                totalNutrition.VitaminB6Per100g += item.FoodItem.Nutrition.VitaminB6Per100g * item.Quantity * item.Measure.Grams / 100.0F;
                totalNutrition.VitaminB9Per100g += item.FoodItem.Nutrition.VitaminB9Per100g * item.Quantity * item.Measure.Grams / 100.0F;
                totalNutrition.VitaminB12Per100g += item.FoodItem.Nutrition.VitaminB12Per100g * item.Quantity * item.Measure.Grams / 100.0F;
                totalNutrition.CalciumPer100g += item.FoodItem.Nutrition.CalciumPer100g * item.Quantity * item.Measure.Grams / 100.0F;
                totalNutrition.IronPer100g += item.FoodItem.Nutrition.IronPer100g * item.Quantity * item.Measure.Grams / 100.0F;
                totalNutrition.MagnesiumPer100g += item.FoodItem.Nutrition.MagnesiumPer100g * item.Quantity * item.Measure.Grams / 100.0F;
                totalNutrition.PhosphorusPer100g += item.FoodItem.Nutrition.PhosphorusPer100g * item.Quantity * item.Measure.Grams / 100.0F;
                totalNutrition.PotassiumPer100g += item.FoodItem.Nutrition.PotassiumPer100g * item.Quantity * item.Measure.Grams / 100.0F;
                totalNutrition.SodiumPer100g += item.FoodItem.Nutrition.SodiumPer100g * item.Quantity * item.Measure.Grams / 100.0F;
                totalNutrition.ZincPer100g += item.FoodItem.Nutrition.ZincPer100g * item.Quantity * item.Measure.Grams / 100.0F;
                totalNutrition.CopperPer100g += item.FoodItem.Nutrition.CopperPer100g * item.Quantity * item.Measure.Grams / 100.0F;
                totalNutrition.ManganesePer100g += item.FoodItem.Nutrition.ManganesePer100g * item.Quantity * item.Measure.Grams / 100.0F;
                totalNutrition.SeleniumPer100g += item.FoodItem.Nutrition.SeleniumPer100g * item.Quantity * item.Measure.Grams / 100.0F;
            }
            return totalNutrition;
        }

        public List<EvaluationResult> GetSummary(Diet diet)
        {
            var results = new List<EvaluationResult>();
            results.Add(new EvaluationResult
            {
                NutrientName = "Calories",
                Level = Level.Unrated,
                Value = diet.Nutritions.CaloriesPer100g,
                Unit = "kcal",
                Suggestions = "Usually, the recommended range of daily calories is between 2000 and 2500 kcal," +
                " but this can be changed by various factors, such as your gender, level of physical activity," +
                " body size or being currently on a weight loss diet."
            });
            results.Add(new EvaluationResult
            {
                NutrientName = "Carbohydrates",
                Level = Level.Unrated,
                Value = diet.Nutritions.CarbohydratesPer100g,
                Unit = "grams",
                Suggestions = "Your percentage of calories coming from carbohydrates is " +
                (diet.Nutritions.CarbohydratesPer100g / diet.Nutritions.CarbohydratesPer100g +
                    diet.Nutritions.ProteinsPer100g + diet.Nutritions.FatsPer100g * CarbProtToFatCalorieRatio).ToString() +
                "%. The commonly recommended range is 45-65%, but some diets may require a percentage " +
                "that is much lower or slightly higher."
            });
            results.Add(new EvaluationResult
            {
                NutrientName = "Fibers",
                Level = Level.Unrated,
                Value = diet.Nutritions.FiberPer100g,
                Unit = "grams",
                Suggestions = "Usually, the recommended amount of fiber is no less than 20-25 grams for women " +
                "and around 30-35 grams for men. Typically, it is also not recommended to eat more " +
                "than 70 grams per day.",
            });
            results.Add(new EvaluationResult
            {
                NutrientName = "Sugars",
                Level = Level.Unrated,
                Value = diet.Nutritions.SugarPer100g,
                Unit = "grams",
                Suggestions = "While there is no clear value for recommended total sugar intake, " +
                "it is commonly understood that large amounts of added sugars in your diet are unhealthy.",
            });
            results.Add(new EvaluationResult
            {
                NutrientName = "Fats",
                Level = Level.Unrated,
                Value = diet.Nutritions.FatsPer100g,
                Unit = "grams",
                Suggestions = "Your percentage of calories coming from fat is " +
                (CarbProtToFatCalorieRatio *diet.Nutritions.FatsPer100g / diet.Nutritions.CarbohydratesPer100g +
                    diet.Nutritions.ProteinsPer100g + diet.Nutritions.FatsPer100g * CarbProtToFatCalorieRatio).ToString() +
                "%. The commonly recommended range is 20-35%, but some diets may require a percentage " +
                "that is slightly lower or much higher."
            });
            results.Add(new EvaluationResult
            {
                NutrientName = "Saturated Fats",
                Level = Level.Unrated,
                Value = diet.Nutritions.SaturatedFatPer100g,
                Unit = "grams",
                Suggestions = "Your percentage of calories coming from saturated fat is " +
                (CarbProtToFatCalorieRatio * diet.Nutritions.SaturatedFatPer100g / diet.Nutritions.CarbohydratesPer100g +
                    diet.Nutritions.ProteinsPer100g + diet.Nutritions.FatsPer100g * CarbProtToFatCalorieRatio).ToString() +
                "%. The most commonly found recommendation is no more than 10%, but some diets set a limit that is " +
                "significantly lower or significantly higher."
            });
            results.Add(new EvaluationResult
            {
                NutrientName = "Proteins",
                Level = Level.Unrated,
                Value = diet.Nutritions.ProteinsPer100g,
                Unit = "grams",
                Suggestions = "Your percentage of calories coming from proteins is " +
                (diet.Nutritions.ProteinsPer100g / diet.Nutritions.CarbohydratesPer100g +
                    diet.Nutritions.ProteinsPer100g + diet.Nutritions.FatsPer100g * CarbProtToFatCalorieRatio).ToString() +
                "%. The recommended range is 10-35%, which tends to be agreed upon " +
                "by a wide range of different diets."
            });
            EvaluateMicronutrient("VitaminA", diet.Nutritions.VitaminAPer100g, results, diet);
            EvaluateMicronutrient("VitaminB1", diet.Nutritions.VitaminB1Per100g, results, diet);
            EvaluateMicronutrient("VitaminB2", diet.Nutritions.VitaminB2Per100g, results, diet);
            EvaluateMicronutrient("VitaminB3", diet.Nutritions.VitaminB3Per100g, results, diet);
            EvaluateMicronutrient("VitaminB6", diet.Nutritions.VitaminB6Per100g, results, diet);
            EvaluateMicronutrient("VitaminB9", diet.Nutritions.VitaminB9Per100g, results, diet);
            EvaluateMicronutrient("VitaminB12", diet.Nutritions.VitaminB12Per100g, results, diet);
            EvaluateMicronutrient("VitaminC", diet.Nutritions.VitaminCPer100g, results, diet);
            EvaluateMicronutrient("VitaminD", diet.Nutritions.VitaminDPer100g, results, diet);
            EvaluateMicronutrient("VitaminE", diet.Nutritions.VitaminEPer100g, results, diet);
            EvaluateMicronutrient("VitaminK", diet.Nutritions.VitaminKPer100g, results, diet);
            EvaluateMicronutrient("Calcium", diet.Nutritions.CalciumPer100g, results, diet);
            EvaluateMicronutrient("Iron", diet.Nutritions.IronPer100g, results, diet);
            EvaluateMicronutrient("Magnesium", diet.Nutritions.MagnesiumPer100g, results, diet);
            EvaluateMicronutrient("Phosphorus", diet.Nutritions.PhosphorusPer100g, results, diet);
            EvaluateMicronutrient("Potassium", diet.Nutritions.PotassiumPer100g, results, diet);
            EvaluateMicronutrient("Sodium", diet.Nutritions.SodiumPer100g, results, diet);
            EvaluateMicronutrient("Zinc", diet.Nutritions.ZincPer100g, results, diet);
            EvaluateMicronutrient("Copper", diet.Nutritions.CopperPer100g, results, diet);
            EvaluateMicronutrient("Manganese", diet.Nutritions.ManganesePer100g, results, diet);
            EvaluateMicronutrient("Selenium", diet.Nutritions.SeleniumPer100g, results, diet);
            return results;
        }

        private void EvaluateMicronutrient(string name, float? value, List<EvaluationResult> results, Diet diet)
        {
            if (value == null) return;
            var micronutrientResult = new EvaluationResult
            {
                NutrientName = name.Replace("Vitamin", "Vitamin "),
                Value = value,
                Unit = "% of RDI",
            };
            if (value < 95.0)
            {
                micronutrientResult.Level = Level.Low;
                var foodsToAdd = _foodService.Get(diet.UserId, true).AsQueryable()
                    .OrderBy($"x => x.Nutrition.{name}Per100g desc").Take(3);
                var stringWithFoodsToAdd = foodsToAdd == null || foodsToAdd.Count() == 0 ? null :
                    foodsToAdd.Count() == 1 ? "" + foodsToAdd.ElementAt(0).Name + "" :
                    foodsToAdd.Count() == 2 ? "" + foodsToAdd.ElementAt(0).Name + " and "
                    + foodsToAdd.ElementAt(1).Name + "" :
                    "" + foodsToAdd.ElementAt(0).Name + ", "
                    + foodsToAdd.ElementAt(1).Name + " and "
                    + foodsToAdd.ElementAt(2).Name + "";
                micronutrientResult.Suggestions = "This value doesn't meet your dietary requirements. Consider" +
                    " adding the following foods high in " + name.Replace("Vitamin", "Vitamin ")
                    + " to your diet: " + stringWithFoodsToAdd + ".";
            }
            else if (value > DataHelper.HighValues[name])
            {
                micronutrientResult.Level = Level.High;
                var foodsToCut = diet.DietItems.AsQueryable()
                    .OrderBy($"x => x.FoodItem.Nutrition.{name}Per100g desc").Take(3);
                var stringWithFoodsToCut = foodsToCut == null || foodsToCut.Count() == 0 ? null :
                    foodsToCut.Count() == 1 ? "" + foodsToCut.ElementAt(0).FoodItem.Name + "" :
                    foodsToCut.Count() == 2 ? "" + foodsToCut.ElementAt(0).FoodItem.Name + " and "
                    + foodsToCut.ElementAt(1).FoodItem.Name + "" :
                    "" + foodsToCut.ElementAt(0).FoodItem.Name + ", "
                    + foodsToCut.ElementAt(1).FoodItem.Name + " and "
                    + foodsToCut.ElementAt(2).FoodItem.Name + "";
                micronutrientResult.Suggestions = "This value is higher than the recommended upper limit, which " +
                    "would be " + (int)DataHelper.HighValues[name] + "%. Consider cutting the following foods " +
                    "high in " + name.Replace("Vitamin", "Vitamin ") + " from your diet: " + stringWithFoodsToCut + ".";
            }
            else
            {
                micronutrientResult.Level = Level.Normal;
                micronutrientResult.Suggestions = "It seems you have no problem with this nutrient. Great job!";
            }
            results.Add(micronutrientResult);
        }

    }
}
