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
            
            builder.HasOne(mo => mo.MenuDad)
                .WithMany()
                .HasForeignKey(mo => mo.MenuDadId)
                .IsRequired(false);
                
            builder.HasOne(mo => mo.Functionality)
                .WithMany()
                .HasForeignKey(mo => mo.FuncionalityId);
        }
    }
}
