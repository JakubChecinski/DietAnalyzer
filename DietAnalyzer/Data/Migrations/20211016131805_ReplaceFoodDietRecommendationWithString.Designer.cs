﻿// <auto-generated />
using System;
using DietAnalyzer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DietAnalyzer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211016131805_ReplaceFoodDietRecommendationWithString")]
    partial class ReplaceFoodDietRecommendationWithString
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DietAnalyzer.Models.Domains.Diet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Recommendations")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Diets");
                });

            modelBuilder.Entity("DietAnalyzer.Models.Domains.DietItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DietId")
                        .HasColumnType("int");

                    b.Property<int>("FoodItemId")
                        .HasColumnType("int");

                    b.Property<int>("MeasureId")
                        .HasColumnType("int");

                    b.Property<float>("Quantity")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("DietId");

                    b.HasIndex("FoodItemId");

                    b.HasIndex("MeasureId");

                    b.ToTable("DietItems");
                });

            modelBuilder.Entity("DietAnalyzer.Models.Domains.FoodItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("FoodItems");
                });

            modelBuilder.Entity("DietAnalyzer.Models.Domains.FoodMeasure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FoodItemId")
                        .HasColumnType("int");

                    b.Property<bool>("IsCurrentlyLinked")
                        .HasColumnType("bit");

                    b.Property<int>("MeasureId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FoodItemId");

                    b.HasIndex("MeasureId");

                    b.ToTable("FoodMeasures");
                });

            modelBuilder.Entity("DietAnalyzer.Models.Domains.Measure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Grams")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Measures");
                });

            modelBuilder.Entity("DietAnalyzer.Models.Domains.NutritionDiet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float?>("CalciumPer100g")
                        .HasColumnType("real");

                    b.Property<float?>("CaloriesPer100g")
                        .HasColumnType("real");

                    b.Property<float?>("CarbohydratesPer100g")
                        .HasColumnType("real");

                    b.Property<float?>("CopperPer100g")
                        .HasColumnType("real");

                    b.Property<int>("DietId")
                        .HasColumnType("int");

                    b.Property<float?>("FatsPer100g")
                        .HasColumnType("real");

                    b.Property<float?>("FiberPer100g")
                        .HasColumnType("real");

                    b.Property<float?>("IronPer100g")
                        .HasColumnType("real");

                    b.Property<float?>("MagnesiumPer100g")
                        .HasColumnType("real");

                    b.Property<float?>("ManganesePer100g")
                        .HasColumnType("real");

                    b.Property<float?>("PhosphorusPer100g")
                        .HasColumnType("real");

                    b.Property<float?>("PotassiumPer100g")
                        .HasColumnType("real");

                    b.Property<float?>("ProteinsPer100g")
                        .HasColumnType("real");

                    b.Property<float?>("SaturatedFatPer100g")
                        .HasColumnType("real");

                    b.Property<float?>("SeleniumPer100g")
                        .HasColumnType("real");

                    b.Property<float?>("SodiumPer100g")
                        .HasColumnType("real");

                    b.Property<float?>("SugarPer100g")
                        .HasColumnType("real");

                    b.Property<float?>("VitaminAPer100g")
                        .HasColumnType("real");

                    b.Property<float?>("VitaminB12Per100g")
                        .HasColumnType("real");

                    b.Property<float?>("VitaminB1Per100g")
                        .HasColumnType("real");

                    b.Property<float?>("VitaminB2Per100g")
                        .HasColumnType("real");

                    b.Property<float?>("VitaminB3Per100g")
                        .HasColumnType("real");

                    b.Property<float?>("VitaminB6Per100g")
                        .HasColumnType("real");

                    b.Property<float?>("VitaminB9Per100g")
                        .HasColumnType("real");

                    b.Property<float?>("VitaminCPer100g")
                        .HasColumnType("real");

                    b.Property<float?>("VitaminDPer100g")
                        .HasColumnType("real");

                    b.Property<float?>("VitaminEPer100g")
                        .HasColumnType("real");

                    b.Property<float?>("VitaminKPer100g")
                        .HasColumnType("real");

                    b.Property<float?>("ZincPer100g")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("DietId")
                        .IsUnique();

                    b.ToTable("NutritionDiets");
                });

            modelBuilder.Entity("DietAnalyzer.Models.Domains.NutritionFood", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float?>("CalciumPer100g")
                        .HasColumnType("real");

                    b.Property<float?>("CaloriesPer100g")
                        .HasColumnType("real");

                    b.Property<float?>("CarbohydratesPer100g")
                        .HasColumnType("real");

                    b.Property<float?>("CopperPer100g")
                        .HasColumnType("real");

                    b.Property<float?>("FatsPer100g")
                        .HasColumnType("real");

                    b.Property<float?>("FiberPer100g")
                        .HasColumnType("real");

                    b.Property<int>("FoodItemId")
                        .HasColumnType("int");

                    b.Property<float?>("IronPer100g")
                        .HasColumnType("real");

                    b.Property<float?>("MagnesiumPer100g")
                        .HasColumnType("real");

                    b.Property<float?>("ManganesePer100g")
                        .HasColumnType("real");

                    b.Property<float?>("PhosphorusPer100g")
                        .HasColumnType("real");

                    b.Property<float?>("PotassiumPer100g")
                        .HasColumnType("real");

                    b.Property<float?>("ProteinsPer100g")
                        .HasColumnType("real");

                    b.Property<float?>("SaturatedFatPer100g")
                        .HasColumnType("real");

                    b.Property<float?>("SeleniumPer100g")
                        .HasColumnType("real");

                    b.Property<float?>("SodiumPer100g")
                        .HasColumnType("real");

                    b.Property<float?>("SugarPer100g")
                        .HasColumnType("real");

                    b.Property<float?>("VitaminAPer100g")
                        .HasColumnType("real");

                    b.Property<float?>("VitaminB12Per100g")
                        .HasColumnType("real");

                    b.Property<float?>("VitaminB1Per100g")
                        .HasColumnType("real");

                    b.Property<float?>("VitaminB2Per100g")
                        .HasColumnType("real");

                    b.Property<float?>("VitaminB3Per100g")
                        .HasColumnType("real");

                    b.Property<float?>("VitaminB6Per100g")
                        .HasColumnType("real");

                    b.Property<float?>("VitaminB9Per100g")
                        .HasColumnType("real");

                    b.Property<float?>("VitaminCPer100g")
                        .HasColumnType("real");

                    b.Property<float?>("VitaminDPer100g")
                        .HasColumnType("real");

                    b.Property<float?>("VitaminEPer100g")
                        .HasColumnType("real");

                    b.Property<float?>("VitaminKPer100g")
                        .HasColumnType("real");

                    b.Property<float?>("ZincPer100g")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("FoodItemId")
                        .IsUnique();

                    b.ToTable("NutritionFoods");
                });

            modelBuilder.Entity("DietAnalyzer.Models.Domains.RestrictionFood", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("DairyIntolerant")
                        .HasColumnType("bit");

                    b.Property<bool>("Diabetes")
                        .HasColumnType("bit");

                    b.Property<int>("FoodItemId")
                        .HasColumnType("int");

                    b.Property<bool>("GlutenIntolerant")
                        .HasColumnType("bit");

                    b.Property<bool>("HeartProblems")
                        .HasColumnType("bit");

                    b.Property<bool>("Keto")
                        .HasColumnType("bit");

                    b.Property<bool>("KidneyProblems")
                        .HasColumnType("bit");

                    b.Property<bool>("Paleo")
                        .HasColumnType("bit");

                    b.Property<bool>("Pescetarian")
                        .HasColumnType("bit");

                    b.Property<bool>("Vegan")
                        .HasColumnType("bit");

                    b.Property<bool>("Vegetarian")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("FoodItemId")
                        .IsUnique();

                    b.ToTable("RestrictionsFoods");
                });

            modelBuilder.Entity("DietAnalyzer.Models.Domains.RestrictionUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("DairyIntolerant")
                        .HasColumnType("bit");

                    b.Property<bool>("Diabetes")
                        .HasColumnType("bit");

                    b.Property<bool>("GlutenIntolerant")
                        .HasColumnType("bit");

                    b.Property<bool>("HeartProblems")
                        .HasColumnType("bit");

                    b.Property<bool>("Keto")
                        .HasColumnType("bit");

                    b.Property<bool>("KidneyProblems")
                        .HasColumnType("bit");

                    b.Property<bool>("Paleo")
                        .HasColumnType("bit");

                    b.Property<bool>("Pescetarian")
                        .HasColumnType("bit");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Vegan")
                        .HasColumnType("bit");

                    b.Property<bool>("Vegetarian")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("RestrictionsUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("DietAnalyzer.Models.Domains.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("DietAnalyzer.Models.Domains.Diet", b =>
                {
                    b.HasOne("DietAnalyzer.Models.Domains.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DietAnalyzer.Models.Domains.DietItem", b =>
                {
                    b.HasOne("DietAnalyzer.Models.Domains.Diet", "Diet")
                        .WithMany("DietItems")
                        .HasForeignKey("DietId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DietAnalyzer.Models.Domains.FoodItem", "FoodItem")
                        .WithMany("DietItems")
                        .HasForeignKey("FoodItemId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DietAnalyzer.Models.Domains.Measure", "Measure")
                        .WithMany("DietItems")
                        .HasForeignKey("MeasureId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Diet");

                    b.Navigation("FoodItem");

                    b.Navigation("Measure");
                });

            modelBuilder.Entity("DietAnalyzer.Models.Domains.FoodItem", b =>
                {
                    b.HasOne("DietAnalyzer.Models.Domains.ApplicationUser", "User")
                        .WithMany("Foods")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("User");
                });

            modelBuilder.Entity("DietAnalyzer.Models.Domains.FoodMeasure", b =>
                {
                    b.HasOne("DietAnalyzer.Models.Domains.FoodItem", "FoodItem")
                        .WithMany("Measures")
                        .HasForeignKey("FoodItemId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DietAnalyzer.Models.Domains.Measure", "Measure")
                        .WithMany("FoodItems")
                        .HasForeignKey("MeasureId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("FoodItem");

                    b.Navigation("Measure");
                });

            modelBuilder.Entity("DietAnalyzer.Models.Domains.Measure", b =>
                {
                    b.HasOne("DietAnalyzer.Models.Domains.ApplicationUser", "User")
                        .WithMany("Measures")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("User");
                });

            modelBuilder.Entity("DietAnalyzer.Models.Domains.NutritionDiet", b =>
                {
                    b.HasOne("DietAnalyzer.Models.Domains.Diet", "Diet")
                        .WithOne("Nutritions")
                        .HasForeignKey("DietAnalyzer.Models.Domains.NutritionDiet", "DietId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Diet");
                });

            modelBuilder.Entity("DietAnalyzer.Models.Domains.NutritionFood", b =>
                {
                    b.HasOne("DietAnalyzer.Models.Domains.FoodItem", "FoodItem")
                        .WithOne("Nutrition")
                        .HasForeignKey("DietAnalyzer.Models.Domains.NutritionFood", "FoodItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FoodItem");
                });

            modelBuilder.Entity("DietAnalyzer.Models.Domains.RestrictionFood", b =>
                {
                    b.HasOne("DietAnalyzer.Models.Domains.FoodItem", "FoodItem")
                        .WithOne("Restrictions")
                        .HasForeignKey("DietAnalyzer.Models.Domains.RestrictionFood", "FoodItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FoodItem");
                });

            modelBuilder.Entity("DietAnalyzer.Models.Domains.RestrictionUser", b =>
                {
                    b.HasOne("DietAnalyzer.Models.Domains.ApplicationUser", "User")
                        .WithOne("Restrictions")
                        .HasForeignKey("DietAnalyzer.Models.Domains.RestrictionUser", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DietAnalyzer.Models.Domains.Diet", b =>
                {
                    b.Navigation("DietItems");

                    b.Navigation("Nutritions");
                });

            modelBuilder.Entity("DietAnalyzer.Models.Domains.FoodItem", b =>
                {
                    b.Navigation("DietItems");

                    b.Navigation("Measures");

                    b.Navigation("Nutrition");

                    b.Navigation("Restrictions");
                });

            modelBuilder.Entity("DietAnalyzer.Models.Domains.Measure", b =>
                {
                    b.Navigation("DietItems");

                    b.Navigation("FoodItems");
                });

            modelBuilder.Entity("DietAnalyzer.Models.Domains.ApplicationUser", b =>
                {
                    b.Navigation("Foods");

                    b.Navigation("Measures");

                    b.Navigation("Restrictions");
                });
#pragma warning restore 612, 618
        }
    }
}
