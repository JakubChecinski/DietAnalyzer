using DietAnalyzer.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Data
{
    public static partial class FoodSeeder
    {
		private static RestrictionFood[] ConstructFoodRestrictions()
		{
			return new RestrictionFood[]
			{
				new RestrictionFood()
				{
					Id = 1,
					FoodItemId = 1,
					Pescetarian = true,
					Vegetarian = true,
					Vegan = true,
					DairyIntolerant = true,
					GlutenIntolerant = true,
					Paleo = true,
					Keto = true,
					Diabetes = true,
					HeartProblems = true,
					KidneyProblems = false,
				},
				new RestrictionFood()
				{
					Id = 2,
					FoodItemId = 2,
					Pescetarian = true,
					Vegetarian = true,
					Vegan = true,
					DairyIntolerant = true,
					GlutenIntolerant = true,
					Paleo = true,
					Keto = false,
					Diabetes = true,
					HeartProblems = true,
					KidneyProblems = false,
				},
				new RestrictionFood()
				{
					Id = 3,
					FoodItemId = 3,
					Pescetarian = true,
					Vegetarian = true,
					Vegan = false,
					DairyIntolerant = true,
					GlutenIntolerant = true,
					Paleo = true,
					Keto = true,
					Diabetes = true,
					HeartProblems = false,
					KidneyProblems = true,
				},
				new RestrictionFood()
				{
					Id = 4,
					FoodItemId = 4,
					Pescetarian = true,
					Vegetarian = true,
					Vegan = false,
					DairyIntolerant = false,
					GlutenIntolerant = true,
					Paleo = false,
					Keto = true,
					Diabetes = true,
					HeartProblems = true,
					KidneyProblems = true,
				},
				new RestrictionFood()
				{
					Id = 5,
					FoodItemId = 5,
					Pescetarian = false,
					Vegetarian = false,
					Vegan = false,
					DairyIntolerant = false,
					GlutenIntolerant = true,
					Paleo = true,
					Keto = true,
					Diabetes = true,
					HeartProblems = true,
					KidneyProblems = true,
				},
				new RestrictionFood()
				{
					Id = 6,
					FoodItemId = 6,
					Pescetarian = true,
					Vegetarian = false,
					Vegan = false,
					DairyIntolerant = true,
					GlutenIntolerant = true,
					Paleo = true,
					Keto = true,
					Diabetes = true,
					HeartProblems = true,
					KidneyProblems = true,
				},
				new RestrictionFood()
				{
					Id = 7,
					FoodItemId = 7,
					Pescetarian = true,
					Vegetarian = true,
					Vegan = true,
					DairyIntolerant = true,
					GlutenIntolerant = false,
					Paleo = false,
					Keto = false,
					Diabetes = true,
					HeartProblems = true,
					KidneyProblems = false,
				},
				new RestrictionFood()
				{
					Id = 8,
					FoodItemId = 8,
					Pescetarian = true,
					Vegetarian = true,
					Vegan = true,
					DairyIntolerant = true,
					GlutenIntolerant = true,
					Paleo = false,
					Keto = false,
					Diabetes = false,
					HeartProblems = true,
					KidneyProblems = false,
				}
			};
		}

	}
}
