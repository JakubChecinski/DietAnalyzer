using DietAnalyzer.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Models.ViewModels
{
    // for now, a trivial encapsulation class
    // mostly here for symmetry and to make modifications easier in the future
    public class RestrictionViewModel
    {
        public RestrictionUser RestrictionInfo { get; set; }
    }
}
