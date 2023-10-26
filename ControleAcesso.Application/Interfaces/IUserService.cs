using ControleAcesso.Application.DTOs;

namespace ControleAcesso.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> GetById(long id);
        Task<UserDTO> GetByEmail(string email);
        Task<UserDTO> GetByUserName(string userName);
        Task<IEnumerable<UserDTO>> GetAll();
        Task<Object> Login(UserLoginDTO model, string ipClient);
        Task<Object> Create(UserRegistrationDTO model, string ipClient);
        Task<UserDTO> Update(UserDTO model, long userId);
        Task<UserDTO> Delete(long id);
    }
}