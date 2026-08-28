using System.ComponentModel.DataAnnotations;

namespace Back.DTO_s
{
    public class UserDTO
    {
     


        
        [StringLength(50, ErrorMessage = "O nome deve ter no máximo 50 caracteres.")]
        public string? Username { get; set; }

        [EmailAddress(ErrorMessage = "O e-mail inserido não é válido.")]
        [StringLength(100, ErrorMessage = "O email deve ter no máximo 100 caracteres.")]
        public string? Email { get; set; }

        
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string? Senha { get; set; }
    }
}
