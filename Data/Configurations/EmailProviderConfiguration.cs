using System;
using System.Collections.Generic;
using System.Text;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class EmailProviderConfiguration : IEntityTypeConfiguration<EmailProvider>
    {
        public void Configure(EntityTypeBuilder<EmailProvider> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasDefaultValueSql("(newid())");
            builder.Property(x => x.Port).IsRequired();
            builder.Property(x => x.Password).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Host).IsRequired().HasMaxLength(200);
            builder.Property(x => x.UserName).IsRequired().HasMaxLength(200);
        }
    }
}
