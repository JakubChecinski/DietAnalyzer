using DietAnalyzer.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Models.Repositories
{
    public interface IRestrictionRepository
    {
        RestrictionsInfo Get(string userId);
        void Add(RestrictionsInfo restriction);
        void Update(RestrictionsInfo restriction);
    }
}
