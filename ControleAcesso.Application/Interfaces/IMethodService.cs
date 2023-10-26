using ControleAcesso.Application.DTOs;

namespace ControleAcesso.Application.Interfaces
{
    public interface IMethodService
    {
        Task<MethodDTO> GetById(long id);
        Task<IEnumerable<MethodDTO>> GetAll();
        Task<IEnumerable<MethodDTO>> GetByFunctionalityId(long functionalityId);
        Task<MethodDTO> Create(MethodDTO model);
        Task<MethodDTO> Update(MethodDTO model);
        Task<MethodDTO> Delete(long id);
    }
}