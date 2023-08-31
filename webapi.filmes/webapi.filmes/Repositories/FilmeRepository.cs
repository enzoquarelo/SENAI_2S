using System.Data.SqlClient;
using webapi.filmes.Domains;
using webapi.filmes.Interfaces;

namespace webapi.filmes.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private string stringConexao = "Data Source = DESKTOP-2KJISQH\\SENAI; Initial Catalog = Filmes; User Id = sa; Pwd = Senai@134";

        public void AtualizarIdUrl(int id, FilmeDomain filme)
        {
            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                string query = "UPDATE Filme SET IdGenero = @NovoIdGenero, Titulo = @NovoTitulo WHERE IdFilme = @Id";

                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NovoIdGenero", filme.IdGenero);
                    command.Parameters.AddWithValue("@NovoTitulo", filme.Titulo);
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                }
            }
        }


        public void AtualizarPeloCorpo(FilmeDomain filmeAtualizado)
        {
            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                string query = "UPDATE Filme SET IdGenero = @NovoIdGenero, Titulo = @NovoTitulo WHERE IdFilme = @Id";

                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NovoIdGenero", filmeAtualizado.IdGenero);
                    command.Parameters.AddWithValue("@NovoTitulo", filmeAtualizado.Titulo);
                    command.Parameters.AddWithValue("@Id", filmeAtualizado.IdFilme);

                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Busca um filme por id
        /// </summary>
        public FilmeDomain BuscarPorId(int id)
        {

            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                string query = "SELECT IdFilme, Titulo, Genero.IdGenero AS IdGenero, Genero.Nome AS NomeGenero FROM Filme " +
                               "JOIN Genero ON Filme.IdGenero = Genero.IdGenero " +
                               "WHERE IdFilme = @Id";

                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        FilmeDomain filme = new FilmeDomain()
                        {
                            IdFilme = Convert.ToInt32(reader["IdFilme"]),
                            IdGenero = Convert.ToInt32(reader["IdGenero"]),
                            Titulo = reader["Titulo"].ToString(),
                            Genero = new GeneroDomain()
                            {
                                IdGenero = Convert.ToInt32(reader["IdGenero"]),
                                Nome = reader["NomeGenero"].ToString()
                            }
                        };

                        return filme;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Busca por todos os filmes
        /// </summary>
        public List<FilmeDomain> BuscarTodos()
        {
            List<FilmeDomain> filmes = new List<FilmeDomain>();

            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                string query = "SELECT IdFilme, Titulo, Genero.IdGenero AS IdGenero, Genero.Nome AS NomeGenero FROM Filme " +
                               "JOIN Genero ON Filme.IdGenero = Genero.IdGenero";

                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        FilmeDomain filme = new FilmeDomain()
                        {
                            IdFilme = Convert.ToInt32(reader["IdFilme"]),
                            IdGenero = Convert.ToInt32(reader["IdGenero"]),
                            Titulo = reader["Titulo"].ToString(),
                            Genero = new GeneroDomain()
                            {
                                IdGenero = Convert.ToInt32(reader["IdGenero"]),
                                Nome = reader["NomeGenero"].ToString()
                            }
                        };

                        filmes.Add(filme);
                    }
                }
            }

            return filmes;
        }

        /// <summary>
        /// Deleta um filme por seu id
        public void Deletar(int id)
        {
            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                string query = "DELETE Filme WHERE IdFilme = @Id";

                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<FilmeDomain> ListarTodos()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Registra um novo filme
        /// </summary>
        public void Registrar(FilmeDomain filme)
        {
            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                string query = "INSERT INTO Filme VALUES (@IdGenero, @Titulo)";

                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdGenero", filme.IdGenero);
                    command.Parameters.AddWithValue("@Titulo", filme.Titulo);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
