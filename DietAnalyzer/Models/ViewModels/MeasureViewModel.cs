using DietAnalyzer.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Models.ViewModels
{
    public class MeasureViewModel
    {
        public IEnumerable<Measure> Measures { get; set; }
    }
}
