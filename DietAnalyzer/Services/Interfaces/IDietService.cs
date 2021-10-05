using DietAnalyzer.Models.Domains;
using DietAnalyzer.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Services
{
    public interface IDietService
    {
        IEnumerable<DietViewModel> Get(string userId);
        IEnumerable<DietViewModel> Get(string userId, string dietName);
        Diet Get(string userId, int dietId);
        void Add(Diet diet);
        void Update(Diet diet, string userId);
        void Delete(int dietId, string userId);
    }
}
