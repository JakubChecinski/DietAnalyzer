﻿using DietAnalyzer.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Data
{

	/// See DataSeeder.cs for more comments on data seeding classes

	public static partial class FoodSeeder
    {
		private static NutritionFood[] ConstructFoodNutritions()
		{
			return new NutritionFood[]
			{
				new NutritionFood
				{
					Id = 1,
					FoodItemId = 1,
					CaloriesPer100g = 23.0F,
					FiberPer100g = 2.2F,
					SugarPer100g = 0.4F,
					CarbohydratesPer100g = 3.6F,
					SaturatedFatPer100g = 0.1F,
					FatsPer100g = 0.4F,
					ProteinsPer100g = 2.9F,
					VitaminAPer100g = 188,
					VitaminCPer100g = 47,
					VitaminDPer100g = 0,
					VitaminEPer100g = 10,
					VitaminKPer100g = 604,
					VitaminB1Per100g = 5,
					VitaminB2Per100g = 11,
					VitaminB3Per100g = 4,
					VitaminB6Per100g = 10,
					VitaminB9Per100g = 49,
					VitaminB12Per100g = 0,
					CalciumPer100g = 3,
					IronPer100g = 5,
					MagnesiumPer100g = 6,
					PhosphorusPer100g = 1,
					PotassiumPer100g = 5,
					SodiumPer100g = 3,
					ZincPer100g = 1,
					CopperPer100g = 2,
					ManganesePer100g = 13,
					SeleniumPer100g = 0,
				},
				new NutritionFood
				{
					Id = 2,
					FoodItemId = 2,
					CaloriesPer100g = 89.0F,
					FiberPer100g = 2.6F,
					SugarPer100g = 12.2F,
					CarbohydratesPer100g = 22.8F,
					SaturatedFatPer100g = 0.1F,
					FatsPer100g = 0.3F,
					ProteinsPer100g = 1.1F,
					VitaminAPer100g = 1,
					VitaminCPer100g = 15,
					VitaminDPer100g = 0,
					VitaminEPer100g = 1,
					VitaminKPer100g = 1,
					VitaminB1Per100g = 2,
					VitaminB2Per100g = 4,
					VitaminB3Per100g = 3,
					VitaminB6Per100g = 18,
					VitaminB9Per100g = 5,
					VitaminB12Per100g = 0,
					CalciumPer100g = 1,
					IronPer100g = 1,
					MagnesiumPer100g = 7,
					PhosphorusPer100g = 2,
					PotassiumPer100g = 10,
					SodiumPer100g = 0,
					ZincPer100g = 1,
					CopperPer100g = 4,
					ManganesePer100g = 13,
					SeleniumPer100g = 1,
				},
				new NutritionFood
				{
					Id = 3,
					FoodItemId = 3,
					CaloriesPer100g = 155,
					FiberPer100g = 0.0F,
					SugarPer100g = 1.1F,
					CarbohydratesPer100g = 1.1F,
					SaturatedFatPer100g = 3.3F,
					FatsPer100g = 10.6F,
					ProteinsPer100g = 12.6F,
					VitaminAPer100g = 12,
					VitaminCPer100g = 0,
					VitaminDPer100g = 0,
					VitaminEPer100g = 5,
					VitaminKPer100g = 0,
					VitaminB1Per100g = 4,
					VitaminB2Per100g = 30,
					VitaminB3Per100g = 0,
					VitaminB6Per100g = 6,
					VitaminB9Per100g = 11,
					VitaminB12Per100g = 19,
					CalciumPer100g = 5,
					IronPer100g = 7,
					MagnesiumPer100g = 2,
					PhosphorusPer100g = 17,
					PotassiumPer100g = 4,
					SodiumPer100g = 5,
					ZincPer100g = 7,
					CopperPer100g = 1,
					ManganesePer100g = 1,
					SeleniumPer100g = 44,
				},
				new NutritionFood
				{
					Id = 4,
					FoodItemId = 4,
					CaloriesPer100g = 61,
					FiberPer100g = 0.0F,
					SugarPer100g = 4.7F,
					CarbohydratesPer100g = 4.7F,
					SaturatedFatPer100g = 2.1F,
					FatsPer100g = 3.3F,
					ProteinsPer100g = 3.5F,
					VitaminAPer100g = 2,
					VitaminCPer100g = 1,
					VitaminDPer100g = 0,
					VitaminEPer100g = 0,
					VitaminKPer100g = 0,
					VitaminB1Per100g = 2,
					VitaminB2Per100g = 8,
					VitaminB3Per100g = 0,
					VitaminB6Per100g = 2,
					VitaminB9Per100g = 2,
					VitaminB12Per100g = 6,
					CalciumPer100g = 12,
					IronPer100g = 0,
					MagnesiumPer100g = 3,
					PhosphorusPer100g = 9,
					PotassiumPer100g = 4,
					SodiumPer100g = 2,
					ZincPer100g = 4,
					CopperPer100g = 0,
					ManganesePer100g = 0,
					SeleniumPer100g = 3,
				},
				new NutritionFood
				{
					Id = 5,
					FoodItemId = 5,
					CaloriesPer100g = 79.0F,
					FiberPer100g = 0.0F,
					SugarPer100g = 0.1F,
					CarbohydratesPer100g = 0.2F,
					SaturatedFatPer100g = 0.1F,
					FatsPer100g = 0.4F,
					ProteinsPer100g = 16.8F,
					VitaminAPer100g = 0,
					VitaminCPer100g = 0,
					VitaminDPer100g = 0,
					VitaminEPer100g = 0,
					VitaminKPer100g = 0,
					VitaminB1Per100g = 1,
					VitaminB2Per100g = 2,
					VitaminB3Per100g = 17,
					VitaminB6Per100g = 8,
					VitaminB9Per100g = 0,
					VitaminB12Per100g = 1,
					CalciumPer100g = 1,
					IronPer100g = 2,
					MagnesiumPer100g = 2,
					PhosphorusPer100g = 6,
					PotassiumPer100g = 2,
					SodiumPer100g = 45,
					ZincPer100g = 2,
					CopperPer100g = 2,
					ManganesePer100g = 2,
					SeleniumPer100g = 11,
				},
				new NutritionFood
				{
					Id = 6,
					FoodItemId = 6,
					CaloriesPer100g = 206,
					FiberPer100g = 0.0F,
					SugarPer100g = 0.0F,
					CarbohydratesPer100g = 0.0F,
					SaturatedFatPer100g = 2.5F,
					FatsPer100g = 12.3F,
					ProteinsPer100g = 22.1F,
					VitaminAPer100g = 1,
					VitaminCPer100g = 6,
					VitaminDPer100g = 0,
					VitaminEPer100g = 0,
					VitaminKPer100g = 0,
					VitaminB1Per100g = 23,
					VitaminB2Per100g = 8,
					VitaminB3Per100g = 40,
					VitaminB6Per100g = 32,
					VitaminB9Per100g = 8,
					VitaminB12Per100g = 47,
					CalciumPer100g = 1,
					IronPer100g = 2,
					MagnesiumPer100g = 8,
					PhosphorusPer100g = 25,
					PotassiumPer100g = 11,
					SodiumPer100g = 3,
					ZincPer100g = 3,
					CopperPer100g = 2,
					ManganesePer100g = 1,
					SeleniumPer100g = 59,
				},
				new NutritionFood
				{
					Id = 7,
					FoodItemId = 7,
					CaloriesPer100g = 258,
					FiberPer100g = 5.8F,
					SugarPer100g = 3.8F,
					CarbohydratesPer100g = 48.3F,
					SaturatedFatPer100g = 0.6F,
					FatsPer100g = 3.3F,
					ProteinsPer100g = 8.5F,
					VitaminAPer100g = 0,
					VitaminCPer100g = 1,
					VitaminDPer100g = 0,
					VitaminEPer100g = 2,
					VitaminKPer100g = 1,
					VitaminB1Per100g = 29,
					VitaminB2Per100g = 20,
					VitaminB3Per100g = 19,
					VitaminB6Per100g = 4,
					VitaminB9Per100g = 27,
					VitaminB12Per100g = 0,
					CalciumPer100g = 7,
					IronPer100g = 16,
					MagnesiumPer100g = 10,
					PhosphorusPer100g = 12,
					PotassiumPer100g = 5,
					SodiumPer100g = 27,
					ZincPer100g = 8,
					CopperPer100g = 9,
					ManganesePer100g = 41,
					SeleniumPer100g = 44,
				},
				new NutritionFood
				{
					Id = 8,
					FoodItemId = 8,
					CaloriesPer100g = 86.0F,
					FiberPer100g = 1.8F,
					SugarPer100g = 0.9F,
					CarbohydratesPer100g = 20.0F,
					SaturatedFatPer100g = 0.0F,
					FatsPer100g = 0.1F,
					ProteinsPer100g = 1.7F,
					VitaminAPer100g = 0,
					VitaminCPer100g = 12,
					VitaminDPer100g = 0,
					VitaminEPer100g = 0,
					VitaminKPer100g = 3,
					VitaminB1Per100g = 7,
					VitaminB2Per100g = 1,
					VitaminB3Per100g = 7,
					VitaminB6Per100g = 13,
					VitaminB9Per100g = 2,
					VitaminB12Per100g = 0,
					CalciumPer100g = 1,
					IronPer100g = 2,
					MagnesiumPer100g = 5,
					PhosphorusPer100g = 4,
					PotassiumPer100g = 9,
					SodiumPer100g = 0,
					ZincPer100g = 2,
					CopperPer100g = 8,
					ManganesePer100g = 7,
					SeleniumPer100g = 0,
				}
			};
		}

	}
}
