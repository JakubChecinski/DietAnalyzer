﻿using DietAnalyzer.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Models.Repositories
{
    public interface INutritionDietRepository
    {
        void Add(NutritionDiet nutrition);
        void Update(NutritionDiet nutrition);
    }
}
