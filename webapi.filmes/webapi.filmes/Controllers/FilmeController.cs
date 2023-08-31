using Microsoft.AspNetCore.Mvc;
using webapi.filmes.Domains;
using webapi.filmes.Repositories;

namespace webapi.filmes.Controllers
{
        [Route("api/[controller]")]

        //define que eh um controlador de api
        [ApiController]

        //define que o tipo de resposta da api sera no formato json
        [Produces("application/json")]
        public class FilmeController : ControllerBase
        {
            private FilmeRepository _filmeRepository;

            public FilmeController()
            {
                _filmeRepository = new FilmeRepository();
            }

            /// <summary>
            /// endpoint que permite buscar por todos os filmes
            /// </summary>
            [HttpGet]
            public IActionResult GetAll()
            {
                try
                {
                    List<FilmeDomain> filmes = _filmeRepository.BuscarTodos();

                    return Ok(filmes);
                }
                catch (Exception err)
                {
                    return BadRequest(err.Message);
                }
            }

            /// <summary>
            /// endpoint que busca um filme através de seu id
            /// </summary>
            [HttpGet("{id}")]
            public IActionResult GetById(int id)
            {
                try
                {
                    FilmeDomain filmeEncontrado = _filmeRepository.BuscarPorId(id);

                    if (filmeEncontrado == null)
                    {
                        return NotFound();
                    }

                    return Ok(filmeEncontrado);
                }
                catch (Exception err)
                {
                    return BadRequest(err.Message);
                }
            }

            /// <summary>
            /// endpoint que permite criar um novo filme
            /// </summary>
            [HttpPost]
            public IActionResult Registrar(FilmeDomain filme)
            {
                try
                {
                    _filmeRepository.Registrar(filme);

                    return StatusCode(201);
                }
                catch (Exception err)
                {
                    return BadRequest(err.Message);
                }
            }

            /// <summary>
            /// endpoint que permite deletar um filme
            /// </summary>
            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                try
                {
                    _filmeRepository.Deletar(id);

                    return NoContent();
                }
                catch (Exception err)
                {
                    return BadRequest(err.Message);
                }
            }

            /// <summary>
            /// endpoint que permite atualizar um filme através do id passado pela url
            /// </summary>
            [HttpPut("{id}")]
            public IActionResult UpdateByIdUrl(int id, FilmeDomain filmeAtualizado)
            {
                try
                {
                    FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(id);

                    if (filmeBuscado != null)
                    {
                        try
                        {
                            _filmeRepository.AtualizarIdUrl(id, filmeAtualizado);

                            return NoContent();
                        }
                        catch (Exception err)
                        {
                            return BadRequest();
                        }

                    }

                    return NotFound("O Filme não existe.");
                }
                catch (Exception err)
                {
                    return BadRequest(err.Message);
                }
            }

            /// <summary>
            /// endpoint que faz a atualização de um filme através dos dados passados no corpo da requisição
            /// </summary>
            [HttpPut]
            public IActionResult UpdateByIdBody(FilmeDomain filmeAtualizado)
            {
                try
                {
                    FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(filmeAtualizado.IdFilme);

                    if (filmeBuscado != null)
                    {
                        try
                        {
                            _filmeRepository.AtualizarPeloCorpo(filmeAtualizado);

                            return NoContent();
                        }
                        catch (Exception err)
                        {
                            return BadRequest();
                        }
                    }

                    return NotFound("O Filme não existe.");
                }
                catch (Exception err)
                {
                    return BadRequest(err.Message);
                }
            }
        }
    }
