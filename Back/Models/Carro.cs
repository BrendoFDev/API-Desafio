using System.ComponentModel.DataAnnotations;

namespace Back.Models
{
    public class Carro
    {
       
        public long Id { get; set; }

        [Required(ErrorMessage = "O modelo é obrigatório.")]
        [StringLength(100, ErrorMessage = "O modelo deve ter no máximo 100 caracteres.")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "A Marca é obrigatória.")]
        [StringLength(100, ErrorMessage =" A Marca deve ter no máximo 100 caracteres.")]
        public string  Marca { get; set; }

        [Required(ErrorMessage = "O ano é obrigatório.")]
        [Range(0.01, int.MaxValue, ErrorMessage = "O ano deve ser maior que zero.")]

        public int Ano { get; set; }

        [Required(ErrorMessage = "A Cor é obrigatório.")]
        [StringLength(50, ErrorMessage = " a cor deve ter no máximo 50 caracteres.")]
        public string Cor { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        public float Preco { get; set; }

        public ICollection<Reserva> Reservas { get; set; } = [];

    }
}
