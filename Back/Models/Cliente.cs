using System.ComponentModel.DataAnnotations;

namespace Back.Models
{
    public class Cliente
    {
        public int id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [StringLength(100, ErrorMessage = "O CPF deve ter no máximo 100 caracteres.")]
        public string Cpf { get; set; }

        public DateOnly dataDeCriacao { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        
        public ICollection<Reserva> Reservas {  get; set; } = [];
    }
}
