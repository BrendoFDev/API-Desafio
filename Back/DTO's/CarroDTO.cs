using System.ComponentModel.DataAnnotations;
using Back.Models;

namespace Back.DTO_s
{
    public class CarroDTO
    {
        [Required(ErrorMessage = "O preço é obrigatório.")]
        public float Preco { get; set; }

        [Required(ErrorMessage = "A cor é obrigatória.")]
        public string Cor { get; set; }

        [Required(ErrorMessage = "O ano é obrigatório.")]
        public int Ano { get; set; }

        public Modelo? Modelo { get; set; }

       
        public Marca? Marca { get; set; }

        [Required(ErrorMessage = "O ID da Marca é obrigatório.")]
        public int MarcaId { get; set; }

        [Required(ErrorMessage = "O ID do Modelo é obrigatório.")]
        public int ModeloId { get; set; }
        public List<string>? Fotos  { get; set; }
    }
}
