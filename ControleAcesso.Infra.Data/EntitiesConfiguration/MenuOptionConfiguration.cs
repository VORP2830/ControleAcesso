using ControleAcesso.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleAcesso.Infra.Data
{
    public class MenuOptionConfiguration : IEntityTypeConfiguration<MenuOption>
    {
        public void Configure(EntityTypeBuilder<MenuOption> builder)
        {
            builder.HasKey(mo => mo.Id);

            builder.Property(mo => mo.Name)
                        .HasMaxLength(50)
                        .IsRequired();
                        
            builder.HasOne(mo => mo.Functionality)
                    .WithOne(f => f.MenuOption)
                    .HasForeignKey<MenuOption>(mo => mo.FunctionalityId);
        }
    }
}
