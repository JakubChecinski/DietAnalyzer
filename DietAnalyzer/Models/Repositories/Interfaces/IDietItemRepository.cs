using DietAnalyzer.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Models.Repositories
{
    public interface IDietItemRepository
    {
        IEnumerable<DietItem> Get(int dietId);
        void Add(DietItem dietItem);
        void Delete(DietItem dietItem);
    }
}
