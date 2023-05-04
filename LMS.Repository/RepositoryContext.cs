using LMS.Repository.EntitiesConfiguration;
using LMS.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace LMS.Repository {
    public class RepositoryContext : DbContext {

        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration<User>(new UserConfiguration());
            
        }

        public DbSet<User> Users { get; set; }

    }
}
