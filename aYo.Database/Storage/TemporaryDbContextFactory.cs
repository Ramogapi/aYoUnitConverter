using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace aYo.Database.Storage
{
    public class TemporaryDbContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<DatabaseContext>();
            var connectionString = "Server=.\\SQLEXPRESS;initial catalog=aYoUnitsConverter;Integrated Security=True;MultipleActiveResultSets=true";
            builder.UseSqlServer(connectionString, m =>
            {
                m.MigrationsAssembly("aYo.Database");
                m.MigrationsHistoryTable("MigrationaYoUnitsConverterHistory");
            });
            return new DatabaseContext(builder.Options);
        }
    }
}
