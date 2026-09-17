using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Back.Models;

namespace WindowsFormsAppp.Models
{
    internal class Carro
    {
        public int Id { get; set; }

        public int ModeloId { get; set; }
        public Modelo Modelo { get; set; }

        public int MarcaId { get; set; }

        public Marca Marca { get; set; }

        [Required(ErrorMessage = "O ano é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O ano deve ser maior que zero.")]
        public int Ano { get; set; }

        [Required(ErrorMessage = "A cor é obrigatória.")]
        [StringLength(50, ErrorMessage = "A cor deve ter no máximo 50 caracteres.")]
        public string Cor { get; set; }

        //   public string ModeloNome { get; set; }
        //  public string? MarcaNome { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        public float Preco { get; set; }

        public ICollection<Reserva> Reservas { get; set; } = [];
        public List<FotoCarro> Fotos { get; set; } = new List<FotoCarro>();
    }
}
