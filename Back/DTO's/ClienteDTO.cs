using System.ComponentModel.DataAnnotations;

namespace Back.DTO_s
{
    public class ClienteDTO
    {

    
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string? nome { get; set; }

        [StringLength(100, ErrorMessage = "O CPF deve ter no máximo 100 caracteres.")]
        public string? cpf { get; set; }



    }
}
