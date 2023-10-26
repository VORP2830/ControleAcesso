using ControleAcesso.Domain.Entities;
using ControleAcesso.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleAcesso.Infra.Data.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) : base(context)
        { 
            _context = context;
        }
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users
                                    .ToListAsync();
        }
        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users
                                    .FirstOrDefaultAsync(u => u.Email == email);
        }
        public async Task<User> GetByIdAsync(long id)
        {
            return await _context.Users
                                    .FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task<User> GetByUserNameAsync(string userName)
        {
            return await _context.Users
                                    .FirstOrDefaultAsync(u => u.UserName == userName);
        }
    }
}