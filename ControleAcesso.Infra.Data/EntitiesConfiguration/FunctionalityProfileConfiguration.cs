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
        }
    }
}
