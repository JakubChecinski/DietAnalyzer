using DietAnalyzer.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Data.Repositories
{
    public interface IRestrictionRepository
    {
        void Add(RestrictionsInfo restriction);
        void Update(RestrictionsInfo restriction);
    }
}
