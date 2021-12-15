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
					ImageFromApp = "/images/bananas.png",
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
					ImageFromApp = "/images/yogurt.png",
				},
				new FoodItem()
				{
					Id = 5,
					Name = "chicken breast",
					ImageFromApp = "/images/chicken_breast.png",
				},
				new FoodItem()
				{
					Id = 6,
					Name = "salmon",
					ImageFromApp = "/images/salmon.png",
				},
				new FoodItem()
				{
					Id = 7,
					Name = "bread (rye)",
					ImageFromApp = "/images/bread_rye.png",
				},
				new FoodItem()
				{
					Id = 8,
					Name = "potatoes",
					ImageFromApp = "/images/potatoes.png",
				},
				new FoodItem()
				{
					Id = 9,
					Name = "cheese",
					ImageFromApp = "/images/cheese.png",
				},
				new FoodItem()
				{
					Id = 10,
					Name = "chocolate",
					ImageFromApp = "/images/chocolate.png",
				},
				new FoodItem()
				{
					Id = 11,
					Name = "bread (wheat)",
					ImageFromApp = "/images/bread_wheat.png",
				},
				new FoodItem()
				{
					Id = 12,
					Name = "sardines",
					ImageFromApp = "/images/sardines.png",
				},
				new FoodItem()
				{
					Id = 13,
					Name = "pork steak",
					ImageFromApp = "/images/steak.png",
				},
				new FoodItem()
				{
					Id = 14,
					Name = "olives",
					ImageFromApp = "/images/olives.png",
				},
				new FoodItem()
				{
					Id = 15,
					Name = "tomatoes",
					ImageFromApp = "/images/tomato.png",
				},
				new FoodItem()
				{
					Id = 16,
					Name = "onions",
					ImageFromApp = "/images/onion.png",
				},
				new FoodItem()
				{
					Id = 17,
					Name = "pasta",
					ImageFromApp = "/images/pasta.png",
				},
				new FoodItem()
				{
					Id = 18,
					Name = "kidney beans",
					ImageFromApp = "/images/kidney_beans.png",
				},
				new FoodItem()
				{
					Id = 19,
					Name = "milk",
					ImageFromApp = "/images/milk.png",
				},
				new FoodItem()
				{
					Id = 20,
					Name = "mushrooms",
					ImageFromApp = "/images/mushrooms.png",
				},
			};
		}


	}
}
