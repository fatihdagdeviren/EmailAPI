using System;
using System.Collections.Generic;
using System.Text;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class EmailDateConfiguration : IEntityTypeConfiguration<EmailDate>
    {
        public void Configure(EntityTypeBuilder<EmailDate> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasDefaultValueSql("(newid())");
            builder.Property(x => x.IsSent).HasDefaultValue(false);
            builder.Property(x => x.Priority).HasDefaultValue(10);
            

        }
    }
}
