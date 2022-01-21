using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(DietAnalyzer.Areas.Identity.IdentityHostingStartup))]
namespace DietAnalyzer.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}