﻿using ControleAcesso.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleAcesso.Infra.Data
{
    public class FuncionalityConfiguration : IEntityTypeConfiguration<Functionality>
    {
        public void Configure(EntityTypeBuilder<Functionality> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Name)
                        .HasMaxLength(50)
                        .IsRequired();
            
            builder.Property(f => f.Description)
                        .HasMaxLength(300)
                        .IsRequired();
        }
    }
}
