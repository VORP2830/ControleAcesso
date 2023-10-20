using ControleAcesso.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleAcesso.Infra.Data
{
    public class MethodConfiguration : IEntityTypeConfiguration<Methods>
    {
        public void Configure(EntityTypeBuilder<Methods> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Class)
                        .HasMaxLength(50)
                        .IsRequired();

            builder.Property(m => m.Method)
                        .HasMaxLength(100)
                        .IsRequired();
            
            builder.Property(m => m.Description)
                        .HasMaxLength(300)
                        .IsRequired();
        }
    }
}
