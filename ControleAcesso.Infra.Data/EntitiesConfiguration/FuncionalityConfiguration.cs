using ControleAcesso.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleAcesso.Infra.Data
{
    public class FuncionalityConfiguration : IEntityTypeConfiguration<Functionality>
    {
        public void Configure(EntityTypeBuilder<Functionality> builder)
        {
            builder.HasKey(f => f.Id);

            builder
                .HasOne(f => f.MenuOption)
                .WithOne(mo => mo.Functionality)
                .HasForeignKey<MenuOption>(mo => mo.FuncionalityId);
        }
    }
}
