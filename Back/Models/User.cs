using System.ComponentModel.DataAnnotations;

namespace Back.Models
{
    public class User
    {
     
        public int Id { get; set; }


        [Required(ErrorMessage = "O nome de usuário é obrigatório.")]
        [StringLength(50, ErrorMessage = "O nome deve ter no máximo 50 caracteres.")]
        public string Username { get; set; }


        [EmailAddress(ErrorMessage = "O e-mail inserido não é válido.")]

        [Required(ErrorMessage = "O Email é obrigatório.")]
        [StringLength(100, ErrorMessage = "O email deve ter no máximo 100 caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string Senha { get; set; }

      

}

   
}
