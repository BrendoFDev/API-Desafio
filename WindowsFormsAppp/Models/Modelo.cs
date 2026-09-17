using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppp.Models
{
    internal class Modelo
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "O Modelo é obrigatória.")]
        [StringLength(100, ErrorMessage = " O Modelo deve ter no máximo 100 caracteres.")]
        public string NomeModelo { get; set; }

        public int MarcaId { get; set; }
        public Marca Marca { get; set; }


        public ICollection<Carro> Carros { get; set; } = new List<Carro>();

    }
}
