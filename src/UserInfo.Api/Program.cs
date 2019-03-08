using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Net;

namespace UserInfo.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new WebHostBuilder()
                .ConfigureAppConfiguration(BuildConfiguration)
                .UseKestrel(kestrel => kestrel.Listen(IPAddress.Any, string.IsNullOrEmpty(Environment.GetEnvironmentVariable("PORT")) ? 5000 : int.Parse(Environment.GetEnvironmentVariable("PORT"))))
                .UseSerilog(InitLogging)
                .UseStartup<Startup>()
                .UseUrls(Environment.GetEnvironmentVariable("ASPNETCORE_URLS"))
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
