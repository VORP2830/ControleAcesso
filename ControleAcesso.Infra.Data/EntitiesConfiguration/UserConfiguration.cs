using ControleAcesso.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleAcesso.Infra.Data
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(u => u.Email)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(u => u.UserName)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(u => u.Password)
                .HasMaxLength(300)
                .IsRequired();
        }
    }
}
