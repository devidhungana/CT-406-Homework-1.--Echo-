using System.Linq;
using CoreBook.HW1_MiniWeb.Persistence.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace HW1_MiniWeb
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDirectoryBrowser();
            services.AddSingleton<ICountryRepository>(new CountryRespository());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ICountryRepository country)
        {
            app.UseDirectoryBrowser();
            app.UseStaticFiles();
            app.Run(async (context) =>
            {
                var query = context.Request.Query["q"];
                var listOfCountries = country.AllBy(query).ToList();
                var json = JsonConvert.SerializeObject(listOfCountries);
                await context.Response.WriteAsync(json);
                //await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
