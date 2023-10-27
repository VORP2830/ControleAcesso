using ControleAcesso.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleAcesso.Infra.Data
{
    public class FunctionalityProfileConfiguration : IEntityTypeConfiguration<FunctionalityProfile>
    {
        public void Configure(EntityTypeBuilder<FunctionalityProfile> builder)
        {
            builder.HasKey(fp => fp.Id);

            builder.HasOne(up => up.Functionality)
                    .WithMany(u => u.FunctionalityProfiles)
                    .HasForeignKey(up => up.FunctionalityId);

            builder.HasOne(up => up.Profile)
                    .WithMany(p => p.FunctionalityProfiles)
                    .HasForeignKey(up => up.ProfileId);
            
            builder.HasData(
                new FunctionalityProfile(1, 1, 1),
                new FunctionalityProfile(2, 1, 2),
                new FunctionalityProfile(3, 1, 3),
                new FunctionalityProfile(4, 1, 4),
                new FunctionalityProfile(5, 1, 5),
                new FunctionalityProfile(6, 1, 6),
                new FunctionalityProfile(7, 1, 7)
            );
        }
    }
}
