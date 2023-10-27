using ControleAcesso.Application.DTOs;

namespace ControleAcesso.Application.Interfaces
{
    public interface IMenuOptionService
    {
        Task<MenuOptionDTO> GetById(long id);
        Task<IEnumerable<MenuOptionDTO>> GetAll();
        Task<IEnumerable<MenuOptionDTO>> GetByFunctionalityId(long functionalityId);
        Task<MenuOptionDTO> Create(MenuOptionDTO model);
        Task<MenuOptionDTO> Update(MenuOptionDTO model);
        Task<MenuOptionDTO> Delete(long id);
        Task<IEnumerable<MenuOptionDTO>> GetForUserIdAsync(long userId);
    }
}