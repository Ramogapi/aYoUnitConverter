using aYo.Database.Entities.Rate;
using aYo.Database.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace aYo.Database.Configurations.Rate
{
    public class MetricRateConfiguration : IEntityTypeConfiguration<MetricRate>
    {
        public void Configure(EntityTypeBuilder<MetricRate> builder)
        {
            builder.ToTable(nameof(MetricRate), DatabaseContext.Rate);
        }
    }
}
