using ControleAcesso.Domain.Entities;

namespace ControleAcesso.Domain.Interfaces
{
    public interface IFunctionalityProfileRepository : IGenericRepository<FunctionalityProfile>
    {
        Task<FunctionalityProfile> GetAllAsync();
        Task<FunctionalityProfile> GetByIdAsync(int id);
        Task<FunctionalityProfile> GetByProfileIdAsync(int profileId);
        Task<FunctionalityProfile> GetByFunctionalityIdAsync(int functionalityId);
    }
}