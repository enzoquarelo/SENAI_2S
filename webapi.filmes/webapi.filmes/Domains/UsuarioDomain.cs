using System.ComponentModel.DataAnnotations;

namespace webapi.filmes.Domains
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Campo nome obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo e-mail obrigatório!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo senha obrigatório!")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O usuário deve possuir uma permição, comum ou administrador!")]
        public bool IsAdmin { get; set; }
    }
}
