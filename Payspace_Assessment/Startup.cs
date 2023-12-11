using Payspace_Assessment.DataAccess.DataObjects;
using Payspace_Assessment.DataAccess.Interfaces;
using Payspace_Assessment.DataAccess;
using Payspace_Assessment.Interfaces;
using Payspace_Assessment.Repositories;
using Payspace_Assessment.Services;
using Microsoft.AspNetCore.Builder;

namespace Payspace_Assessment
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddScoped<ITaxCalculator, ProgressiveTaxCalculator>();
            services.AddScoped<ITaxCalculator, FlatValueTaxCalculator>();
            services.AddScoped<ITaxCalculator, FlatRateTaxCalculator>();
            services.AddScoped<ITaxCalculator_B, TaxCalculator_B>();
            services.AddScoped<ITaxCalculator_D, TaxCalculator_D>();
            services.AddScoped<ITaxCalculatorService, TaxCalculatorService>();
            services.AddDbContext<TaxCalculatorContext>((serviceProvider, dbContextBuilder) => { });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=TaxCalculator}/{action=Index}/{id?}");
            });
        }
    }
}
