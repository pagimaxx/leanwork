using LeanWork.AppService.Interfaces;
using LeanWork.AppService.ViewModels.Consulta;
using LeanWork.AppService.ViewModels.Inclusao;
using LeanWork.Infrastructure.CrossCutting.Utilities.Results;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LeanWork.Api.Controllers
{
    [Route("empresa-tecnologia")]
    [ApiController]
    public class EmpresaTecnologiaController : ControllerBase
    {
        private readonly IEmpresaTecnologiaAppService appService;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="_appService"></param>
        public EmpresaTecnologiaController(IEmpresaTecnologiaAppService _appService)
        {
            appService = _appService;
        }

        [HttpGet]
        [Route("obter-por-empresa")]
        public ResultadoPesquisa<IEnumerable<EmpresaTecnologiaConsultaVM>> ObterTodosPorEmpresa(int id) =>
            new ResultadoPesquisa<IEnumerable<EmpresaTecnologiaConsultaVM>> { Resultado = appService.ObterTodosPorEmpresa(id) };

        [HttpGet]
        [Route("obter-por-tecnologia")]
        public ResultadoPesquisa<IEnumerable<EmpresaTecnologiaConsultaVM>> ObterTodosPorTecnologia(int id) =>
            new ResultadoPesquisa<IEnumerable<EmpresaTecnologiaConsultaVM>> { Resultado = appService.ObterTodosPorTecnologia(id) };

        [HttpPost]
        [Route("cadastrar")]
        public ResultadoOperacao Cadastrar(EmpresaTecnologiaInclusaoVM entity) =>
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