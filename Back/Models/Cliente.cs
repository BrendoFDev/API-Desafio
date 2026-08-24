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


        public DateOnly dataDeCriacao { get; set; }
        
        public ICollection<Reserva> Reservas {  get; set; } =
        [];

      //  public Cliente(int id, string nome, string cpf)
       // {
       //     this.id = id;
       //     this.nome = nome;
     //       this.cpf = cpf;
      //      dataDeCriacao = DateOnly.FromDateTime(DateTime.Now);
       // }
    }
}
