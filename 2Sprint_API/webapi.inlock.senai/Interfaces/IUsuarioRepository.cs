using webapi.inlock.senai.Domains;

namespace webapi.inlock.senai.Interfaces
{
    public interface IUsuarioRepository
    {
        UsuarioDomain Login(string Email, string Senha);
    }
}
