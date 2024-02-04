using CRUD_Veiculos.Web.Models;

namespace CRUD_Veiculos.Web.API.Interface
{
    public interface IApiClient
    {
        IEnumerable<Veiculo> GetAll();
        Task<IEnumerable<Veiculo>> GetById(int id);
        Task<int> Create(Veiculo veiculo);
        Task<int> Update(Veiculo veiculo);
        Task<int> Delete(int id);
    }
}