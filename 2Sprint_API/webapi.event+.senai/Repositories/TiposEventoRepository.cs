using webapi.event_.senai.Contexts;
using webapi.event_.senai.Domains;
using webapi.event_.senai.Interfaces;
using webapi.event_.senai.Utils;

namespace webapi.event_.senai.Repositories
{
    public class TiposEventoRepository : ITiposEventoRepository
    {
        private readonly EventContext _eventContext;

        public TiposEventoRepository()
        {
            _eventContext = new EventContext();
        }


        public void Atualizar(Guid id, TiposEvento tiposEvento)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(TiposEvento tiposEvento)
        {
            _eventContext.TiposEvento.Add(tiposEvento);

            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<TiposEvento> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
