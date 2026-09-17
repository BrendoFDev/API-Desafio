using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsAppp.Models;

namespace WindowsFormsAppp.DTO_s
{
    internal class ModeloDTO
    {
        public int? id { get; set; }
        [Required(ErrorMessage = "O Modelo é obrigatório.")]
        [StringLength(100, ErrorMessage = "O Modelo deve ter no máximo 100 caracteres.")]
        public string NomeModelo { get; set; }

        [Required(ErrorMessage = "O Id da Marca é obrigatório.")]
        public int MarcaId { get; set; }

        public Marca? Marca { get; set; }
    }
}
