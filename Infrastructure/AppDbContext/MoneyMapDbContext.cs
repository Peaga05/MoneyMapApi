using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.AppDbContext
{
    public class MoneyMapDbContext : DbContext
    {
        public MoneyMapDbContext(DbContextOptions<MoneyMapDbContext> options)
        : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
