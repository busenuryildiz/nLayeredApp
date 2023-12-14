﻿using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {

        public void Configure(EntityTypeBuilder<Customer> builder)
        {

            builder.ToTable("Customers").HasKey(b => b.Id);
            builder.Property(b => b.Id).HasColumnName("CustomerID").IsRequired();
            builder.Property(b => b.CompanyName).HasColumnName("CompanyName").IsRequired();
            builder.Property(b => b.ContactName).HasColumnName("ContactName");
            builder.Property(b => b.Country).HasColumnName("Country");
            builder.Property(b => b.City).HasColumnName("City");

            builder.HasIndex(indexExpression: b => b.ContactName, name: "UK_Customers_ContactName").IsUnique();
            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);

        }
    }
}
