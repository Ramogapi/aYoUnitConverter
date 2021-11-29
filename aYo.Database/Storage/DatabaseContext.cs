using aYo.Database.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace aYo.Database.Storage
{
    public class DatabaseContext : DbContext, IDbContext
    {
        public static string Dbo = "dbo";
        public static string Rate = "Rate";

        public DatabaseContext(DbContextOptions<DatabaseContext> contextOptions) : base(contextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var typesToRegister = Assembly.GetAssembly(typeof(DatabaseContext)).GetTypes()
                .Where(x => x.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))).ToList();
            foreach (var type in typesToRegister)
            {
                dynamic configuration = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configuration);
            }
        }

        public DbSet<T> GetEntity<T>() where T : class, new()
        {
            return base.Set<T>();
        }
    }
}
