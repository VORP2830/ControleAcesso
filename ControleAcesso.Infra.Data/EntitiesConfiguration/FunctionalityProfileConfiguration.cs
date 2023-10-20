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
        }
    }
}
