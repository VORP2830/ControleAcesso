using ControleAcesso.Application.DTOs;

namespace ControleAcesso.Application.Interfaces
{
    public interface IProfileService
    {
        Task<ProfileDTO> GetById(long id);  
        Task<IEnumerable<ProfileDTO>> GetAll();  
        Task<ProfileDTO> Create(ProfileDTO model);  
        Task<ProfileDTO> Update(ProfileDTO model);  
        Task<ProfileDTO> Delete(long id);  
    }
}