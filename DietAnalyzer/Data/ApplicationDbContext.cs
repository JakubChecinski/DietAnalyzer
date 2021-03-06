using DietAnalyzer.Models.Domains;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DietAnalyzer.Data
{
    public class ApplicationDbContext : IdentityDbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Diet> Diets { get; set; }
        public DbSet<DietItem> DietItems { get; set; }
        public DbSet<EvaluationResult> EvaluationResults { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<Measure> Measures { get; set; }
        public DbSet<FoodMeasure> FoodMeasures { get; set; }
        public DbSet<NutritionFood> NutritionFoods { get; set; }
        public DbSet<NutritionDiet> NutritionDiets { get; set; }
        public DbSet<RestrictionFood> RestrictionsFoods { get; set; }
        public DbSet<RestrictionUser> RestrictionsUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(x => x.Measures)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(x => x.Foods)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ApplicationUser>()
                .HasOne(x => x.Restrictions)
                .WithOne(x => x.User)
                .HasForeignKey<RestrictionUser>(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Diet>()
                .HasMany(x => x.DietItems)
                .WithOne(x => x.Diet)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Diet>()
                .HasOne(x => x.Nutritions)
                .WithOne(x => x.Diet)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Diet>()
                .HasMany(x => x.Summary)
                .WithOne(x => x.Diet)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DietItem>()
                .HasOne(x => x.FoodItem)
                .WithMany(x => x.DietItems)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<DietItem>()
                .HasOne(x => x.Measure)
                .WithMany(x => x.DietItems)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FoodItem>()
                .HasOne(x => x.Restrictions)
                .WithOne(x => x.FoodItem)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<FoodItem>()
                .HasOne(x => x.Nutrition)
                .WithOne(x => x.FoodItem)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FoodMeasure>()
                .HasOne(x => x.Measure)
                .WithMany(x => x.FoodItems)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<FoodMeasure>()
                .HasOne(x => x.FoodItem)
                .WithMany(x => x.Measures)
                .OnDelete(DeleteBehavior.Restrict);

            DataSeeder.Seed(modelBuilder);

        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // See: https://stackoverflow.com/a/66153603
            // I've checked this and in my case the issue is exactly the same - the warning fires
            // during a Single() call and not during any actual Take/OrderBy call
            // So I'm ignoring it for now
            optionsBuilder.ConfigureWarnings(w => w.Ignore
                (Microsoft.EntityFrameworkCore.Diagnostics.CoreEventId.RowLimitingOperationWithoutOrderByWarning));

            // sql warnings debug
            /*
            // optionsBuilder.EnableSensitiveDataLogging(true);
            optionsBuilder.ConfigureWarnings(w => w.Throw
                (Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.MultipleCollectionIncludeWarning));
            */
        }
        

    }
}
