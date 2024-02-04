using CRUD_Veiculo.API.Data.Context;
using CRUD_Veiculo.API.Data.Repository.Interface;
using CRUD_Veiculo.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Data.Entity.Core;
using System.Data.SqlClient;

namespace CRUD_Veiculo.API.Data.Repository
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private bool disposedValue;
        private CRUDContext _context;

        public VeiculoRepository(CRUDContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Veiculo>> GetAll()
        {
            var result = await _context.Veiculo.FromSqlRaw("EXEC sp_GetTodosVeiculos").ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Veiculo>> GetById(int id)
        {
            var result = await _context.Veiculo.FromSql($"EXEC sp_GetVeiculoPorID {id}").ToListAsync();
            return result;
        }

        public async Task<int> Create(Veiculo veiculo)
        {
            try
            {
                var result = await _context.Database.ExecuteSqlAsync($"EXEC sp_InserirVeiculo {veiculo.Chassi}, {veiculo.Montadora}, {veiculo.Modelo}, {veiculo.Placa}, {veiculo.AnoFabricacao}");
                return result; ;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Update(Veiculo veiculo)
        {
            var result = await _context.Database.ExecuteSqlAsync($"EXEC sp_AtualizarVeiculo {veiculo.Id}, {veiculo.Chassi}, {veiculo.Montadora}, {veiculo.Modelo}, {veiculo.Placa}, {veiculo.AnoFabricacao}");
            return result;
        }

        public async Task<int> Delete(int id)
        {
            var result = await _context.Database.ExecuteSqlAsync($"EXEC sp_DeletarVeiculo {id}");
            return result;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
