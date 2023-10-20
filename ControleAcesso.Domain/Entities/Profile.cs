using ControleAcesso.Domain.Validation;

namespace ControleAcesso.Domain.Entities
{
    public class Profile : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<UserProfile> UserProfiles { get; private set; }
        public IEnumerable<FunctionalityProfile> FunctionalityProfiles { get; private set; }
        protected Profile() { }
        public Profile(string name, string description)
        {
            ValidateDomain(name, description);
            Active = true;
        }
        private void ValidateDomain(string name, string description)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Nome invalido. Nome é obrigatório.");
            DomainExceptionValidation.When(name.Length < 3, "Nome invávido. Nome deve contar mais de 3 caracteres.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Descrição invalida. Descrição é obrigatória.");
            DomainExceptionValidation.When(description.Length < 5, "Descrição invávida. Descrição deve contar mais de 5 caracteres.");
            Name = name;
            Description = description;
        }
    }
}