using System.ComponentModel.DataAnnotations;

namespace ChapterOi.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o E-mail do usuário")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a Senha do usuário")]
        public string Senha { get; set; }
    }
}
