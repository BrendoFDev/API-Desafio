using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.Json.Serialization;

namespace Back.Models
{
    public class FotoCarro
    {
        public int Id { get; set; }

        [NotMapped]
        public IFormFile Conteudo { get; set; }

        public byte[]? FotoBytes { get; set; }

        [ForeignKey("CarroId")]
        public int CarroId { get; set; }

        [BindNever]
        [JsonIgnore]
        public Carro? Carro { get; set; }
    }
}
