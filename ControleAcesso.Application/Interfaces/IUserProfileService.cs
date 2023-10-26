using ControleAcesso.Application.DTOs;

namespace ControleAcesso.Application.Interfaces
{
    public interface IUserProfileService
    {
        Task<UserProfileDTO> GetById(long id); 
        Task<IEnumerable<UserProfileDTO>> GetAll(); 
        Task<IEnumerable<UserProfileDTO>> GetByProfileId(long profileId); 
        Task<IEnumerable<UserProfileDTO>> GetByUserId(long userId); 
        Task<UserProfileDTO> Create(UserProfileDTO model); 
        Task<UserProfileDTO> Update(UserProfileDTO model); 
        Task<UserProfileDTO> Delete(long id); 
    }
}