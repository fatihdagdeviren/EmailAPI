using System;
using System.Collections.Generic;
using System.Text;
using Core.Models;
using Data.Configurations;
using Data.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data
{
    public class EmailAPIDBContext : DbContext
    {
        IConfiguration _configuration;
        //public EmailAPIDBContext(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

     
        public EmailAPIDBContext(DbContextOptions<EmailAPIDBContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{

            //    optionsBuilder.UseSqlServer(_configuration.GetConnectionString("SqlConnectionString"));
            //}
        }

        public DbSet<EmailAttachment> EmailAttachments { get; set; }
        public DbSet<EmailProvider> EmailProviders { get; set; }
        public DbSet<EmailQueue> EmailQueue { get; set; }
        public DbSet<EmailDate> EmailDates { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmailAttachmentConfiguration());
            modelBuilder.ApplyConfiguration(new EmailProviderConfiguration());
            modelBuilder.ApplyConfiguration(new EmailProviderSeed());
            modelBuilder.ApplyConfiguration(new EmailQueueProviderConfiguration());
            modelBuilder.ApplyConfiguration(new EmailDateConfiguration());

        }
    }
}
