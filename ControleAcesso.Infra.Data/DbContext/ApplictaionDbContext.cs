using ControleAcesso.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControleAcesso.Infra.Data;

public class ApplicationDbContext : DbContext
{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAccess> UsersAccesses { get; set; }
        public DbSet<UserProfile> UsersProfiles { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Methods> Methods { get; set; }
        public DbSet<MenuOption> MenuOptions { get; set; }
        public DbSet<Functionality> Functionalities { get; set; }
        public DbSet<FuncionalityProfile> FuncionalitiesProfiles { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
                .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                entry.Entity.ModifiedAt = DateTime.Now;
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.Now;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
}
