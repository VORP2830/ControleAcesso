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

            builder.Property(m => m.ClassName)
                        .HasMaxLength(50)
                        .IsRequired();

            builder.Property(m => m.Action)
                        .HasMaxLength(100)
                        .IsRequired();
            
            builder.Property(m => m.Description)
                        .HasMaxLength(300)
                        .IsRequired();

            builder.HasOne(m => m.Functionality)
                        .WithMany(m => m.Methods)
                        .HasForeignKey(m => m.FunctionalityId);
                        
             builder.HasData(
				new Methods(1, "Pegar todos os usuarios do sistema", "UserController", "GetAllUsers", 1),
				new Methods(2, "Pegar qualquer usuario do sistema por id", "UserController", "GetById", 1),
				new Methods(3, "Deletar qualquer usuario do sistema", "UserController", "Delete", 1),
				
				new Methods(36, "Pegar o proprio usuário do sistema", "UserController", "GetPersonalUser", 7),
				new Methods(37, "Alterar o proprio usuário do sistema", "UserController", "UpdatePerosnalUser", 7),
				new Methods(21, "Pegar menus do proprio usuário", "MenuOptionController", "GetForUserId", 7),
				
				new Methods(4, "Pegar todos os metodos do sistema", "MethodController", "GetAllMethod", 2),
				new Methods(5, "Pegar metodo por id do sistema", "MethodController", "GetById", 2),
				new Methods(6, "Pegar metodos por funcionalidade", "MethodController", "GetByFunctionalityId", 2),
				new Methods(7, "Criar metodo", "MethodController", "Create", 2),
				new Methods(8, "Atualizar metodo", "MethodController", "Update", 2),
				new Methods(9, "Deletar metodo", "MethodController", "Delete", 2),
				new Methods(38, "Verificação externa de ações", "MethodController", "ValidateAccessClassMethod", 2),
				
				new Methods(10, "Pegar todas as funcionalidades do sistema", "FunctionalityController", "GetAllFunctionality", 3),
				new Methods(11, "Pegar funcionalidade por id", "FunctionalityController", "GetById", 3),
				new Methods(12, "Criar funcionalidades", "FunctionalityController", "Create", 3),
				new Methods(13, "Atualizar funcionalidades", "FunctionalityController", "Update", 3),
				new Methods(14, "Deletar funcionalidades", "FunctionalityController", "Delete", 3),

				new Methods(15, "Pegar todos os menus", "MenuOptionController", "GetAllMenuOption", 4),
				new Methods(16, "Pegar menu por id", "MenuOptionController", "GetById", 4),
				new Methods(17, "Pegar menus por menu", "MenuOptionController", "GetByFunctionalityId", 4),
				new Methods(18, "Criar menu", "MenuOptionController", "Create", 4),
				new Methods(19, "Alterar menus", "MenuOptionController", "Update", 4),
				new Methods(20, "Deletar menus", "MenuOptionController", "Delete", 4),
				
				new Methods(22, "Pegar todas as funcionalidades perfis do sistema", "FunctionalityProfileController", "GetAllFunctionalityProfiles", 5),
				new Methods(23, "Pegar funcionalidade perfil por id", "FunctionalityProfileController", "GetById", 5),
				new Methods(24, "Pegar funcionalidades perfis por funcionalidade", "FunctionalityProfileController", "GetByFunctionalityId", 5),
				new Methods(25, "Pegar funcionalidade perfis por perfil", "FunctionalityProfileController", "GetByProfileId", 5),
				new Methods(26, "Criar funcionalidade perfil", "FunctionalityProfileController", "Create", 5),
				new Methods(27, "Alterar funcionalidade perfil", "FunctionalityProfileController", "Update", 5),
				new Methods(28, "Deletar funcionalidade perfil", "FunctionalityProfileController", "Delete", 5),
				
				new Methods(29, "Pegar todos os usuários perfis do sistema", "UserProfileController", "GetAllUserProfiles", 6),
				new Methods(30, "Pegar usuários perfil por id", "UserProfileController", "GetById", 6),
				new Methods(31, "Pegar usuários perfis por usuários", "UserProfileController", "GetByUserId", 6),
				new Methods(32, "Pegar usuários perfis por perfil", "UserProfileController", "GetByProfileId", 6),
				new Methods(33, "Criar usuário perfil", "UserProfileController", "Create", 6),
				new Methods(34, "Alterar usuário perfil", "UserProfileController", "Update", 6),
				new Methods(35, "Deletar usuário perfil", "UserProfileController", "Delete", 6)
            );
        }
    }
}
