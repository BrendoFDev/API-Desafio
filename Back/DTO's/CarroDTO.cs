using System.ComponentModel.DataAnnotations;

namespace Back.DTO_s
{
    public class CarroDTO
    {
        [StringLength(100, ErrorMessage = "O modelo deve ter no máximo 100 caracteres.")]
        public string? Modelo { get; set; }

      
        [StringLength(100, ErrorMessage = " A Marca deve ter no máximo 100 caracteres.")]
        public string? Marca { get; set; }

       
        [Range(0.01, int.MaxValue, ErrorMessage = "O ano deve ser maior que zero.")]

        public int? Ano { get; set; }

       
        [StringLength(50, ErrorMessage = " a cor deve ter no máximo 50 caracteres.")]
        public string? Cor { get; set; }

      
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        public float? Preco { get; set; }
    }
}
