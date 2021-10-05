using DietAnalyzer.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Services
{
    public interface IRestrictionService
    {
        RestrictionsInfo Get(string userId);
        void Update(RestrictionsInfo restriction);
    }
}
