using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Services.Utilities
{
    /// <summary>
    /// 
    /// A utility service used to fill new user accounts with data examples
    ///
    /// </summary>
    public interface IExampleDataService
    {
        /// <summary>
        /// Call this method to create example data and link it to the registered user's account
        /// </summary>
        /// <param name="userId"> is the registered user ID</param>
        Task InsertExampleDataAsync(string userId);
    }
}
