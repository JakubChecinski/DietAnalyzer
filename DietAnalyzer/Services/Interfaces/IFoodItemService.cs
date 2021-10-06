using DietAnalyzer.Models.Domains;
using DietAnalyzer.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Services
{
    public interface IFoodItemService
    {
        IEnumerable<FoodItem> Get(string userId);
        FoodItem Get(string userId, int foodId);
        void Add(FoodItem food);
        void Update(FoodItem food, string userId);
        void Delete(int foodId, string userId);
    }
}
