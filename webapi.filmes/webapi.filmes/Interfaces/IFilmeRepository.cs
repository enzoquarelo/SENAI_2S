using webapi.filmes.Domains;
using webapi.filmes.Repositories;

namespace webapi.filmes.Interfaces
{
    public class IFilmeRepository
    {
        /// <summary>
        /// Método para cadastrar filmes
        /// </summary>
        /// <param name="novoFilme"></param>
        void Cadastrar(FilmeDomain novoFilme);
        List<FilmeDomain> ListarTodos();

        void AtualizarIdCorpo(FilmeDomain filme);

        void AtualizarIdUrl(int id, FilmeDomain filme);

        void Deletar(int id);

        FilmeDomain BuscarPorId(int id);
    }
}
