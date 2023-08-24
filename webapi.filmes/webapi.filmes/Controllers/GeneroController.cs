﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.filmes.Domains;
using webapi.filmes.Interfaces;
using webapi.filmes.Repositories;

namespace webapi.filmes.Controllers
{
    // define que a rota de uma requisicao sera no seguinte formato
    //dominio/api/controller
    //ex: hhtp://localhost:5000/api/genero
    [Route("api/[controller]")]

    //define que eh um controlador de api
    [ApiController]

    //define que o tipo de resposta da api sera no formato json
    [Produces("application/json")]

    //metodo controlador que herda da controller base
    //onde sera criado os endpoints (rotas)
    public class GeneroController : ControllerBase
    {
        /// <summary>
        /// objeto _generoRepository que ira receber todos os metodos definidos na interface
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }

        //instancia o objeto _generoRepository para que haja referencia aos metodos no repositorio
        public GeneroController()
        {
            _generoRepository = new GeneroRepository();
        }

        //endpoint que aciona o metodo listarTodos do repositorio e retorna a resposta para o usuario(front-end)
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //cria uma lista que recebe os dados da requisicao
                List<GeneroDomain> listaGeneros = _generoRepository.ListarTodos();

                //retorna a lista no formato JSON com o status code OK(200)
                return Ok(listaGeneros);
            }
            catch (Exception erro)
            {
                //retorna status code BadRequest(400) e a mensagem do erro
                return BadRequest(erro.Message);
            }

        }
    }
}
