using DietAnalyzer.Models.Domains;
using DietAnalyzer.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Data.Repositories
{
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
