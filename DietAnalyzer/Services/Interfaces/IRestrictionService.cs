using DietAnalyzer.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Services
{
    public interface IRestrictionService
    {
        RestrictionUser Get(string userId);
        void Update(RestrictionUser restriction);
    }
}
