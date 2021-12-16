using DietAnalyzer.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Data.Repositories
{
    /// <summary>
    /// 
    /// A repository for Restriction tables used in FOODS. Don't call it for user Restriction tables. 
    /// Methods: add, update
    /// 
    /// </summary>
    public interface IRestrictionFoodRepository
    {
        void Add(RestrictionFood restriction);
        Task AddAsync(RestrictionFood restriction);
        void Update(RestrictionFood restriction);
    }
}
