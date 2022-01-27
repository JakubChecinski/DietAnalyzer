using DietAnalyzer.Data;
using DietAnalyzer.Services;
using DietAnalyzer.Services.Utilities;
using JSNLog;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DietAnalyzer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDietService, DietService>();
            services.AddScoped<IFoodItemService, FoodItemService>();
            services.AddScoped<IMeasureService, MeasureService>();
            services.AddScoped<IRestrictionService, RestrictionService>();
            services.AddScoped<IEvaluationService, EvaluationService>();
            services.AddScoped<IExampleDataService, ExampleDataService>();
            services.AddScoped<ImageHelper, ImageHelper>();

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                options.UseSqlServer(o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
            });
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();

            services.AddHttpsRedirection(opts =>
            {
                opts.HttpsPort = 44300;
            });

            services.AddHsts(opts =>
            {
                opts.MaxAge = System.TimeSpan.FromDays(30);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseHttpsRedirection();

            // app.UseDeveloperExceptionPage();

            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
            app.UseStatusCodePages();

            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseJSNLog(loggerFactory);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
