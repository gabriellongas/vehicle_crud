namespace CRUD_Veiculos.Web.Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string Chassi { get; set; }
        public string Montadora { get; set; }
        public string Modelo { get; set; }
        public string Placa{ get; set; }
        public int AnoFabricacao{ get; set; }
    }
}
