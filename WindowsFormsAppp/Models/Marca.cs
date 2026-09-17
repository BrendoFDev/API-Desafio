using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppp.Models
{
    internal class Marca
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "A Marca é obrigatória.")]
        [StringLength(100, ErrorMessage = " A Marca deve ter no máximo 100 caracteres.")]
        public string NomeMarca { get; set; }




        public ICollection<Carro> Carros { get; set; } = new List<Carro>();


    }
}
