using CRUD_Veiculos.Web.Models;

namespace CRUD_Veiculos.Web.API.Interface
{
    public interface IApiClient
    {
        IEnumerable<Veiculo> GetAll();
        Veiculo GetById(int id);
        bool Create(Veiculo veiculo);
        bool Update(Veiculo veiculo);
        bool Delete(int id);
    }
}