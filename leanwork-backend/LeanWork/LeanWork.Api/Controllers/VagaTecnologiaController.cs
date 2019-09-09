using LeanWork.AppService.Interfaces;
using LeanWork.AppService.ViewModels.Consulta;
using LeanWork.AppService.ViewModels.Inclusao;
using LeanWork.Infrastructure.CrossCutting.Utilities.Results;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LeanWork.Api.Controllers
{
    [Route("vaga-tecnologia")]
    [ApiController]
    public class VagaTecnologiaController : ControllerBase
    {
        private readonly IVagaTecnologiaAppService appService;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="_appService"></param>
        public VagaTecnologiaController(IVagaTecnologiaAppService _appService)
        {
            appService = _appService;
        }

        [HttpGet]
        [Route("obter-por-vaga")]
        public ResultadoPesquisa<IEnumerable<VagaTecnologiaConsultaVM>> ObterTodosPorVaga(int id) =>
            new ResultadoPesquisa<IEnumerable<VagaTecnologiaConsultaVM>> { Resultado = appService.ObterTodosPorVaga(id) };

        [HttpGet]
        [Route("obter-por-tecnologia")]
        public ResultadoPesquisa<IEnumerable<VagaTecnologiaConsultaVM>> ObterTodosPorTecnologia(int id) =>
            new ResultadoPesquisa<IEnumerable<VagaTecnologiaConsultaVM>> { Resultado = appService.ObterTodosPorTecnologia(id) };

        [HttpPost]
        [Route("cadastrar")]
        public ResultadoOperacao Cadastrar(VagaTecnologiaInclusaoVM entity) =>
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