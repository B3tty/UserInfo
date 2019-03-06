using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace UserInfo.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly ILoggerFactory _loggerFactory;
        private readonly IHostingEnvironment _hostingEnvironment;


        public Startup(IConfiguration configuration, ILoggerFactory loggerFactory, IHostingEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _loggerFactory = loggerFactory;
            _hostingEnvironment = hostingEnvironment;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApiSwagger(_loggerFactory)
                    .AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseApiSwagger()
               .UseMvc();
        }
    }
}
