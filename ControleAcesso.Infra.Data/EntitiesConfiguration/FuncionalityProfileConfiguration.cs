using ControleAcesso.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleAcesso.Infra.Data
{
    public class FuncionalityProfileConfiguration : IEntityTypeConfiguration<FuncionalityProfile>
    {
        public void Configure(EntityTypeBuilder<FuncionalityProfile> builder)
        {
            builder.HasKey(fp => fp.Id);

            builder
                .HasOne(fp => fp.Profile)
                .WithMany(p => p.FuncionalityProfiles)
                .HasForeignKey(fp => fp.ProfileId);

            builder
                .HasOne(fp => fp.Functionality)
                .WithMany(f => f.FuncionalityProfiles)
                .HasForeignKey(fp => fp.FuncionalityId);
        }
    }
}
