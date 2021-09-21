using System;
using System.Collections.Generic;
using System.Text;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class EmailQueueProviderConfiguration : IEntityTypeConfiguration<EmailQueue>
    {
        public void Configure(EntityTypeBuilder<EmailQueue> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasDefaultValueSql("(newid())");
            
            builder.Property(x => x.Content).HasMaxLength(4096).IsRequired();
            builder.Property(x => x.From).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Title).HasMaxLength(1024).IsRequired();
            builder.Property(x => x.To).HasMaxLength(2048).IsRequired();

            builder.Property(x => x.EmailProviderId).IsRequired();
           
            //builder.HasOne(x => x.EmailProvider).WithOne().HasForeignKey<EmailQueue>(e => e.EmailProviderId);
            

            builder
                .HasMany<EmailAttachment>(s => s.Attachments)
                .WithOne()
                .HasForeignKey(s => s.EmailQueueId);


            builder
                .HasMany<EmailDate>(s => s.Dates)
                .WithOne()
                .HasForeignKey(s => s.EmailQueueId);

        }
    }
}
