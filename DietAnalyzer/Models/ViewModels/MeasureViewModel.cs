using DietAnalyzer.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Models.ViewModels
{
    public class MeasureViewModel
    {
        public List<Measure> Measures { get; set; }
        public string PositionsToDelete { get; set; }

    }
}
