using DietAnalyzer.Models.Domains;
using System.Linq;

namespace DietAnalyzer.Data.Repositories
{
    /// <summary>
    /// 
    /// Standard implementation of INutritionDietRepository
    /// 
    /// </summary>
    public class NutritionDietRepository : INutritionDietRepository
    {
        private IApplicationDbContext _context;
        public NutritionDietRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(NutritionDiet nutrition)
        {
            _context.NutritionDiets.Add(nutrition);
        }
        public void Update(NutritionDiet nutrition)
        {
            var nutritionToUpdate = _context.NutritionDiets.Single(x => x.Id == nutrition.Id);
            nutritionToUpdate.CaloriesPer100g = nutrition.CaloriesPer100g;
            nutritionToUpdate.FiberPer100g = nutrition.FiberPer100g;
            nutritionToUpdate.SugarPer100g = nutrition.SugarPer100g;
            nutritionToUpdate.CarbohydratesPer100g = nutrition.CarbohydratesPer100g;
            nutritionToUpdate.SaturatedFatPer100g = nutrition.SaturatedFatPer100g;
            nutritionToUpdate.FatsPer100g = nutrition.FatsPer100g;
            nutritionToUpdate.ProteinsPer100g = nutrition.ProteinsPer100g;
            nutritionToUpdate.VitaminAPer100g = nutrition.VitaminAPer100g;
            nutritionToUpdate.VitaminCPer100g = nutrition.VitaminCPer100g;
            nutritionToUpdate.VitaminDPer100g = nutrition.VitaminDPer100g;
            nutritionToUpdate.VitaminEPer100g = nutrition.VitaminEPer100g;
            nutritionToUpdate.VitaminKPer100g = nutrition.VitaminKPer100g;
            nutritionToUpdate.VitaminB1Per100g = nutrition.VitaminB1Per100g;
            nutritionToUpdate.VitaminB2Per100g = nutrition.VitaminB2Per100g;
            nutritionToUpdate.VitaminB3Per100g = nutrition.VitaminB3Per100g;
            nutritionToUpdate.VitaminB6Per100g = nutrition.VitaminB6Per100g;
            nutritionToUpdate.VitaminB9Per100g = nutrition.VitaminB9Per100g;
            nutritionToUpdate.VitaminB12Per100g = nutrition.VitaminB12Per100g;
            nutritionToUpdate.CalciumPer100g = nutrition.CalciumPer100g;
            nutritionToUpdate.IronPer100g = nutrition.IronPer100g;
            nutritionToUpdate.MagnesiumPer100g = nutrition.MagnesiumPer100g;
            nutritionToUpdate.PhosphorusPer100g = nutrition.PhosphorusPer100g;
            nutritionToUpdate.PotassiumPer100g = nutrition.PotassiumPer100g;
            nutritionToUpdate.SodiumPer100g = nutrition.SodiumPer100g;
            nutritionToUpdate.ZincPer100g = nutrition.ZincPer100g;
            nutritionToUpdate.CopperPer100g = nutrition.CopperPer100g;
            nutritionToUpdate.ManganesePer100g = nutrition.ManganesePer100g;
            nutritionToUpdate.SeleniumPer100g = nutrition.SeleniumPer100g;
        }
    }
}
