using webapi.event_.senai.Contexts;
using webapi.event_.senai.Domains;
using webapi.event_.senai.Interfaces;

namespace webapi.event_.senai.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly EventContext _eventContext;

        public UsuarioRepository()
        {
            _eventContext = new EventContext();
        }

        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public Usuario BuscarPorId(Guid id)
        {
            return _eventContext.Usuario.FirstOrDefault(u => u.IdUsuario == id)!;
        }

        public void Cadastrar(Usuario usuario)
        {
            _eventContext.Usuario.Add(usuario);

            _eventContext.SaveChanges();
        }
    }
}
