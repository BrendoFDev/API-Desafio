using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsAppp.Models;
namespace WindowsFormsAppp.DTO_s
{
    internal class ClienteDTO
    {
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string? Nome { get; set; }

        [StringLength(11, ErrorMessage = "O CPF deve ter no máximo 11 caracteres.")]
        public string? Cpf { get; set; }
    }
}
