using webapi.inlock.senai.Domains;

namespace webapi.inlock.senai.Interfaces
{
    public interface ITiposUsuarioRepository
    {
        List<TiposUsuarioDomain> ListarTodos();
    }
}
