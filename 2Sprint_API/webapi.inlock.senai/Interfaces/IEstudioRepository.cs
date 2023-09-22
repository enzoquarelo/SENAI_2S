using webapi.inlock.senai.Domains;

namespace webapi.inlock.senai.Interfaces
{
    public interface IEstudioRepository
    {
        /// <summary>
        /// Método para cadastrar novos estúdios
        /// </summary>
        /// <param name="novoEstudio">Novo objeto que será criado</param>
        void Cadastrar(EstudioDomain novoEstudio);

        /// <summary>
        /// Método para listar os estúdios cadastrados
        /// </summary>
        /// <returns>Lista com objetos cadastrados</returns>
        List<EstudioDomain> ListarTodos();

        /// <summary>
        /// Método para deletar um estúdio passando seu id 
        /// </summary>
        /// <param name="id">argumento que permitirá encontrar o estúdio para deletá-lo</param>
        void Deletar(int id);
    }
}
