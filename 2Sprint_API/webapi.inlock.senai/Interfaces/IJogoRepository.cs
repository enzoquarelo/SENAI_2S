using webapi.inlock.senai.Domains;

namespace webapi.inlock.senai.Interfaces
{
    public interface IJogoRepository 
    {
        void Cadastrar(JogoDomain novoJogo);
        List<JogoDomain> ListarTodos();
        void Atualizar(JogoDomain jogo);
        void Deletar(int id);
        JogoDomain Buscar(int id);
    }
}
