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

            builder
                .HasOne(up => up.Profile)
                .WithMany(p => p.UserProfiles)
                .HasForeignKey(up => up.ProfileId);

            builder
                .HasOne(up => up.User)
                .WithMany(u => u.UserProfiles)
                .HasForeignKey(up => up.UserId);
        }
    }
}
