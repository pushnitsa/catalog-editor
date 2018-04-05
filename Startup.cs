using CatalogEditor.DatabaseContext;
using CatalogEditor.Deserializer;
using CatalogEditor.Fetcher;
using CatalogEditor.Initializer;
using CatalogEditor.Serializer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CatalogEditor
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _hostingEnvironment;
        
        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddContext(_configuration.GetValue<string>("DatabaseName"));
            services
                .AddTransient<IEntitySerializer, EntitySerializer>()
                .AddTransient<IEntityDeserializer, EntityDeserializer>()
                .AddTransient<ICategoryFetcher, CategoryFetcher>()
                .AddTransient<IDatabaseInitializer, DatabaseInitializer>();
        }

        public void Configure(IApplicationBuilder app, IDatabaseInitializer initializer)
        {
            app.UseStaticFiles();

            if (_hostingEnvironment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            initializer.Seed().Wait();
        }
    }
}