using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.filmes.DataTransfering;
using webapi.filmes.Domains;
using webapi.filmes.Interfaces;
using webapi.filmes.Repositories;

namespace webapi.filmes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(UsuarioTransfer dadosUsuario)
        {
            try
            {
                UsuarioDomain usuarioEncontrado = _usuarioRepository.Login(dadosUsuario.Email, dadosUsuario.Senha);

                if (usuarioEncontrado == null)
                {
                    return NotFound("Usuário nao encontrado!");
                }

                return Ok(usuarioEncontrado);
            }
            catch (Exception err)
            {
                return BadRequest(err);
            }
        }
    }
}