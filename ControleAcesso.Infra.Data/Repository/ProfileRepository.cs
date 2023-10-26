using ControleAcesso.Domain.Entities;
using ControleAcesso.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleAcesso.Infra.Data.Repository
{
    public class ProfileRepository : GenericRepository<Profile>, IProfileRepository
    {
        private readonly ApplicationDbContext _context;
        public ProfileRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Profile>> GetAllAsync()
        {
            return await _context.Profiles
                                    .ToListAsync();
        }
        public async Task<Profile> GetByIdAsync(long id)
        {
            return await _context.Profiles
                                    .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}