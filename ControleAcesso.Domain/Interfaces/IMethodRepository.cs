using ControleAcesso.Domain.Entities;

namespace ControleAcesso.Domain.Interfaces
{
    public interface IMethodRepository : IGenericRepository<Methods>
    {
        Task<Methods> GetAllAsync();
        Task<Methods> GetByIdAsync(int id);
        Task<Methods> GetByFunctionalityIdAsync(int functionalityId);
    }
}