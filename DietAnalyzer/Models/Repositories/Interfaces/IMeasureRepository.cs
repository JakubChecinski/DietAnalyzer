using DietAnalyzer.Models.Domains;
using DietAnalyzer.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Models.Repositories
{
    public interface IMeasureRepository
    {
        IEnumerable<Measure> Get(string userId);
        IEnumerable<Measure> GetCustom(string userId);
        void Add(Measure measure);
        void Delete(int measureId, string userId);
    }
}
