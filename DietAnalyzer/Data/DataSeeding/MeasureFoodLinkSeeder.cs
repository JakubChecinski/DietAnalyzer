using DietAnalyzer.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Data
{

	/// See DataSeeder.cs for more comments on data seeding classes

	public static partial class MeasureSeeder
    {
		private static FoodMeasure[] ConstructFoodMeasures()
		{
			return new FoodMeasure[]
			{

				// grams

				new FoodMeasure
				{
					Id = 1,
					IsCurrentlyLinked = true,
					MeasureId = 1,
					FoodItemId = 1,
				},
				new FoodMeasure
				{
					Id = 2,
					IsCurrentlyLinked = true,
					MeasureId = 1,
					FoodItemId = 2,
				},
				new FoodMeasure
				{
					Id = 3,
					IsCurrentlyLinked = true,
					MeasureId = 1,
					FoodItemId = 3,
				},
				new FoodMeasure
				{
					Id = 4,
					IsCurrentlyLinked = true,
					MeasureId = 1,
					FoodItemId = 4,
				},
				new FoodMeasure
				{
					Id = 5,
					IsCurrentlyLinked = true,
					MeasureId = 1,
					FoodItemId = 5,
				},
				new FoodMeasure
				{
					Id = 6,
					IsCurrentlyLinked = true,
					MeasureId = 1,
					FoodItemId = 6,
				},
				new FoodMeasure
				{
					Id = 7,
					IsCurrentlyLinked = true,
					MeasureId = 1,
					FoodItemId = 7,
				},
				new FoodMeasure
				{
					Id = 8,
					IsCurrentlyLinked = true,
					MeasureId = 1,
					FoodItemId = 8,
				},
				new FoodMeasure
				{
					Id = 109,
					IsCurrentlyLinked = true,
					MeasureId = 1,
					FoodItemId = 9,
				},
				new FoodMeasure
				{
					Id = 110,
					IsCurrentlyLinked = true,
					MeasureId = 1,
					FoodItemId = 10,
				},
				new FoodMeasure
				{
					Id = 111,
					IsCurrentlyLinked = true,
					MeasureId = 1,
					FoodItemId = 11,
				},
				new FoodMeasure
				{
					Id = 112,
					IsCurrentlyLinked = true,
					MeasureId = 1,
					FoodItemId = 12,
				},
				new FoodMeasure
				{
					Id = 113,
					IsCurrentlyLinked = true,
					MeasureId = 1,
					FoodItemId = 13,
				},
				new FoodMeasure
				{
					Id = 114,
					IsCurrentlyLinked = true,
					MeasureId = 1,
					FoodItemId = 14,
				},
				new FoodMeasure
				{
					Id = 115,
					IsCurrentlyLinked = true,
					MeasureId = 1,
					FoodItemId = 15,
				},
				new FoodMeasure
				{
					Id = 116,
					IsCurrentlyLinked = true,
					MeasureId = 1,
					FoodItemId = 16,
				},
				new FoodMeasure
				{
					Id = 117,
					IsCurrentlyLinked = true,
					MeasureId = 1,
					FoodItemId = 17,
				},
				new FoodMeasure
				{
					Id = 118,
					IsCurrentlyLinked = true,
					MeasureId = 1,
					FoodItemId = 18,
				},
				new FoodMeasure
				{
					Id = 119,
					IsCurrentlyLinked = true,
					MeasureId = 1,
					FoodItemId = 19,
				},
				new FoodMeasure
				{
					Id = 120,
					IsCurrentlyLinked = true,
					MeasureId = 1,
					FoodItemId = 20,
				},

				// other measures

				new FoodMeasure
				{
					Id = 10,
					IsCurrentlyLinked = true,
					MeasureId = 2,
					FoodItemId = 2,
				},
				new FoodMeasure
				{
					Id = 19,
					IsCurrentlyLinked = true,
					MeasureId = 3,
					FoodItemId = 3,
				},
				new FoodMeasure
				{
					Id = 31,
					IsCurrentlyLinked = true,
					MeasureId = 4,
					FoodItemId = 7,
				},
				new FoodMeasure
				{
					Id = 200,
					IsCurrentlyLinked = true,
					MeasureId = 4,
					FoodItemId = 11,
				},
				new FoodMeasure
				{
					Id = 201,
					IsCurrentlyLinked = true,
					MeasureId = 5,
					FoodItemId = 12,
				},
				new FoodMeasure
				{
					Id = 202,
					IsCurrentlyLinked = true,
					MeasureId = 6,
					FoodItemId = 15,
				},
				new FoodMeasure
				{
					Id = 203,
					IsCurrentlyLinked = true,
					MeasureId = 7,
					FoodItemId = 16,
				}
			};
		}
	}
}
