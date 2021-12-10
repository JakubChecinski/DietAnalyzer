﻿using DietAnalyzer.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Data.Repositories
{
    /// <summary>
    /// 
    /// A repository for USER Restriction tables. Don't call it for Restriction tables used in foods. 
    /// Methods: get, add, update
    /// 
    /// </summary>
    public interface IRestrictionUserRepository
    {
        RestrictionUser Get(string userId);
        void Add(RestrictionUser restriction);
        void Update(RestrictionUser restriction);
    }
}
