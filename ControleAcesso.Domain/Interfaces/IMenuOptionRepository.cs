using ControleAcesso.Domain.Entities;

namespace ControleAcesso.Domain.Interfaces
{
    public interface IMenuOptionRepository : IGenericRepository<MenuOption>
    {
        Task<IEnumerable<MenuOption>> GetAllAsync();
        Task<MenuOption> GetByIdAsync(int id);
        Task<IEnumerable<MenuOption>> GetByFunctionalityIdAsync(int functionalityId);
    }
}