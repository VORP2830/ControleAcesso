using System.Security.Cryptography;
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
        public async Task<MenuOption> GetByIdAsync(long id)
        {
            return await _context.MenuOptions
                                    .FirstOrDefaultAsync(mo => mo.Id == id);
        }
        public async Task<IEnumerable<MenuOption>> GetByFunctionalityIdAsync(long functionalityId)
        {
            return await _context.MenuOptions
                                    .Where(mo => mo.FunctionalityId == functionalityId)
                                    .ToListAsync();
        }
        public async Task<IEnumerable<MenuOption>> GetForUserIdAsync(long userId)
        {
            return await _context.UsersProfiles
                        .Where(up => up.UserId == userId)
                        .SelectMany(up => up.Profile.FunctionalityProfiles)
                        .Where(fp => fp.Active == true &&
                                        fp.Profile.Active == true)
                        .Select(fp => fp.Functionality.MenuOption)
                        .Where(mo => mo.Active == true && 
                                        mo.Functionality.Active == true)
                        .Where(menuOption => menuOption != null)
                        .ToListAsync();
        }
    }
}