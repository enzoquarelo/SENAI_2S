using Microsoft.Data.SqlClient;
using webapi.inlock.senai.Domains;
using webapi.inlock.senai.Interfaces;

namespace webapi.inlock.senai.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string stringConexao = "Data Source = DESKTOP-2KJISQH\\SENAI; Initial Catalog = inlock_games_manha; User Id = sa; Pwd = Senai@134";
        public UsuarioDomain Login(string Email, string Senha)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySearch = "SELECT IdUsuario, Email, IdTipoUsuario FROM Usuario WHERE Email = @Email AND Senha = @Senha";

                using (SqlCommand cmd = new SqlCommand(querySearch, con))
                {
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@Senha", Senha);

                    con.Open();

                    SqlDataReader rdr;

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain
                        {
                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                            Email = rdr["Email"].ToString(),
                            IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"])
                        };
                        return usuario;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
    }
}
