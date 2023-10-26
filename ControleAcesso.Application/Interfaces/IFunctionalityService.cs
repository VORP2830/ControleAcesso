using ControleAcesso.Application.DTOs;

namespace ControleAcesso.Application.Interfaces
{
    public interface IFunctionalityService
    {
        Task<FunctionalityDTO> GetById(long id);
        Task<IEnumerable<FunctionalityDTO>> GetAll();
        Task<FunctionalityDTO> Create(FunctionalityDTO model);
        Task<FunctionalityDTO> Update(FunctionalityDTO model);
        Task<FunctionalityDTO> Delete(long id);
    }
}