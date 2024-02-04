using CRUD_Veiculo.API.Data.Mapping;
using CRUD_Veiculo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Veiculo.API.Data.Context
{
    public class CRUDContext : DbContext
    {
        public CRUDContext(DbContextOptions<CRUDContext> options) : base(options)
        {
        }

        public virtual DbSet<Veiculo> Veiculo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            VeiculoMapping.Configure(modelBuilder);
        }
    }
}
