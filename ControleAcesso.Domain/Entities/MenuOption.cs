using ControleAcesso.Domain.Validation;

namespace ControleAcesso.Domain.Entities
{
    public class MenuOption : BaseEntity
    {
        public string Name { get; private set; }
        public string URL { get; private set; }
        public int Position { get; private set; }
        public long? MenuDad { get; private set; }
        public long FuncionalityId { get; private set; }
        public Functionality Functionality { get; set; }
        protected MenuOption() { }
        public MenuOption(string name, string url, int position, long? menuDad, long funcionalityId) 
        { 
            ValidateDomain(name, url, position, menuDad, funcionalityId);
            Position = position;
            MenuDad = menuDad;
            FuncionalityId = funcionalityId;
            Active = true;
        }
        private void ValidateDomain(string name, string url, int position, long? menuDad, long funcionalityId)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Nome invalido. Nome é obrigatório.");
            DomainExceptionValidation.When(name.Length < 3, "Nome invávido. Nome deve contar mais de 3 caracteres.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(url), "URL invalida. URL é obrigatória.");
            DomainExceptionValidation.When(url.Length < 5, "URL invávida. URL deve contar mais de 5 caracteres.");
            DomainExceptionValidation.When(position <= 0, "Posição invávida. Posição deve ser maior que 0.");
            if(menuDad.HasValue)
            {
                DomainExceptionValidation.When(menuDad <= 0, "Menu invávido. Menu deve ter o id maior que 0.");
            }
            DomainExceptionValidation.When(funcionalityId <= 0, "Funcionalidade invávida. Funcionalidade deve ter o id maior que 0.");
            Name = name;
            URL = url;
            Position = position;
            MenuDad = menuDad;
            FuncionalityId = funcionalityId;
        }
    }
}