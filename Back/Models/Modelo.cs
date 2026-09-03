using System.ComponentModel.DataAnnotations;

namespace Back.Models
{
    public class Modelo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O Modelo é obrigatória.")]
        [StringLength(100, ErrorMessage = " O Modelo deve ter no máximo 100 caracteres.")]
        public string NomeModelo { get; set; }

        public int MarcaId {  get; set; }
        public Marca Marca { get; set; }


        public ICollection<Carro> Carros { get; set; } = new List<Carro>(); 
    }

}
