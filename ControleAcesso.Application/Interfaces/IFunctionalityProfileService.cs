using ControleAcesso.Application.DTOs;

namespace ControleAcesso.Application.Interfaces
{
    public interface IFunctionalityProfileService
    {
        Task<FunctionalityProfileDTO> GetById(long id);  
        Task<IEnumerable<FunctionalityProfileDTO>> GetAll();
        Task<IEnumerable<FunctionalityProfileDTO>> GetByFunctionalityId(long functionalityId);  
        Task<IEnumerable<FunctionalityProfileDTO>> GetByProfileId(long profileId);
        Task<FunctionalityProfileDTO> Create(FunctionalityProfileDTO model);
        Task<FunctionalityProfileDTO> Update(FunctionalityProfileDTO model); 
        Task<FunctionalityProfileDTO> Delete(long id);  
    }
}