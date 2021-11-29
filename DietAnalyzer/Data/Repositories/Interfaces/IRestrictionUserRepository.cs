using DietAnalyzer.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Data.Repositories
{
    public interface IRestrictionUserRepository
    {
        RestrictionUser Get(string userId);
        void Add(RestrictionUser restriction);
        void Update(RestrictionUser restriction);
    }
}
