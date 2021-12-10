using DietAnalyzer.Models.Domains;
using DietAnalyzer.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Data.Repositories
{
    /// <summary>
    /// 
    /// A repository for FoodItems
    /// Methods: get foods, get foods filtered by restrictions, get only custom (non-library) foods, 
    /// get only custom AND filtered foods, get a single food, add, update, delete
    /// 
    /// </summary>
    public interface IFoodItemRepository
    {
        IEnumerable<FoodItem> Get(string userId);
        IEnumerable<FoodItem> Get(string userId, RestrictionUser restrictions);
        IEnumerable<FoodItem> GetCustom(string userId);
        IEnumerable<FoodItem> GetCustom(string userId, RestrictionUser restrictions);
        FoodItem Get(string userId, int foodId);
        void Add(FoodItem food);
        void Update(FoodItem food, string userId);
        void Delete(int foodId, string userId);
    }
}
