using System.Data.SqlClient;
using System.Reflection.PortableExecutable;
using webapi.filmes.Domains;
using webapi.filmes.Interfaces;

namespace webapi.filmes.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string StringConexao = "Data Source = DESKTOP-2KJISQH\\SENAI; Initial Catalog = Filmes; User Id = sa; Pwd = Senai@134";

        /// <summary>
        /// É o método que permite a autenticação do usuário
        /// </summary>
        /// <param name="email">O e-mail do usuário</param>
        /// <param name="senha">A senha do usuário</param>
        /// <returns>Os dados do usuário em um objeto</returns>
        public UsuarioDomain Login(string email, string senha)
        {
            using (SqlConnection connection = new SqlConnection(StringConexao))
            {
                string query = "SELECT Id, Nome, Email, Senha, IsAdmin FROM Usuario " +
                               "WHERE Email = @Email AND Senha = @Senha";

                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Senha", senha);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        UsuarioDomain usuarioEncontrado = new UsuarioDomain()
                        {
                            IdUsuario = Convert.ToInt32(reader["Id"]),
                            Nome = reader["Nome"].ToString(),
                            Email = reader["Email"].ToString(),
                            Senha = reader["Senha"].ToString(),
                            IsAdmin = Convert.ToBoolean(reader["IsAdmin"])
                        };

                        return usuarioEncontrado;
                    }
                }
            }

            return null;
        }
    }
}