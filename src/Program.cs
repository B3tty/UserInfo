using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;
using System.Net;

namespace UserInfo.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new WebHostBuilder()
                .UseKestrel(kestrel => kestrel.Listen(IPAddress.Any, 5000))
                .ConfigureAppConfiguration(BuildConfiguration)
                .UseSerilog(InitLogging)
                .UseStartup<Startup>()
                .Build()
                .Run();
        }

        private static void BuildConfiguration(WebHostBuilderContext context, IConfigurationBuilder builder)
        {
            builder.AddJsonFile("appsettings.json")
                   .AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json", true)
                   .AddEnvironmentVariables();
        }

        private static void InitLogging(WebHostBuilderContext hostingContext, LoggerConfiguration loggerConf)
        {
            loggerConf.WriteTo.Console();
            loggerConf.Enrich.FromLogContext();
        }
    }
}
