using Autofac;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Balaji.Api
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        public Startup(IConfiguration _configuration, ILogger<Startup> logger)
        {
            configuration = _configuration;
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

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
             .AddJwtBearer(options =>
             {
                 var jwtSettings = configuration.GetSection("Jwt");
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,
                     ValidIssuer = jwtSettings["Issuer"],
                     ValidAudience = jwtSettings["Audience"],
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]))
                 };
             });

            services.AddAuthorization();
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
