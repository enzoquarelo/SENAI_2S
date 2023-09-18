using System.Data.SqlClient;
using System.Reflection.PortableExecutable;
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
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "UPDATE Genero SET Nome = @Nome WHERE IdGenero = @IdGenero";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", genero.Nome);
                    cmd.Parameters.AddWithValue("@IdGenero", genero.IdGenero);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                string query = "UPDATE Genero SET Nome = @NovoNome WHERE IdGenero = @Id";

                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@NovoNome", genero.Nome);

                    command.ExecuteNonQuery();
                }
            }
        }

        public GeneroDomain BuscarPorId(int id)
        {
            GeneroDomain generoEncontrado = null;

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT IdGenero, Nome FROM Genero WHERE IdGenero = @IdGenero";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@IdGenero", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        generoEncontrado = new GeneroDomain()
                        {
                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),
                            Nome = rdr["Nome"].ToString()
                        };
                    }
                }
            }

            return generoEncontrado;
        }

        public void Cadastrar(GeneroDomain novoGenero)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Genero (Nome) VALUES (@Nome)";


                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Nome",novoGenero.Nome);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Genero WHERE IdGenero = @IdGenero";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@IdGenero", id);

                    // abre a conexão com o bd
                    con.Open();

                    // executar a query de deletar
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<GeneroDomain> ListarTodos()
        { 
            List<GeneroDomain> listaGeneros = new List<GeneroDomain>();


            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT IdGenero, Nome FROM Genero";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain()
                        {
                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),

                            Nome = rdr["Nome"].ToString()
                        };

                        listaGeneros.Add(genero);
                    }
                }

                //retorna a lista 
                return listaGeneros;
            }
        }
    }
}
