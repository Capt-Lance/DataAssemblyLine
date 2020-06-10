using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAssemblyLine.Domain.Items;
using DataAssemblyLine.Domain.Processes;
using DataAssemblyLine.Infrastructure.EFCore;
using DataAssemblyLine.Infrastructure.EFCore.Processes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ItemApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataAssemblyLineContext>(options => options.UseSqlServer("Data Source=localhost;Initial Catalog=DataAssemblyLine;Integrated Security=True"));
            services.AddScoped<IProcessRepository<ItemProcess>, ItemProcessRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<ItemRepository>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
