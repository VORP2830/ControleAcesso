using ControleAcesso.Domain.Entities;
using ControleAcesso.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleAcesso.Infra.Data.Repository
{
    public class MenuOptionRepository : GenericRepository<MenuOption>, IMenuOptionRepository
    {
        private readonly ApplicationDbContext _context;

        public MenuOptionRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<MenuOption>> GetAllAsync()
        {
            return await _context.MenuOptions
                                    .ToListAsync();
        }
        public async Task<MenuOption> GetByIdAsync(int id)
        {
            return await _context.MenuOptions
                                    .FirstOrDefaultAsync(mo => mo.Id == id);
        }
        public async Task<IEnumerable<MenuOption>> GetByFunctionalityIdAsync(int functionalityId)
        {
            return await _context.MenuOptions
                                    .Where(mo => mo.FunctionalityId == functionalityId)
                                    .ToListAsync();
        }
    }
}