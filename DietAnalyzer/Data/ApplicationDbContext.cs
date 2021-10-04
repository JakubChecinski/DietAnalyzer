using DietAnalyzer.Models.Domains;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

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
        public DbSet<DietItem> DietItem { get; set; }
        public DbSet<FoodDietRecommendation> FoodDietRecommendations { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<Measure> Measures { get; set; }
        public DbSet<NutritionInfo> NutritionInfos { get; set; }
        public DbSet<RestrictionsInfo> RestrictionsInfos { get; set; }

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
                .HasForeignKey<RestrictionsInfo>(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Diet>()
                .HasMany(x => x.DietItems)
                .WithOne(x => x.Diet)
                .HasForeignKey(x => x.DietId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Diet>()
                .HasMany(x => x.Recommendations)
                .WithOne(x => x.Diet)
                .HasForeignKey(x => x.DietId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DietItem>()
                .HasOne(x => x.FoodItem)
                .WithMany(x => x.DietItems)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<DietItem>()
                .HasOne(x => x.Diet)
                .WithMany(x => x.DietItems)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FoodDietRecommendation>()
                .HasOne(x => x.FoodItem)
                .WithMany(x => x.Recommendations)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<FoodDietRecommendation>()
                .HasOne(x => x.Diet)
                .WithMany(x => x.Recommendations)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FoodItem>()
                .HasMany(x => x.Recommendations)
                .WithOne(x => x.FoodItem)
                .HasForeignKey(x => x.FoodItemId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<FoodItem>()
                .HasMany(x => x.Recommendations)
                .WithOne(x => x.FoodItem)
                .HasForeignKey(x => x.FoodItemId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<FoodItem>()
                .HasOne(x => x.Restrictions)
                .WithOne(x => x.FoodItem)
                .HasForeignKey<RestrictionsInfo>(x => x.FoodItemId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Measure>()
               .HasMany(x => x.DietItems)
               .WithOne(x => x.Measure)
               .HasForeignKey(x => x.MeasureId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RestrictionsInfo>()
                .HasOne(x => x.FoodItem)
                .WithOne(x => x.Restrictions)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<RestrictionsInfo>()
                .HasOne(x => x.User)
                .WithOne(x => x.Restrictions)
                .OnDelete(DeleteBehavior.Restrict);

        }

    }
}
