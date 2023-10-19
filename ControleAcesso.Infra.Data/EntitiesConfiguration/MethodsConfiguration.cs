using ControleAcesso.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleAcesso.Infra.Data
{
    public class MethodConfiguration : IEntityTypeConfiguration<Methods>
    {
        public void Configure(EntityTypeBuilder<Methods> builder)
        {
            builder.HasKey(m => m.Id);

            builder.HasOne(m => m.Functionality)
                .WithMany(f => f.Methods)
                .HasForeignKey(m => m.FunctionalityId);
        }
    }
}
