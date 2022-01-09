using DietAnalyzer.Models.Domains;
using DietAnalyzer.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Services
{
    /// <summary>
    /// 
    /// A service for Diets 
    ///
    /// </summary>
    public interface IDietService
    {
        /// <summary>
        /// Get the list of all diets
        /// </summary>
        /// <param name="userId"> is the current user ID</param>
        /// <returns>The list of all diets available for the current user</returns>
        IEnumerable<Diet> Get(string userId);

        /// <summary>
        /// Get IDs of all diets which violate user's dietary restrictions 
        /// </summary>
        /// <param name="userId"> is the current user ID</param>
        /// <returns>The list with IDs of all diets violating the current user's dietary restrictions.
        /// Only the diets available to the current user are considered.</returns>
        IEnumerable<int> GetIncompatibleDietIds(string userId);

        /// <summary>
        /// Get a single diet
        /// </summary>
        /// <param name="userId"> is the current user ID</param>
        /// <param name="dietId"> is the diet ID</param>
        /// <returns>A Diet object corresponding to the given ID,
        /// as long as it's accessible to the current user. Nested dependencies are not included.</returns>
        Diet Get(string userId, int dietId);

        /// <summary>
        /// Get a single diet with dependent objects
        /// </summary>
        /// <param name="userId"> is the current user ID</param>
        /// <param name="dietId"> is the diet ID</param>
        /// <returns>A Diet object corresponding to the given ID,
        /// as long as it's accessible to the current user. 
        /// Includes some nested dependencies such as nutrition tables for each DietItem food.</returns>
        Diet GetWithDietItemChildren(string userId, int dietId);

        /// <summary>
        /// A helper method to prepare a new Diet template 
        /// </summary>
        /// <param name="userId"> is the current user ID</param>
        /// <returns>The prepared Diet object, ready to be edited.</returns>
        Diet PrepareNewDiet(string userId);

        /// <summary>
        /// Add new Diet to database
        /// </summary>
        /// <param name="diet"> is the Diet to add</param>
        void Add(Diet diet);

        /// <summary>
        /// Update an existing Diet in database
        /// </summary>
        /// <param name="diet"> is the Diet to update</param>
        /// <param name="userId"> is the current user ID</param>
        /// <param name="updateItems"> is a bool parameter. 
        /// If true, DietItems belonging to the current Diet will also be updated.
        /// If false, any changes in DietItems will be ignored.</param>
        void Update(Diet diet, string userId, bool updateItems = true);

        /// <summary>
        /// Delete an existing Diet from database
        /// </summary>
        /// <param name="dietId"> is the ID of the diet to delete</param>
        /// <param name="userId"> is the current user ID</param>
        void Delete(int dietId, string userId);

        /// <summary>
        /// Utility method to post-process the DietViewModel and reassign diet items
        /// </summary>
        /// <param name="vm"> is the viewModel to post-process</param>
        void AssignDietItems(DietViewModel vm);
    }
}
