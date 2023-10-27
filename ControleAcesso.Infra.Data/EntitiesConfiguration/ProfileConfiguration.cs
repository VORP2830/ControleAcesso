using ControleAcesso.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleAcesso.Infra.Data
{
    public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                        .HasMaxLength(50)
                        .IsRequired();
            
            builder.Property(p => p.Description)
                        .HasMaxLength(300)
                        .IsRequired();
            
            builder.HasMany(p => p.UserProfiles)
                        .WithOne(p => p.Profile)
                        .HasForeignKey(p => p.ProfileId);
            
            builder.HasMany(p => p.FunctionalityProfiles)
                        .WithOne(p => p.Profile)
                        .HasForeignKey(p => p.ProfileId);

            builder.HasMany(p => p.UserProfiles)
                    .WithOne(up => up.Profile)
                    .HasForeignKey(up => up.ProfileId);
            
            builder.HasMany(p => p.FunctionalityProfiles)
                    .WithOne(up => up.Profile)
                    .HasForeignKey(up => up.ProfileId);

            builder.HasData(
                new Profile(1, "Administrador", "Administrador do sistema")
            );
        }
    }
}
