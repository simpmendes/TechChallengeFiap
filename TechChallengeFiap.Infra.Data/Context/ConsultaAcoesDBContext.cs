using TechChallengeFiap.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace TechChallengeFiap.Infra.Data.Context
{
    public partial class ConsultaAcoesDBContext : DbContext
    {
        public virtual DbSet<ConsultaAcoes> Produtos { get; set; }

        public ConsultaAcoesDBContext()
        {
        }

        public ConsultaAcoesDBContext(DbContextOptions<ConsultaAcoesDBContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
