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
        DbSet<FoodDietRecommendation> FoodDietRecommendations { get; set; }
        DbSet<FoodItem> FoodItems { get; set; }
        DbSet<Measure> Measures { get; set; }
        DbSet<NutritionInfo> NutritionInfos { get; set; }
        DbSet<RestrictionsInfo> RestrictionsInfos { get; set; }
        int SaveChanges();
    }
}
