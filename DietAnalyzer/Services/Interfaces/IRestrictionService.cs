using DietAnalyzer.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Services
{
    /// <summary>
    /// 
    /// A service for Restrictions 
    ///
    /// </summary>
    public interface IRestrictionService
    {
        /// <summary>
        /// Get restrictions for the current user
        /// </summary>
        /// <param name="userId"> is the current user ID</param>
        /// <returns>A class containing all user restrictions.</returns>
        RestrictionUser Get(string userId);

        /// <summary>
        /// Update restrictions for the current user
        /// </summary>
        /// <param name="restriction"> is the table of restrictions to update</param>
        void Update(RestrictionUser restriction);
    }
}
