using ControleAcesso.Domain.Entities;
using ControleAcesso.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleAcesso.Infra.Data.Repository
{
    public class UserProfileRepository : GenericRepository<UserProfile>, IUserProfileRepository
    {
        private readonly ApplicationDbContext _context;
        public UserProfileRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<UserProfile>> GetAllAsync()
        {
            return await _context.UsersProfiles
                                    .ToListAsync();
        }
        public async Task<UserProfile> GetByIdAsync(long id)
        {
            return await _context.UsersProfiles
                                    .FirstOrDefaultAsync(up => up.Id == id);
        }
        public async Task<IEnumerable<UserProfile>> GetByProfileIdAsync(long profileId)
        {
            return await _context.UsersProfiles
                                    .Where(up => up.ProfileId == profileId)
                                    .ToListAsync();
        }
        public async Task<IEnumerable<UserProfile>> GetByUserIdAsync(long userId)
        {
            return await _context.UsersProfiles
                                    .Where(up => up.UserId == userId)
                                    .ToListAsync();
        }
    }
}