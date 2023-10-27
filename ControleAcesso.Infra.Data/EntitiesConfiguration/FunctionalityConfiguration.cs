using ControleAcesso.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleAcesso.Infra.Data
{
    public class FunctionalityConfiguration : IEntityTypeConfiguration<Functionality>
    {
        public void Configure(EntityTypeBuilder<Functionality> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Name)
                        .HasMaxLength(50)
                        .IsRequired();
            
            builder.Property(f => f.Description)
                        .HasMaxLength(300)
                        .IsRequired();
            
            builder.HasMany(u => u.FunctionalityProfiles)
                    .WithOne(up => up.Functionality)
                    .HasForeignKey(up => up.FunctionalityId);
            
            builder.HasData(
                new Functionality(1, "Manter perfil", "Funcionalidade para manter todos os perfis do sistema"),
                new Functionality(2, "Manter metodos", "Funcionalidade para manter todos os metodos do sistema"),
                new Functionality(3, "Manter funcionalidades", "Funcionalidade para manter todas as funcionalidades do sistema"),
                new Functionality(4, "Manter menus", "Funcionalidade para manter todos os menus do sistema"),
                new Functionality(5, "Manter perfis do usuario", "Funcionalidade para manter todos os perfeis de usuarios"),
                new Functionality(6, "Manter funcionalidade perfis", "Funcionalidade para manter todos os menus do sistema"),
                new Functionality(7, "Manter perfil próprio", "Funcionalidade para manter o próprio perfil no sistema")
            );
        }
    }
}
