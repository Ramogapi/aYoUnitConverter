using aYo.Database.Entities.Rate;
using aYo.Database.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace aYo.Database.Configurations.Rate
{
    public class ImperialRateConfiguration: IEntityTypeConfiguration<ImperialRate>
    {
        public void Configure(EntityTypeBuilder<ImperialRate> builder)
        {
            builder.ToTable(nameof(ImperialRate), DatabaseContext.Rate);
        }
    }
}
