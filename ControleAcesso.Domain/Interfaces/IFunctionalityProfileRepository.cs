using ControleAcesso.Domain.Entities;

namespace ControleAcesso.Domain.Interfaces
{
    public interface IFunctionalityProfileRepository : IGenericRepository<FunctionalityProfile>
    {
        Task<IEnumerable<FunctionalityProfile>> GetAllAsync();
        Task<FunctionalityProfile> GetByIdAsync(int id);
        Task<IEnumerable<FunctionalityProfile>> GetByProfileIdAsync(int profileId);
        Task<IEnumerable<FunctionalityProfile>> GetByFunctionalityIdAsync(int functionalityId);
    }
}