using DietAnalyzer.Models.Domains;
using DietAnalyzer.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Services
{
    public interface IDietService
    {
        IEnumerable<Diet> Get(string userId);
        IEnumerable<int> GetIncompatibleDietIds(string userId);
        Diet Get(string userId, int dietId);
        Diet GetWithDietItemChildren(string userId, int dietId);
        Diet PrepareNewDiet(string userId);
        void Add(Diet diet);
        void Update(Diet diet, string userId, bool updateItems = true);
        void Delete(int dietId, string userId);
    }
}
