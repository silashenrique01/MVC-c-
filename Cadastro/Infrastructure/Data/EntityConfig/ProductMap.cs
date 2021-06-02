﻿using Cadastro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cadastro.Infrastructure.Data.EntityConfig
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(m => m.Value)
                .HasColumnType("DECIMAL")
                .IsRequired();

            builder.HasOne(m => m.Category)
                .WithMany()
                .HasForeignKey(m => m.IdCategory);

            builder.HasOne(m => m.Client)
                .WithMany()
                .HasForeignKey(m => m.IdClient);
        }
    }
}
