﻿using DietAnalyzer.Models.Domains;
using DietAnalyzer.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Models.Repositories
{
    public interface IDietRepository
    {
        IEnumerable<Diet> Get(string userId);
        Diet Get(string userId, int dietId);
        void Add(Diet diet);
        void Update(Diet diet, string userId);
        void Delete(int dietId, string userId);

    }
}
