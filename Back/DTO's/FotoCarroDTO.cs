using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Back.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Back.DTO_s
{
    public class FotoCarroDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O conteúdo é obrigatório.")]

        [NotMapped]
        public IFormFile Conteudo { get; set; }

        public byte[]? FotoBytes { get; set; }

        public int CarroId { get; set; }

        [BindNever]
        [JsonIgnore]
        public Carro? Carro { get; set; }


    }
}
