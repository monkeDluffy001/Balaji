using Autofac;
using Microsoft.Extensions.Configuration;

namespace Balaji.Api
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        public Startup(IConfiguration _configuration, ILogger<Startup> logger)
        {
            configuration =_configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.Name = ".AdventureWorks.Session";
                options.IdleTimeout = TimeSpan.FromMinutes(60);
                options.Cookie.IsEssential = true;
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(
                System.Reflection.Assembly.GetExecutingAssembly(),
                System.Reflection.Assembly.Load("Balaji.ApiModels"),
                System.Reflection.Assembly.Load("Balaji.Common"),
                System.Reflection.Assembly.Load("Balaji.Core"),
                System.Reflection.Assembly.Load("Balaji.Domain"),
                System.Reflection.Assembly.Load("Balaji.Infrastructure"),
                System.Reflection.Assembly.Load("Balaji.Logging"),
                System.Reflection.Assembly.Load("Balaji.Common.Helpers")
            ).Where(t => t.IsClass)
            .AsImplementedInterfaces();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
