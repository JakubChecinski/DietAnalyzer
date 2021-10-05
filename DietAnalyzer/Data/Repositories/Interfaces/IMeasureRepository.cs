﻿using DietAnalyzer.Models.Domains;
using DietAnalyzer.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Data.Repositories
{
    public interface IMeasureRepository
    {
        IEnumerable<MeasureViewModel> Get(string userId);
        Measure Get(string userId, int measureId);
        void Add(Measure measure);
        void Update(Measure measure, string userId);
        void Delete(int measureId, string userId);
    }
}
