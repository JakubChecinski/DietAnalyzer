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
				},
				new NutritionFood
				{
					Id = 9,
					FoodItemId = 9,
					CaloriesPer100g = 356,
					FiberPer100g = 0.0F,
					SugarPer100g = 2.2F,
					CarbohydratesPer100g = 2.2F,
					SaturatedFatPer100g = 17.6F,
					FatsPer100g = 27.4F,
					ProteinsPer100g = 24.9F,
					VitaminAPer100g = 11,
					VitaminCPer100g = 0,
					VitaminDPer100g = 0,
					VitaminEPer100g = 1,
					VitaminKPer100g = 2,
					VitaminB1Per100g = 3,
					VitaminB2Per100g = 20,
					VitaminB3Per100g = 0,
					VitaminB6Per100g = 4,
					VitaminB9Per100g = 5,
					VitaminB12Per100g = 26,
					CalciumPer100g = 70,
					IronPer100g = 1,
					MagnesiumPer100g = 7,
					PhosphorusPer100g = 55,
					PotassiumPer100g = 3,
					SodiumPer100g = 34,
					ZincPer100g = 26,
					CopperPer100g = 2,
					ManganesePer100g = 1,
					SeleniumPer100g = 21,
				},
				new NutritionFood
				{
					Id = 10,
					FoodItemId = 10,
					CaloriesPer100g = 479,
					FiberPer100g = 5.9F,
					SugarPer100g = 54.5F,
					CarbohydratesPer100g = 63.1F,
					SaturatedFatPer100g = 17.7F,
					FatsPer100g = 30.0F,
					ProteinsPer100g = 4.2F,
					VitaminAPer100g = 0,
					VitaminCPer100g = 0,
					VitaminDPer100g = 0,
					VitaminEPer100g = 1,
					VitaminKPer100g = 7,
					VitaminB1Per100g = 4,
					VitaminB2Per100g = 5,
					VitaminB3Per100g = 2,
					VitaminB6Per100g = 2,
					VitaminB9Per100g = 3,
					VitaminB12Per100g = 0,
					CalciumPer100g = 3,
					IronPer100g = 17,
					MagnesiumPer100g = 29,
					PhosphorusPer100g = 13,
					PotassiumPer100g = 10,
					SodiumPer100g = 0,
					ZincPer100g = 11,
					CopperPer100g = 35,
					ManganesePer100g = 40,
					SeleniumPer100g = 6,
				},
				new NutritionFood
				{
					Id = 11,
					FoodItemId = 11,
					CaloriesPer100g = 266,
					FiberPer100g = 3.6F,
					SugarPer100g = 5.8F,
					CarbohydratesPer100g = 47.5F,
					SaturatedFatPer100g = 0.8F,
					FatsPer100g = 3.6F,
					ProteinsPer100g = 10.9F,
					VitaminAPer100g = 0,
					VitaminCPer100g = 0,
					VitaminDPer100g = 0,
					VitaminEPer100g = 1,
					VitaminKPer100g = 6,
					VitaminB1Per100g = 25,
					VitaminB2Per100g = 18,
					VitaminB3Per100g = 26,
					VitaminB6Per100g = 6,
					VitaminB9Per100g = 21,
					VitaminB12Per100g = 0,
					CalciumPer100g = 14,
					IronPer100g = 19,
					MagnesiumPer100g = 12,
					PhosphorusPer100g = 15,
					PotassiumPer100g = 5,
					SodiumPer100g = 22,
					ZincPer100g = 8,
					CopperPer100g = 8,
					ManganesePer100g = 56,
					SeleniumPer100g = 41,
				},
				new NutritionFood
				{
					Id = 12,
					FoodItemId = 12,
					CaloriesPer100g = 208,
					FiberPer100g = 0.0F,
					SugarPer100g = 0.0F,
					CarbohydratesPer100g = 0.0F,
					SaturatedFatPer100g = 1.5F,
					FatsPer100g = 11.5F,
					ProteinsPer100g = 24.6F,
					VitaminAPer100g = 2,
					VitaminCPer100g = 0,
					VitaminDPer100g = 68,
					VitaminEPer100g = 10,
					VitaminKPer100g = 3,
					VitaminB1Per100g = 5,
					VitaminB2Per100g = 13,
					VitaminB3Per100g = 26,
					VitaminB6Per100g = 8,
					VitaminB9Per100g = 3,
					VitaminB12Per100g = 149,
					CalciumPer100g = 38,
					IronPer100g = 16,
					MagnesiumPer100g = 10,
					PhosphorusPer100g = 49,
					PotassiumPer100g = 11,
					SodiumPer100g = 21,
					ZincPer100g = 9,
					CopperPer100g = 9,
					ManganesePer100g = 5,
					SeleniumPer100g = 75,
				},
				new NutritionFood
				{
					Id = 13,
					FoodItemId = 13,
					CaloriesPer100g = 227,
					FiberPer100g = 0.0F,
					SugarPer100g = 0.0F,
					CarbohydratesPer100g = 0.0F,
					SaturatedFatPer100g = 4.6F,
					FatsPer100g = 12.1F,
					ProteinsPer100g = 27.6F,
					VitaminAPer100g = 0,
					VitaminCPer100g = 0,
					VitaminDPer100g = 0,
					VitaminEPer100g = 1,
					VitaminKPer100g = 0,
					VitaminB1Per100g = 28,
					VitaminB2Per100g = 22,
					VitaminB3Per100g = 18,
					VitaminB6Per100g = 24,
					VitaminB9Per100g = 0,
					VitaminB12Per100g = 16,
					CalciumPer100g = 3,
					IronPer100g = 10,
					MagnesiumPer100g = 5,
					PhosphorusPer100g = 23,
					PotassiumPer100g = 11,
					SodiumPer100g = 6,
					ZincPer100g = 32,
					CopperPer100g = 10,
					ManganesePer100g = 1,
					SeleniumPer100g = 65,
				},
				new NutritionFood
				{
					Id = 14,
					FoodItemId = 14,
					CaloriesPer100g = 145,
					FiberPer100g = 3.3F,
					SugarPer100g = 0.5F,
					CarbohydratesPer100g = 3.8F,
					SaturatedFatPer100g = 2.0F,
					FatsPer100g = 15.3F,
					ProteinsPer100g = 1.0F,
					VitaminAPer100g = 8,
					VitaminCPer100g = 0,
					VitaminDPer100g = 0,
					VitaminEPer100g = 19,
					VitaminKPer100g = 2,
					VitaminB1Per100g = 1,
					VitaminB2Per100g = 0,
					VitaminB3Per100g = 1,
					VitaminB6Per100g = 2,
					VitaminB9Per100g = 1,
					VitaminB12Per100g = 0,
					CalciumPer100g = 5,
					IronPer100g = 3,
					MagnesiumPer100g = 3,
					PhosphorusPer100g = 0,
					PotassiumPer100g = 1,
					SodiumPer100g = 65,
					ZincPer100g = 0,
					CopperPer100g = 6,
					ManganesePer100g = 0,
					SeleniumPer100g = 1,
				},
				new NutritionFood
				{
					Id = 15,
					FoodItemId = 15,
					CaloriesPer100g = 18,
					FiberPer100g = 1.2F,
					SugarPer100g = 2.6F,
					CarbohydratesPer100g = 3.9F,
					SaturatedFatPer100g = 0.0F,
					FatsPer100g = 0.2F,
					ProteinsPer100g = 0.9F,
					VitaminAPer100g = 17,
					VitaminCPer100g = 21,
					VitaminDPer100g = 0,
					VitaminEPer100g = 3,
					VitaminKPer100g = 10,
					VitaminB1Per100g = 2,
					VitaminB2Per100g = 1,
					VitaminB3Per100g = 3,
					VitaminB6Per100g = 4,
					VitaminB9Per100g = 4,
					VitaminB12Per100g = 0,
					CalciumPer100g = 1,
					IronPer100g = 1,
					MagnesiumPer100g = 3,
					PhosphorusPer100g = 2,
					PotassiumPer100g = 7,
					SodiumPer100g = 0,
					ZincPer100g = 1,
					CopperPer100g = 3,
					ManganesePer100g = 6,
					SeleniumPer100g = 0,
				},
				new NutritionFood
				{
					Id = 16,
					FoodItemId = 16,
					CaloriesPer100g = 40,
					FiberPer100g = 1.7F,
					SugarPer100g = 4.2F,
					CarbohydratesPer100g = 9.3F,
					SaturatedFatPer100g = 0.0F,
					FatsPer100g = 0.1F,
					ProteinsPer100g = 1.1F,
					VitaminAPer100g = 0,
					VitaminCPer100g = 12,
					VitaminDPer100g = 0,
					VitaminEPer100g = 0,
					VitaminKPer100g = 0,
					VitaminB1Per100g = 3,
					VitaminB2Per100g = 2,
					VitaminB3Per100g = 1,
					VitaminB6Per100g = 6,
					VitaminB9Per100g = 5,
					VitaminB12Per100g = 0,
					CalciumPer100g = 2,
					IronPer100g = 1,
					MagnesiumPer100g = 2,
					PhosphorusPer100g = 3,
					PotassiumPer100g = 4,
					SodiumPer100g = 0,
					ZincPer100g = 1,
					CopperPer100g = 2,
					ManganesePer100g = 6,
					SeleniumPer100g = 1,
				},
				new NutritionFood
				{
					Id = 17,
					FoodItemId = 17,
					CaloriesPer100g = 131,
					FiberPer100g = 0.0F,
					SugarPer100g = 0.0F,
					CarbohydratesPer100g = 24.9F,
					SaturatedFatPer100g = 0.2F,
					FatsPer100g = 1.1F,
					ProteinsPer100g = 5.2F,
					VitaminAPer100g = 0,
					VitaminCPer100g = 0,
					VitaminDPer100g = 0,
					VitaminEPer100g = 0,
					VitaminKPer100g = 0,
					VitaminB1Per100g = 14,
					VitaminB2Per100g = 9,
					VitaminB3Per100g = 5,
					VitaminB6Per100g = 2,
					VitaminB9Per100g = 16,
					VitaminB12Per100g = 2,
					CalciumPer100g = 1,
					IronPer100g = 6,
					MagnesiumPer100g = 5,
					PhosphorusPer100g = 6,
					PotassiumPer100g = 1,
					SodiumPer100g = 0,
					ZincPer100g = 4,
					CopperPer100g = 5,
					ManganesePer100g = 11,
					SeleniumPer100g = 0,
				},
				new NutritionFood
				{
					Id = 18,
					FoodItemId = 18,
					CaloriesPer100g = 225,
					FiberPer100g = 6.4F,
					SugarPer100g = 0.3F,
					CarbohydratesPer100g = 22.8F,
					SaturatedFatPer100g = 0.1F,
					FatsPer100g = 0.5F,
					ProteinsPer100g = 8.7F,
					VitaminAPer100g = 0,
					VitaminCPer100g = 2,
					VitaminDPer100g = 0,
					VitaminEPer100g = 0,
					VitaminKPer100g = 10,
					VitaminB1Per100g = 11,
					VitaminB2Per100g = 3,
					VitaminB3Per100g = 3,
					VitaminB6Per100g = 6,
					VitaminB9Per100g = 33,
					VitaminB12Per100g = 0,
					CalciumPer100g = 4,
					IronPer100g = 12,
					MagnesiumPer100g = 10,
					PhosphorusPer100g = 14,
					PotassiumPer100g = 12,
					SodiumPer100g = 0,
					ZincPer100g = 7,
					CopperPer100g = 12,
					ManganesePer100g = 22,
					SeleniumPer100g = 2,
				},
				new NutritionFood
				{
					Id = 19,
					FoodItemId = 19,
					CaloriesPer100g = 60,
					FiberPer100g = 0.0F,
					SugarPer100g = 0.0F,
					CarbohydratesPer100g = 5.3F,
					SaturatedFatPer100g = 1.9F,
					FatsPer100g = 3.3F,
					ProteinsPer100g = 3.2F,
					VitaminAPer100g = 2,
					VitaminCPer100g = 0,
					VitaminDPer100g = 10,
					VitaminEPer100g = 0,
					VitaminKPer100g = 0,
					VitaminB1Per100g = 3,
					VitaminB2Per100g = 11,
					VitaminB3Per100g = 1,
					VitaminB6Per100g = 2,
					VitaminB9Per100g = 1,
					VitaminB12Per100g = 7,
					CalciumPer100g = 11,
					IronPer100g = 0,
					MagnesiumPer100g = 2,
					PhosphorusPer100g = 9,
					PotassiumPer100g = 4,
					SodiumPer100g = 2,
					ZincPer100g = 3,
					CopperPer100g = 1,
					ManganesePer100g = 0,
					SeleniumPer100g = 5,
				},
				new NutritionFood
				{
					Id = 20,
					FoodItemId = 20,
					CaloriesPer100g = 35,
					FiberPer100g = 2.2F,
					SugarPer100g = 0.0F,
					CarbohydratesPer100g = 4.9F,
					SaturatedFatPer100g = 0.1F,
					FatsPer100g = 0.7F,
					ProteinsPer100g = 4.3F,
					VitaminAPer100g = 0,
					VitaminCPer100g = 0,
					VitaminDPer100g = 0,
					VitaminEPer100g = 0,
					VitaminKPer100g = 0,
					VitaminB1Per100g = 6,
					VitaminB2Per100g = 28,
					VitaminB3Per100g = 30,
					VitaminB6Per100g = 4,
					VitaminB9Per100g = 5,
					VitaminB12Per100g = 0,
					CalciumPer100g = 0,
					IronPer100g = 3,
					MagnesiumPer100g = 4,
					PhosphorusPer100g = 15,
					PotassiumPer100g = 15,
					SodiumPer100g = 0,
					ZincPer100g = 5,
					CopperPer100g = 25,
					ManganesePer100g = 4,
					SeleniumPer100g = 25,
				}

			};
		}

	}
}
