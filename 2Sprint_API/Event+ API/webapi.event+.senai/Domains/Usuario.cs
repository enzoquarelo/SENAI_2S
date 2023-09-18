using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_.senai.Domains
{
    [Table("Usuario")]
    public class Usuario
    {

        [Key]
        public Guid IdTUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome do usuário é obrigatório!")]
        public string? Nome { get; set; }

        [Column(TypeName = "VARCHAR(256)")]
        [Required(ErrorMessage = "O e-mail é obrigatório!")]
        public string? Email { get; set; }

        [Column(TypeName = "CHAR(60)")]
        [Required(ErrorMessage = "O e-mail é obrigatório!")]
        public string? Senha { get; set; }

    }
}
}
