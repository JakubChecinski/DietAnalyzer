using DietAnalyzer.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Services.Utilities
{
    public partial class ExampleDataService
    {
        private void AddNutritions(List<FoodItem> foods)
        {
            if (foods == null || foods.Count < 2) return;
			foods[0].Nutrition = new NutritionFood
			{
				CaloriesPer100g = 41.0F,
				FiberPer100g = 2.8F,
				SugarPer100g = 4.7F,
				CarbohydratesPer100g = 9.6F,
				SaturatedFatPer100g = 0.0F,
				FatsPer100g = 0.2F,
				ProteinsPer100g = 0.9F,
				VitaminAPer100g = 334,
				VitaminCPer100g = 10,
				VitaminDPer100g = 0,
				VitaminEPer100g = 3,
				VitaminKPer100g = 16,
				VitaminB1Per100g = 4,
				VitaminB2Per100g = 3,
				VitaminB3Per100g = 5,
				VitaminB6Per100g = 7,
				VitaminB9Per100g = 5,
				VitaminB12Per100g = 0,
				CalciumPer100g = 3,
				IronPer100g = 2,
				MagnesiumPer100g = 3,
				PhosphorusPer100g = 4,
				PotassiumPer100g = 9,
				SodiumPer100g = 3,
				ZincPer100g = 2,
				CopperPer100g = 2,
				ManganesePer100g = 7,
				SeleniumPer100g = 0,
			};
			foods[1].Nutrition = new NutritionFood
			{
				CaloriesPer100g = 47.0F,
				FiberPer100g = 0.3F,
				SugarPer100g = 8.8F,
				CarbohydratesPer100g = 11.0F,
				SaturatedFatPer100g = 0.0F,
				FatsPer100g = 0.2F,
				ProteinsPer100g = 0.7F,
				VitaminAPer100g = 4,
				VitaminCPer100g = 50,
				VitaminDPer100g = 0,
				VitaminEPer100g = 1,
				VitaminKPer100g = 0,
				VitaminB1Per100g = 3,
				VitaminB2Per100g = 1,
				VitaminB3Per100g = 1,
				VitaminB6Per100g = 2,
				VitaminB9Per100g = 6,
				VitaminB12Per100g = 0,
				CalciumPer100g = 1,
				IronPer100g = 1,
				MagnesiumPer100g = 2,
				PhosphorusPer100g = 2,
				PotassiumPer100g = 5,
				SodiumPer100g = 0,
				ZincPer100g = 0,
				CopperPer100g = 1,
				ManganesePer100g = 1,
				SeleniumPer100g = 0,
			};
		}

        private void AddRestrictions(List<FoodItem> foods)
        {
            if (foods == null || foods.Count < 2) return;
			foods[0].Restrictions = new RestrictionFood
			{
				Pescetarian = true,
				Vegetarian = true,
				Vegan = true,
				DairyIntolerant = true,
				GlutenIntolerant = true,
				Paleo = true,
				Keto = false,
				Diabetes = true,
				HeartProblems = true,
				KidneyProblems = true,
			};
			foods[1].Restrictions = new RestrictionFood
			{
				Pescetarian = true,
				Vegetarian = true,
				Vegan = true,
				DairyIntolerant = true,
				GlutenIntolerant = true,
				Paleo = false,
				Keto = false,
				Diabetes = true,
				HeartProblems = true,
				KidneyProblems = false,
			};
		}

    }
}
