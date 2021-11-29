using aYo.Business.Converter.Abstracts;
using aYo.Business.Converter.Definitions;
using aYo.Database.Abstract;
using aYo.Database.Definitions;
using aYo.Database.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace aYo.Analysis
{
    public class InversionOfControl
    {
        public InversionOfControl()
        {
            var services = new ServiceCollection();
            services.AddDbContext<DatabaseContext>(o => o.UseSqlServer("Server=.\\SQLEXPRESS;initial catalog=aYoUnitsConverter;Integrated Security=True;MultipleActiveResultSets=true",
                 b =>
                 {
                     b.MigrationsAssembly("aYo.Analysis");
                     b.MigrationsHistoryTable("MigrationaYoUnitsConverterHistory");
                     b.EnableRetryOnFailure(5);
                 }));
            services.AddTransient<IDbContext, DatabaseContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IImperialToMetric, ImperialToMetric>();
            services.AddTransient<IMetricToImperial, MetricToImperial>();

            ServiceProvider = services.BuildServiceProvider();
        }

        public ServiceProvider ServiceProvider { get; private set; }
    }
}
