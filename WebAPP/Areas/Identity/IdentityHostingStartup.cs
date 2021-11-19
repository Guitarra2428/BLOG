using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(WebAPP.Areas.Identity.IdentityHostingStartup))]
namespace WebAPP.Areas.Identity
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