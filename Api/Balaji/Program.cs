
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Balaji.Api
{
    class Program
    {
        public static void Main(string[] args) 
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .ConfigureServices(services => services.AddAutofac())
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                    logging.AddDebug();
                });
        }
    }
}
