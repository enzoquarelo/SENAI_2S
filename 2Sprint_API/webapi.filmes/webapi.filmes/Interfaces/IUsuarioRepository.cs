using System.Data.SqlClient;
using webapi.filmes.Domains;

namespace webapi.filmes.Interfaces
{
    public interface IUsuarioRepository
    {
        UsuarioDomain Login(string email, string senha);

    }
}