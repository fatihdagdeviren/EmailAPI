using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Seeds
{
    public class EmailProviderSeed : IEntityTypeConfiguration<EmailProvider>
    {
        public void Configure(EntityTypeBuilder<EmailProvider> builder)
        {
            //builder.HasData(new EmailProvider
            //{
            //    Id = Guid.NewGuid(),
            //    Host = "smtp.gmail.com",
            //    Port = 587,
            //    EnableSSL = true,
            //    Password = string.Empty,
            //    UserName = "smtp.gmail.com"
            //});
        }
    }
}
