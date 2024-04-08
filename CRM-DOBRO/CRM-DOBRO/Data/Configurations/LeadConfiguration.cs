﻿using CRM_DOBRO.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRM_DOBRO.Data.Configurations
{
    public class LeadConfiguration : IEntityTypeConfiguration<Lead>
    {
        public void Configure(EntityTypeBuilder<Lead> builder)
        {
            builder.HasKey(l => l.Id);

            builder
                .HasOne(l => l.Contact)
                .WithOne(c => c.Lead)
                .HasForeignKey<Lead>(l => l.ContactId);

            builder
                .HasOne(l => l.Saler)
                .WithMany(s => s.Leads)
                .HasForeignKey(l => l.SalerId);
        }
    }
}