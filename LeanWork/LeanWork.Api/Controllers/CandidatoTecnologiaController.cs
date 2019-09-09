using LeanWork.AppService.Interfaces;
using LeanWork.AppService.ViewModels.Consulta;
using LeanWork.AppService.ViewModels.Inclusao;
using LeanWork.Infrastructure.CrossCutting.Utilities.Results;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LeanWork.Api.Controllers
{
    [Route("candidato-tecnologia")]
    [ApiController]
    public class CandidatoTecnologiaController : ControllerBase
    {
        private readonly ICandidatoTecnologiaAppService appService;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="_appService"></param>
        public CandidatoTecnologiaController(ICandidatoTecnologiaAppService _appService)
        {
            appService = _appService;
        }

        [HttpGet]
        [Route("obter-por-candidato")]
        public ResultadoPesquisa<IEnumerable<CandidatoTecnologiaConsultaVM>> ObterTodosPorCandidato(int id) =>
            new ResultadoPesquisa<IEnumerable<CandidatoTecnologiaConsultaVM>> { Resultado = appService.ObterTodosPorCandidato(id) };

        [HttpGet]
        [Route("obter-por-tecnologia")]
        public ResultadoPesquisa<IEnumerable<CandidatoTecnologiaConsultaVM>> ObterTodosPorTecnologia(int id) =>
            new ResultadoPesquisa<IEnumerable<CandidatoTecnologiaConsultaVM>> { Resultado = appService.ObterTodosPorTecnologia(id) };

        [HttpPost]
        [Route("cadastrar")]
        public ResultadoOperacao Cadastrar(CandidatoTecnologiaInclusaoVM entity) =>
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