using ControleAcesso.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleAcesso.Infra.Data;

public class FuncionalityConfiguration : IEntityTypeConfiguration<Functionality>
{
    public void Configure(EntityTypeBuilder<Functionality> builder)
    {
        builder.HasKey(fp => fp.Id);

        builder.HasOne(f => f.MenuOption)
                .WithOne()
                .HasForeignKey<MenuOption>(mo => mo.FuncionalityId);
    }
}
