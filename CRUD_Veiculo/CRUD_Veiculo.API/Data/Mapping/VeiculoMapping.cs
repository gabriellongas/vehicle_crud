using CRUD_Veiculo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Veiculo.API.Data.Mapping
{
    public static class VeiculoMapping
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Veiculo>(entity =>
            {
                entity.ToTable("veiculos");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Chassi).HasColumnName("chassi").HasMaxLength(17);
                entity.Property(e => e.Montadora).HasColumnName("montadora").HasMaxLength(50);
                entity.Property(e => e.Modelo).HasColumnName("modelo").HasMaxLength(50);
                entity.Property(e => e.Placa).HasColumnName("placa").HasMaxLength(8);
                entity.Property(e => e.AnoFabricacao).HasColumnName("ano_fabricacao");
            });

        }
    }
}
