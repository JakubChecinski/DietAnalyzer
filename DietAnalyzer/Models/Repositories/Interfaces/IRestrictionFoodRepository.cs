using DietAnalyzer.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Models.Repositories
{
    public interface IRestrictionFoodRepository
    {
        void Add(RestrictionFood restriction);
        void Update(RestrictionFood restriction);
    }
}
