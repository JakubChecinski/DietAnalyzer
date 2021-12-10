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
    /// A repository for Measures
    /// Methods: get measures, get a single measure, get only custom (non-library) measures,
    /// add, update, delete
    /// 
    /// </summary>
    public interface IMeasureRepository
    {
        IEnumerable<Measure> Get(string userId);
        Measure Get(int measureId);
        IEnumerable<Measure> GetCustom(string userId);
        void Add(Measure measure);
        void Update(Measure measure, string userId);
        void Delete(int measureId, string userId);
    }
}
