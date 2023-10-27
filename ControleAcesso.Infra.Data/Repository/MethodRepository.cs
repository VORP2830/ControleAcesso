using ControleAcesso.Domain.Entities;
using ControleAcesso.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleAcesso.Infra.Data.Repository
{
    public class MethodRepository : GenericRepository<Methods>, IMethodRepository
    {
        private readonly ApplicationDbContext _context;
        public MethodRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Methods>> GetAllAsync()
        {
            return await _context.Methods
                                    .ToListAsync();
        }
        public async Task<IEnumerable<Methods>> GetByFunctionalityIdAsync(long functionalityId)
        {
            return await _context.Methods
                                    .Where(m => m.FunctionalityId == functionalityId)
                                    .ToListAsync();
        }
        public async Task<Methods> GetByIdAsync(long id)
        {
            return await _context.Methods
                                    .FirstOrDefaultAsync(m => m.Id == id);
        }
        public async Task<Methods> GetMethodByUserId(long userId, string className, string action)
        {
            return await _context.UsersProfiles
                                    .Where(up => up.UserId == userId)
                                    .SelectMany(up => up.Profile.FunctionalityProfiles)
                                    .SelectMany(fp => fp.Functionality.Methods)
                                    .Where(method => 
                                        method.ClassName == className &&
                                        method.Action == action)
                                    .Distinct()
                                    .FirstOrDefaultAsync();
        }
    }
}