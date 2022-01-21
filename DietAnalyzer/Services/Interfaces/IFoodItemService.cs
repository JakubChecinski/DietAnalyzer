using DietAnalyzer.Models.Domains;
using DietAnalyzer.Models.ViewModels;
using System;
using System.Collections.Generic;

namespace DietAnalyzer.Services
{
    /// <summary>
    /// 
    /// A service for FoodItems 
    ///
    /// </summary>
    public interface IFoodItemService
    {
        /// <summary>
        /// Get the list of all food items
        /// </summary>
        /// <param name="userId"> is the current user ID</param>
        /// <param name="suitableOnly"> is a bool parameter. 
        /// If true, the foods will be filtered accordingly to user's dietary restrictions.</param>
        /// <returns>The list of all food items available for the current user, 
        /// filtered or unfiltered by the user's dietary restrictions.</returns>
        IEnumerable<FoodItem> Get(string userId, bool suitableOnly = false);

        /// <summary>
        /// Get the list of all food item that have been defined by the current user
        /// </summary>
        /// <param name="userId"> is the current user ID</param>
        /// <param name="suitableOnly"> is a bool parameter. 
        /// If true, the foods will be filtered accordingly to user's dietary restrictions.</param>
        /// <returns>The list of all user-defined foods available to the current user, 
        /// filtered or unfiltered by the user's dietary restrictions. 
        /// Library (pre-defined) measures are not included.</returns>
        IEnumerable<FoodItem> GetCustom(string userId, bool suitableOnly = false);

        /// <summary>
        /// A helper method that reads and processes available measures during food creation/edition
        /// </summary>
        /// <param name="userId"> is the current user ID</param>
        /// <param name="foodId"> is the food ID</param>
        /// <returns>A list of Tuples, where the first element is the measure ID 
        /// and the second element is the measure name. 
        /// The included measures are those which are available for the given food.</returns>
        List<Tuple<int, string>> PrepareMeasuresForFood(string userId, int foodId);

        /// <summary>
        /// A helper method that reads and processes available measures during food creation/edition
        /// </summary>
        /// <param name="userId"> is the current user ID</param>
        /// <param name="fromDietItems"> is the collection of DietItem objects that need measures to be prepared</param>
        /// <returns>A list of list of Tuples, where the first element is the measure ID 
        /// and the second element is the measure name. 
        /// The outer list includes one element for each input DietItem.
        /// The inner lists include all measures available for the FoodItem inside this DietItem.</returns>
        List<List<Tuple<int, string>>> PrepareMeasuresForFoods(string userId,
            ICollection<DietItem> fromDietItems);

        /// <summary>
        /// Get a single food item
        /// </summary>
        /// <param name="userId"> is the current user ID</param>
        /// <param name="foodId"> is the food ID</param>
        /// <returns>A FoodItem object corresponding to the given ID,
        /// as long as it's accessible to the current user.</returns>
        FoodItem Get(string userId, int foodId);

        /// <summary>
        /// A helper method to prepare a new FoodItem template 
        /// </summary>
        /// <param name="userId"> is the current user ID</param>
        /// <returns>The prepared FoodItem object, ready to be edited.</returns>
        FoodItem PrepareNewFood(string userId);

        /// <summary>
        /// Add new FoodItem to database
        /// </summary>
        /// <param name="food"> is the FoodItem to add</param>
        void Add(FoodItem food);

        /// <summary>
        /// Update an existing FoodItem in database
        /// </summary>
        /// <param name="food"> is the FoodItem</param>
        /// <param name="userId"> is the current user ID</param>
        void Update(FoodItem food, string userId);

        /// <summary>
        /// Delete an existing FoodItem from database
        /// </summary>
        /// <param name="foodId"> is the FoodItem</param>
        /// <param name="userId"> is the current user ID</param>
        void Delete(int foodId, string userId);

        /// <summary>
        /// Utility method to post-process the FoodItemViewModel and reassign food item data
        /// </summary>
        /// <param name="vm"> is the viewModel to post-process</param>
        /// /// <param name="userId"> is the current user ID</param>
        void AssignFoodItemData(FoodItemViewModel vm, string userId);

    }
}
