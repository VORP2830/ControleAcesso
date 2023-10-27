using ControleAcesso.Domain.Entities;

namespace ControleAcesso.Domain.Interfaces
{
    public interface IMenuOptionRepository : IGenericRepository<MenuOption>
    {
        Task<IEnumerable<MenuOption>> GetAllAsync();
        Task<MenuOption> GetByIdAsync(long id);
        Task<IEnumerable<MenuOption>> GetByFunctionalityIdAsync(long functionalityId);
        Task<IEnumerable<MenuOption>> GetForUserIdAsync(long userId);
    }
}