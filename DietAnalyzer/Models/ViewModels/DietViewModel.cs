﻿using DietAnalyzer.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Models.ViewModels
{
    public class DietViewModel
    {
        public bool IsAdd { get; set; }
        public Diet Diet { get; set; }
        public IEnumerable<FoodItem> AvailableFoods { get; set; }
    }
}
