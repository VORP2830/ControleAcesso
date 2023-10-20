using ControleAcesso.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleAcesso.Infra.Data
{
    public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.HasKey(up => up.Id);
        }
    }
}
