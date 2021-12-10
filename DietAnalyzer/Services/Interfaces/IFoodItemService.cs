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
        IEnumerable<FoodItem> Get(string userId, bool suitableOnly = false);
        IEnumerable<FoodItem> GetCustom(string userId, bool suitableOnly = false);
        List<Tuple<int, string>> PrepareMeasuresForFood(string userId, int foodId);
        List<List<Tuple<int, string>>> PrepareMeasuresForFoods(string userId, 
            ICollection<DietItem> fromDietItems);
        FoodItem Get(string userId, int foodId);
        FoodItem PrepareNewFood(string userId);
        void Add(FoodItem food);
        void Update(FoodItem food, string userId);
        void Delete(int foodId, string userId);
    }
}
