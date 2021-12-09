using DietAnalyzer.Models.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Data
{

	/// See DataSeeder.cs for more comments on data seeding classes

	public static partial class FoodSeeder
    {
		public static void Seed(ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<FoodItem>().HasData(ConstructFoods());
			modelBuilder.Entity<NutritionFood>().HasData(ConstructFoodNutritions());
			modelBuilder.Entity<RestrictionFood>().HasData(ConstructFoodRestrictions());
		}

		private static FoodItem[] ConstructFoods()
        {
			return new FoodItem[] 
			{
				new FoodItem()
				{
					Id = 1,
					Name = "spinach",
					ImageFromApp = "/images/spinach.png",
				},
				new FoodItem()
				{
					Id = 2,
					Name = "bananas",
				},
				new FoodItem()
				{
					Id = 3,
					Name = "eggs",
					ImageFromApp = "/images/eggs.png",
				},
				new FoodItem()
				{
					Id = 4,
					Name = "yogurt",
				},
				new FoodItem()
				{
					Id = 5,
					Name = "chicken breast",
				},
				new FoodItem()
				{
					Id = 6,
					Name = "salmon",
				},
				new FoodItem()
				{
					Id = 7,
					Name = "bread (rye)",
				},
				new FoodItem()
				{
					Id = 8,
					Name = "potatoes",
				}
			};
		}


	}
}
