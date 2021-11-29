using aYo.Database.Entities;
using aYo.Database.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace aYo.Database.Configurations
{
    public class ImperialConfiguration : IEntityTypeConfiguration<Imperial>
    {
        public void Configure(EntityTypeBuilder<Imperial> builder)
        {
            builder.ToTable(nameof(Imperial), DatabaseContext.Dbo);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(50);
        }
    }
}
