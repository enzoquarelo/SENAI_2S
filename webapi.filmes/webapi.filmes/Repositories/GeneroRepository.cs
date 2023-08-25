using System.Data.SqlClient;
using webapi.filmes.Domains;
using webapi.filmes.Interfaces;

namespace webapi.filmes.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        private string stringConexao = "Data Source = DESKTOP-2KJISQH\\SENAI; Initial Catalog = Filmes; User Id = sa; Pwd = Senai@134";

        // autenticação através do windows: Integrated Security = true
        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public GeneroDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// cadastrar um novo genero
        /// </summary>
        /// <param name="novoGenero"> objeto com as informacoes que serao cadastradas <param>
        public void Cadastrar(GeneroDomain novoGenero)
        {
            //declara a conexao passando a string de conexao como parametro 
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //declara a query que sera executada
                string queryInsert = "INSERT INTO Genero (Nome) VALUES (@Nome)";


                //declara o sqlcommand com a query que sera executada e a conexao com o bd
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    //passa o valor do paramentro @Nome
                    cmd.Parameters.AddWithValue("@Nome",novoGenero.Nome);

                    //abre a conexao com o banco de dados
                    con.Open();

                    //executar a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// método para deletar um gênero
        /// </summary>
        /// <returns></returns>
        public void Deletar(int id)
        {
            //declara a conexao passando a string de conexao como parametro 
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //declara a query que sera executada
                string queryDelete = "DELETE FROM Genero WHERE IdGenero = @IdGenero";

                //declara o sqlcommand com a query que sera executada e a conexao com o bd
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    // passa o valor do parametro @IdGenero
                    cmd.Parameters.AddWithValue("@IdGenero", id);

                    // abre a conexão com o bd
                    con.Open();

                    // executar a query de deletar
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// método para listar todos os objetos gêneros
        /// </summary>
        /// <returns></returns>
        public List<GeneroDomain> ListarTodos()
        {
            // cria uma lista de objetos do tipo gênero 
            List<GeneroDomain> listaGeneros = new List<GeneroDomain>();


            // declara a sqlconnection passando a string de conexão como parâmetro 
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // declara a instruçaõ a ser executada
                string querySelectAll = "SELECT IdGenero, Nome FROM Genero";

                //abre a conexão com o banco de dados
                con.Open();

                //declara o sqldatareader para percorrer a tabela do banco de dados 
                SqlDataReader rdr;

                //declara o sqlcommand passando a query a ser executada e a conexão com o bd
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    // executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain()
                        {
                            //atribui a propriedade IdGenero o valor recebido no rdr
                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),

                            //atribui a propriedade Nome o valor recebido no rdr
                            Nome = rdr["Nome"].ToString()
                        };

                        //adiciona cada objeto dentro da lista
                        listaGeneros.Add(genero);
                    }
                }

                //retorna a lista 
                return listaGeneros;
            }
        }
    }
}
