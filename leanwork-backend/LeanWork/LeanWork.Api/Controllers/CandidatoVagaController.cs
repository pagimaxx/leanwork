using LeanWork.AppService.Interfaces;
using LeanWork.AppService.ViewModels.Consulta;
using LeanWork.AppService.ViewModels.Inclusao;
using LeanWork.Infrastructure.CrossCutting.Utilities.Results;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LeanWork.Api.Controllers
{
    [Route("candidato-vaga")]
    [ApiController]
    public class CandidatoVagaController : ControllerBase
    {
        private readonly ICandidatoVagaAppService appService;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="_appService"></param>
        public CandidatoVagaController(ICandidatoVagaAppService _appService)
        {
            appService = _appService;
        }

        [HttpGet]
        [Route("obter-por-candidato")]
        public ResultadoPesquisa<IEnumerable<CandidatoVagaConsultaVM>> ObterTodosPorCandidato(int id) =>
            new ResultadoPesquisa<IEnumerable<CandidatoVagaConsultaVM>> { Resultado = appService.ObterTodosPorCandidato(id) };

        [HttpGet]
        [Route("obter-por-vaga")]
        public ResultadoPesquisa<IEnumerable<CandidatoVagaConsultaVM>> ObterTodosPorVaga(int id) =>
            new ResultadoPesquisa<IEnumerable<CandidatoVagaConsultaVM>> { Resultado = appService.ObterTodosPorVaga(id) };

        [HttpPost]
        [Route("cadastrar")]
        public ResultadoOperacao Cadastrar(CandidatoVagaInclusaoVM entity) =>
            new ResultadoOperacao { Identificador = appService.Cadastrar(entity).ToString(), Sucesso = true };


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