using DietAnalyzer.Models.Domains;
using System.Collections.Generic;

namespace DietAnalyzer.Data.Repositories
{
    /// <summary>
    /// 
    /// A repository for DietItems
    /// Methods: get, add, delete
    /// 
    /// </summary>
    public interface IDietItemRepository
    {
        IEnumerable<DietItem> Get(int dietId);
        void Add(DietItem dietItem);
        void Delete(DietItem dietItem);
    }
}
