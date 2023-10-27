using ControleAcesso.Domain.Validation;

namespace ControleAcesso.Domain.Entities
{
    public class MenuOption : BaseEntity
    {
        public string Name { get; private set; }
        public string URL { get; private set; }
        public int Position { get; private set; }
        public long? MenuDadId { get; private set; }
        public long? FunctionalityId { get; private set; }
        public MenuOption MenuDad { get; private set; }
        public Functionality Functionality { get; private set; }
        protected MenuOption() { }
        public MenuOption(string name, string url, int position, long? menuDadId, long? functionalityId) 
        { 
            ValidateDomain(name, url, position, menuDadId, functionalityId);
            Position = position;
            MenuDadId = menuDadId;
            FunctionalityId = functionalityId;
            Active = true;
        }
        public MenuOption(long id, string name, string url, int position, long? menuDadId, long? functionalityId) 
        { 
            DomainExceptionValidation.When(id < 0, "Id invalido. O id deve ser maior que 0");
            Id = id;
            ValidateDomain(name, url, position, menuDadId, functionalityId);
            Position = position;
            MenuDadId = menuDadId;
            FunctionalityId = functionalityId;
            Active = true;
        }
        private void ValidateDomain(string name, string url, int position, long? menuDadId, long? functionalityId)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Nome invalido. Nome é obrigatório.");
            DomainExceptionValidation.When(name.Length < 3, "Nome invávido. Nome deve contar mais de 3 caracteres.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(url), "URL invalida. URL é obrigatória.");
            DomainExceptionValidation.When(url.Length < 5, "URL invávida. URL deve contar mais de 5 caracteres.");
            DomainExceptionValidation.When(position <= 0, "Posição invávida. Posição deve ser maior que 0.");
            if(menuDadId.HasValue)
            {
                DomainExceptionValidation.When(menuDadId <= 0, "Menu invávido. Menu deve ter o id maior que 0.");
            }
            DomainExceptionValidation.When(functionalityId <= 0, "Funcionalidade invávida. Funcionalidade deve ter o id maior que 0.");
            Name = name;
            URL = url;
            Position = position;
            MenuDadId = menuDadId;
            FunctionalityId = functionalityId;
        }
    }
}