using System.ComponentModel.DataAnnotations;
using Back.Models;

namespace Back.DTO_s
{
    public class ModeloDTO
    {
        [Required(ErrorMessage = "O Modelo é obrigatório.")]
        [StringLength(100, ErrorMessage = "O Modelo deve ter no máximo 100 caracteres.")]
        public string NomeModelo { get; set; }

        [Required(ErrorMessage = "O Id da Marca é obrigatório.")]
        public int MarcaId { get; set; }

        public Marca Marca { get; set; }
    }
}
