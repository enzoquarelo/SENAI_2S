using Microsoft.Data.SqlClient;
using webapi.inlock.senai.Domains;
using webapi.inlock.senai.Interfaces;

namespace senai.inlock.webApi_.Repositories
{
    public class TiposUsuarioRepository : ITiposUsuarioRepository
    {
        private string stringConexao = "Data Source = DESKTOP-2KJISQH\\SENAI; Initial Catalog = inlock_games_manha; User Id = sa; Pwd = Senai@134";

        public List<TiposUsuarioDomain> ListarTodos()
        {
            List<TiposUsuarioDomain> listarTiposUsuario = new List<TiposUsuarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT IdTipoUsuario, Titulo FROM TiposUsuario";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        TiposUsuarioDomain estudio = new TiposUsuarioDomain
                        {
                            IdTipoUsuario = Convert.ToInt32(rdr[("IdTipoUsuario")]),
                            Titulo = rdr["Titulo"].ToString()
                        };

                        listarTiposUsuario.Add(estudio);
                    }
                }
            }

            return listarTiposUsuario;
        }
    }
}
