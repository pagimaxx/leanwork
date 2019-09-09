using LeanWork.AppService.Interfaces;
using LeanWork.AppService.ViewModels.Alteracao;
using LeanWork.AppService.ViewModels.Consulta;
using LeanWork.AppService.ViewModels.Inclusao;
using LeanWork.Infrastructure.CrossCutting.Utilities.Results;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LeanWork.Api.Controllers
{
    [Route("tecnologia")]
    [ApiController]
    public class TecnologiaController : ControllerBase
    {
        private readonly ITecnologiaAppService appService;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="_appService"></param>
        public TecnologiaController(ITecnologiaAppService _appService)
        {
            appService = _appService;
        }

        [HttpGet]
        [Route("obter-por-id")]
        public ResultadoPesquisa<TecnologiaConsultaVM> ObterPorId(int id) =>
            new ResultadoPesquisa<TecnologiaConsultaVM> { Resultado = appService.ObterPorId(id) };

        [HttpGet]
        [Route("obter-por-texto")]
        public ResultadoPesquisa<IEnumerable<TecnologiaConsultaVM>> ObterTodos(string texto) =>
            new ResultadoPesquisa<IEnumerable<TecnologiaConsultaVM>> { Resultado = appService.ObterPorTexto(texto) };

        [HttpGet]
        [Route("obter-todos")]
        public ResultadoPesquisa<IEnumerable<TecnologiaConsultaVM>> ObterTodos() =>
            new ResultadoPesquisa<IEnumerable<TecnologiaConsultaVM>> { Resultado = appService.ObterTodos() };

        [HttpPost]
        [Route("cadastrar")]
        public ResultadoOperacao Cadastrar(TecnologiaInclusaoVM entity) =>
            new ResultadoOperacao { Identificador = appService.Cadastrar(entity).ToString(), Sucesso = true };

        [HttpPut]
        [Route("alterar")]
        public ResultadoOperacao Atualizar(TecnologiaAlteracaoVM entity) =>
            new ResultadoOperacao { Identificador = appService.Atualizar(entity).ToString(), Sucesso = true };

        [HttpDelete]
        [Route("remover")]
        public ResultadoOperacao Remover(int id)
        {
            var resultado = false;
            resultado = appService.Remover(id);
            return new ResultadoOperacao { Identificador = id.ToString(), Sucesso = resultado };
        }
    }
}