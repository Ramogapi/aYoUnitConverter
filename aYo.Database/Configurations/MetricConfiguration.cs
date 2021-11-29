using aYo.Database.Entities;
using aYo.Database.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace aYo.Database.Configurations
{
    public class MetricConfiguration : IEntityTypeConfiguration<Metric>
    {
        public void Configure(EntityTypeBuilder<Metric> builder)
        {
            builder.ToTable(nameof(Metric), DatabaseContext.Dbo);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(50);
        }
    }
}
