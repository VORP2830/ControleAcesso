using ControleAcesso.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleAcesso.Infra.Data;

public class UserAccessConfiguration
{
        public void Configure(EntityTypeBuilder<UserAccess> builder)
        {
                builder.HasKey(ua => ua.Id);

                builder.Property(ua => ua.UserName)
                        .HasMaxLength(100)
                        .IsRequired();

                builder.Property(ua => ua.IP)
                        .HasMaxLength(100)
                        .IsRequired();
        }
}
