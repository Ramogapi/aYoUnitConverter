using aYo.Business.Converter.Abstracts;
using aYo.Business.Converter.Definitions;
using aYo.Database.Abstract;
using aYo.Database.Definitions;
using aYo.Database.Storage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aYo
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
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "aYo", Version = "v1", Description = "aYo Converter" });
            });

            var connection = Configuration["ConnectionString"];
            services.AddDbContext<DatabaseContext>(o => o.UseSqlServer(connection, b =>
            {
                b.MigrationsAssembly("aYo.Database");
                b.MigrationsHistoryTable("MigrationaYoUnitsConverterHistory");
                b.EnableRetryOnFailure(5);
            }));

            services.AddTransient<IDbContext, DatabaseContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IImperialToMetric, ImperialToMetric>();
            services.AddTransient<IMetricToImperial, MetricToImperial>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "aYo.Assessment");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
