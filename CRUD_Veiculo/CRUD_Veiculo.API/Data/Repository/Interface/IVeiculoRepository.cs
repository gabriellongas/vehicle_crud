using CRUD_Veiculo.API.Entities;

namespace CRUD_Veiculo.API.Data.Repository.Interface
{
    public interface IVeiculoRepository : IDisposable
    {
        Task<IEnumerable<Veiculo>> GetAll();
        Task<IEnumerable<Veiculo>> GetById(int id);
        Task<int> Create(Veiculo veiculo);
        Task<int> Update(Veiculo veiculo);
        Task<int> Delete(int id);
    }
}
