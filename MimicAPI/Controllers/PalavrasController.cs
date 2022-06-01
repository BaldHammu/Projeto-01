using Microsoft.AspNetCore.Mvc;
using MimicAPI.Helpers;
using MimicAPI.Models;
using MimicAPI.Repositories;
using MimicAPI.Repositories.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MimicAPI.Controllers
{
    [Route("api/palavras")]
    public class PalavrasController : ControllerBase
    {
        private readonly IPalavraRepository _repository;
        public PalavrasController(IPalavraRepository repository)
        {
            _repository = repository;
        }

        [Route("")]
        [HttpGet]
        public ActionResult ObterTodas([FromQuery]UrlQuery urlQuery) 
        {
            var bdItem = _repository.ObterPalavras(urlQuery);
            Response.Headers.Add("Paginator", JsonConvert.SerializeObject(bdItem.Paginator));
            if (urlQuery.PageNumber >= bdItem.Paginator.PagesTotal) return NotFound();
            return Ok(bdItem.PalavraLista);
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult Obter (int id)
        {
            Palavra recebePalavra = _repository.Obter(id);
            return Ok(recebePalavra);
        }

        [Route("")]
        [HttpPost]
        public ActionResult Cadastrar ([FromBody] Palavra palavra)
        {
            _repository.Cadastrar(palavra);
            return Ok();
        }

        [Route("{id}")]
        [HttpPut]
        public ActionResult Atualizar ([FromBody] Palavra palavra)
        {
            _repository.Atualizar(palavra);
            return Accepted();
        }

        [Route("{id}")]
        [HttpDelete]
        public ActionResult Deletar (int id)
        {
            _repository.Deletar(id);
            return Accepted();
        }
    }
}
