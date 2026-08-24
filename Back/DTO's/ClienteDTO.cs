using System.ComponentModel.DataAnnotations;

namespace Back.DTO_s
{
    public class ClienteDTO
    {

    
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string? Nome { get; set; }

        [StringLength(11, ErrorMessage = "O CPF deve ter no máximo 11 caracteres.")]
        public string? Cpf { get; set; }



    }
}
