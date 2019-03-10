using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;
using UserInfo.Storage;

namespace UserInfo.Api
{
    public static class StartupExtensions
    {
        private const string ApiName = "User Info API";
        private const string ApiVersion = "v1";

        public static IServiceCollection AddApiSwagger(this IServiceCollection services, ILoggerFactory loggerFactory)
        {
            return services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = ApiName, Version = ApiVersion });
                var assembly = Assembly.GetEntryAssembly();
                var filePath = Path.Combine(Path.GetDirectoryName(assembly.Location), assembly.GetName().Name + ".xml");
                if (File.Exists(filePath))
                {
                    c.IncludeXmlComments(filePath);
                }
                else
                {
                    loggerFactory.CreateLogger("startup").LogWarning($"could not find comments in xml file : {filePath}");
                }
            });
        }

        public static IServiceCollection AddStorage(this IServiceCollection services, IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            // CachedStorage is the one deployed on production to ease heroku deployment
            if (hostingEnvironment.EnvironmentName.ToLower().Equals("production"))
            {
                services.AddSingleton<IUserStore>(new CachedStorage());
            }
            else
            {
                var helper = new CassandraHelper(configuration["cassandra:host"], int.Parse(configuration["cassandra:port"]), configuration["cassandra:script"]);
                services.AddSingleton<IUserStore>(new CassandraStorage(helper.Session));
            }
            return services;
        }

        public static IApplicationBuilder UseApiSwagger(this IApplicationBuilder app)
        {
            return app.UseSwagger(null)
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{ApiName} {ApiVersion}");
                });
        }
    }
}