using DietAnalyzer.Models.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Data
{
    public interface IApplicationDbContext
    {
        DbSet<ApplicationUser> ApplicationUsers { get; set; }
        DbSet<Diet> Diets { get; set; }
        DbSet<DietItem> DietItems { get; set; }
        DbSet<EvaluationResult> EvaluationResults { get; set; }
        DbSet<FoodItem> FoodItems { get; set; }
        DbSet<Measure> Measures { get; set; }
        DbSet<FoodMeasure> FoodMeasures { get; set; }
        DbSet<NutritionFood> NutritionFoods { get; set; }
        DbSet<NutritionDiet> NutritionDiets { get; set; }
        DbSet<RestrictionFood> RestrictionsFoods { get; set; }
        DbSet<RestrictionUser> RestrictionsUsers { get; set; }
        int SaveChanges();
    }
}
