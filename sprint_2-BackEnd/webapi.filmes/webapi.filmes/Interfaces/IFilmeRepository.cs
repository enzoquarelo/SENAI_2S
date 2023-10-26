using webapi.filmes.Domains;
using webapi.filmes.Repositories;

namespace webapi.filmes.Interfaces
{
    public interface IFilmeRepository
    {

        void Registrar(FilmeDomain filme);

        List<FilmeDomain> ListarTodos();


        FilmeDomain BuscarPorId(int id);


        void AtualizarPeloCorpo(FilmeDomain filmeAtualizado);


        void AtualizarIdUrl(int id, FilmeDomain filme);

        void Deletar(int id);
    }
}
