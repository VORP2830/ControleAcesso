using System.Text.RegularExpressions;
using ControleAcesso.Domain.Validation;

namespace ControleAcesso.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; private set; } 
        public string Email { get; private set; } 
        public string UserName { get; private set; } 
        public string Password { get; private set; } 
        public bool Active { get; private set; } 
        public bool Blocked { get; private set; } 
        protected User() { }
        public User(string name, string email, string userName, string Password)
        {
            ValidateDomain(name, email, userName, Password);
            Active = true;
            Blocked = false;
        }
        public void SetPassword (string password)
        {
            Password = password;
        }
        public void SetActive(bool active)
        {
            Active = active;
        }
        public void SetBlocked(bool blocked)
        {
            Blocked = blocked;
        }
        private void ValidateDomain(string name, string email, string userName, string password)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Nome invalido. Nome é obrigatório.");
            DomainExceptionValidation.When(name.Length < 3, "Nome invávido. Nome deve contar mais de 3 caracteres.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(email), "Email invalido. Email é obrigatório.");
            DomainExceptionValidation.When(IsInvalidEmail(email), "Email invalido.");  
            DomainExceptionValidation.When(string.IsNullOrEmpty(userName), "userName invalido. userName é obrigatório.");
            DomainExceptionValidation.When(userName.Length < 3, "userName invalido. userName deve contar mais de 3 caracteres.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(password), "Senha invalida. Senha é obrigatória.");
            Name = name;
            Email = email;
            UserName = userName;
            Password = password;
        }
        private static bool IsInvalidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            return !Regex.IsMatch(email, pattern);
        }
    }
}