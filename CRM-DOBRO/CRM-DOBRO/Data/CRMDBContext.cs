﻿using CRM_DOBRO.CustomAttributes.Configurations;
using CRM_DOBRO.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRM_DOBRO.CustomAttributes
{

    public class CRMDBContext(DbContextOptions<CRMDBContext> options) : DbContext(options)
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Lead> Leads { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            modelBuilder.ApplyConfiguration(new LeadConfiguration());
            modelBuilder.ApplyConfiguration(new SaleConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
