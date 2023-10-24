using ControleAcesso.Domain.Entities;

namespace ControleAcesso.Domain.Interfaces
{
    public interface IMenuOptionRepository : IGenericRepository<MenuOption>
    {
        Task<MenuOption> GetAllAsync();
        Task<MenuOption> GetByIdAsync(int id);
        Task<MenuOption> GetByFunctionalityIdAsync(int functionalityId);
    }
}