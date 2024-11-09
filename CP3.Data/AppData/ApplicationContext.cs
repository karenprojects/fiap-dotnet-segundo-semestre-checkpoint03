using CP3.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CP3.Infrastructure
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<BarcoEntity> Barcos { get; set; }

        // Configurações adicionais para tabelas e relacionamentos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
