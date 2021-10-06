using DietAnalyzer.Models.Domains;
using DietAnalyzer.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Services
{
    public interface IMeasureService
    {
        IEnumerable<Measure> Get(string userId);
        void Update(IEnumerable<Measure> measures, string userId);
    }
}
