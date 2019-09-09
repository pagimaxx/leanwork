using LeanWork.AppService.Interfaces;
using LeanWork.AppService.ViewModels.Alteracao;
using LeanWork.AppService.ViewModels.Consulta;
using LeanWork.AppService.ViewModels.Inclusao;
using LeanWork.Infrastructure.CrossCutting.Utilities.Results;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LeanWork.Api.Controllers
{
    [Route("candidato")]
    [ApiController]
    public class CandidatoController : ControllerBase
    {
        private readonly ICandidatoAppService appService;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="_appService"></param>
        public CandidatoController(ICandidatoAppService _appService)
        {
            appService = _appService;
        }

        [HttpGet]
        [Route("obter-por-id")]
        public ResultadoPesquisa<CandidatoConsultaVM> ObterPorId(int id) =>
            new ResultadoPesquisa<CandidatoConsultaVM> { Resultado = appService.ObterPorId(id) };

        [HttpGet]
        [Route("obter-por-texto")]
        public ResultadoPesquisa<IEnumerable<CandidatoConsultaVM>> ObterTodos(string texto) =>
            new ResultadoPesquisa<IEnumerable<CandidatoConsultaVM>> { Resultado = appService.ObterPorTexto(texto) };

        [HttpGet]
        [Route("obter-todos")]
        public ResultadoPesquisa<IEnumerable<CandidatoConsultaVM>> ObterTodos() =>
            new ResultadoPesquisa<IEnumerable<CandidatoConsultaVM>> { Resultado = appService.ObterTodos() };

        [HttpPost]
        [Route("cadastrar")]
        public ResultadoOperacao Cadastrar(CandidatoInclusaoVM entity) =>
            new ResultadoOperacao { Identificador = appService.Cadastrar(entity).ToString(), Sucesso = true };

        [HttpPut]
        [Route("alterar")]
        public ResultadoOperacao Atualizar(CandidatoAlteracaoVM entity) =>
            new ResultadoOperacao { Identificador = appService.Atualizar(entity).ToString(), Sucesso = true };

        [HttpDelete]
        [Route("remover")]
        public ResultadoOperacao Remover(int id)
        {
            var resultado = false;
            resultado = appService.Remover(id);
            return new ResultadoOperacao { Identificador = id.ToString(), Sucesso = resultado };
        }

        [HttpGet]
        [Route("obter-pontuacao-triagem")]
        public ResultadoPesquisa<IEnumerable<TriagemConsultaVM>> ObterPontuacaoTriagem() =>
            new ResultadoPesquisa<IEnumerable<TriagemConsultaVM>> { Resultado = appService.ObterPontuacaoTriagem() };
    }
}