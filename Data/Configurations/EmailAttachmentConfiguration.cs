using System;
using System.Collections.Generic;
using System.Text;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class EmailAttachmentConfiguration : IEntityTypeConfiguration<EmailAttachment>
    {
        public void Configure(EntityTypeBuilder<EmailAttachment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasDefaultValueSql("(newid())");
            builder.Property(x => x.DocumentId).IsRequired();
            builder.Property(x => x.EmailQueueId).IsRequired();
        }
    }
}
