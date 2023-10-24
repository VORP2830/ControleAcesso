using ControleAcesso.Domain.Entities;
using ControleAcesso.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleAcesso.Infra.Data.Repository
{
    public class FunctionalityProfileRepository : GenericRepository<FunctionalityProfile>, IFunctionalityProfileRepository
    {
        private readonly ApplicationDbContext _context;
        public FunctionalityProfileRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<FunctionalityProfile>> GetAllAsync()
        {
            return await _context.FunctionalitiesProfiles
                                    .ToListAsync();
        }
        public async Task<FunctionalityProfile> GetByIdAsync(int id)
        {
            return await _context.FunctionalitiesProfiles
                                    .FirstOrDefaultAsync(fp => fp.Id == id);
        }
        public async Task<IEnumerable<FunctionalityProfile>> GetByFunctionalityIdAsync(int functionalityId)
        {
            return await _context.FunctionalitiesProfiles
                                    .Where(fp => fp.FunctionalityId == functionalityId)
                                    .ToListAsync();
        }
        public async Task<IEnumerable<FunctionalityProfile>> GetByProfileIdAsync(int profileId)
        {
            return await _context.FunctionalitiesProfiles
                                    .Where(fp => fp.ProfileId == profileId)
                                    .ToListAsync();
        }
    }
}