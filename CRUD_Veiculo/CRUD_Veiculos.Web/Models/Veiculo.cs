using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CRUD_Veiculos.Web.Models
{
    public class Veiculo
    {
        //[JsonPropertyName("id")]
        public int Id { get; set; }
        
        //[JsonPropertyName("chassi")]
        [Required(ErrorMessage = "O Chassi deve ser preenchido")]
        public string Chassi { get; set; }
        
        //[JsonPropertyName("montadora")]
        [Required(ErrorMessage = "A Montadora deve ser preenchida")]
        public string Montadora { get; set; }
        
        //[JsonPropertyName("modelo")]
        [Required(ErrorMessage = "O Modelo deve ser preenchido")]
        public string Modelo { get; set; }
        
        //[JsonPropertyName("placa")]
        [Required(ErrorMessage = "A Placa deve ser preenchida")]
        public string Placa{ get; set; }
        
        //[JsonPropertyName("anoFabricacao")]
        [Required(ErrorMessage = "O Ano de Fabricacao deve ser preenchido")]
        public int AnoFabricacao{ get; set; }
    }
}
