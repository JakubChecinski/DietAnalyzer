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
    /// A repository for Diets
    /// Methods: get all diets for the current user, get a single diet, get a single diet with dependences,
    /// add, update, delete
    /// 
    /// </summary>
    public interface IDietRepository
    {
        IEnumerable<Diet> Get(string userId);
        Diet Get(string userId, int dietId);
        Diet GetWithDietItemChildren(string userId, int dietId);
        void Add(Diet diet);
        void Update(Diet diet, string userId);
        void Delete(int dietId, string userId);

    }
}
