using ControleAcesso.Domain.Validation;

namespace ControleAcesso.Domain.Entities
{
    public class Methods : BaseEntity
    {
        public string Description { get; private set; }
        public string Class { get; private set; }
        public string Method { get; private set; }
        public long FunctionalityId { get; private set; }
        public Functionality Functionality { get; set; }
        protected Methods() { }
        public Methods(string description, string classe, string method, long functionalityId)
        {
            ValidateDomain(description, classe, method, functionalityId);
            Active = true;
        }
        private void ValidateDomain(string description, string classe, string method, long functionalityId)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Descrição invalida. Descrição é obrigatória.");
            DomainExceptionValidation.When(description.Length < 5, "Descrição invávida. Descrição deve contar mais de 5 caracteres.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(classe), "Classe invalida. Classe é obrigatória.");
            DomainExceptionValidation.When(classe.Length < 5, "Classe invávida. Classe deve contar mais de 5 caracteres.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(method), "Metodo invalido. Metodo é obrigatório.");
            DomainExceptionValidation.When(method.Length < 5, "Metodo invávido. Metodo deve contar mais de 5 caracteres.");
            DomainExceptionValidation.When(functionalityId <= 0 , "Funcionalidade invávida. Funcionalidade deve ter o id maior que 0.");
            Description = description;
            Class = classe;
            Method = method;
            FunctionalityId = functionalityId;
        }
    }
}