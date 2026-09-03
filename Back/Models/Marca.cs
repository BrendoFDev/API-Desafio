using System.ComponentModel.DataAnnotations;

namespace Back.Models
{
    public class Marca
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A Marca é obrigatória.")]
        [StringLength(100, ErrorMessage = " A Marca deve ter no máximo 100 caracteres.")]
        public string NomeMarca { get; set; }




        public ICollection<Carro> Carros { get; set; }= new List<Carro>();

    }
}
