using ControleAcesso.Domain.Validation;

namespace ControleAcesso.Domain.Entities
{
    public class Methods : BaseEntity
    {
        public string Description { get; private set; }
        public string ClassName { get; private set; }
        public string Action { get; private set; }
        public long FunctionalityId { get; private set; }
        public Functionality Functionality { get; private set; }
        protected Methods() { }
        public Methods(string description, string className, string action, long functionalityId)
        {
            ValidateDomain(description, className, action, functionalityId);
            Active = true;
        }
        public Methods(long id, string description, string className, string action, long functionalityId)
        {
            DomainExceptionValidation.When(id < 0, "Id invalido. O id deve ser maior que 0");
            Id = id;
            ValidateDomain(description, className, action, functionalityId);
            Active = true;
        }
        private void ValidateDomain(string description, string className, string action, long functionalityId)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Descrição invalida. Descrição é obrigatória.");
            DomainExceptionValidation.When(description.Length < 5, "Descrição invávida. Descrição deve contar mais de 5 caracteres.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(className), "Classe invalida. Classe é obrigatória.");
            DomainExceptionValidation.When(className.Length < 5, "Classe invávida. Classe deve contar mais de 5 caracteres.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(action), "Ação invalida. Ação é obrigatória.");
            DomainExceptionValidation.When(action.Length < 5, "Ação invávido. Ação deve contar mais de 5 caracteres.");
            DomainExceptionValidation.When(functionalityId <= 0 , "Funcionalidade invávida. Funcionalidade deve ter o id maior que 0.");
            Description = description;
            ClassName = className;
            Action = action;
            FunctionalityId = functionalityId;
        }
    }
}