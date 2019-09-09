using LeanWork.AppService.Interfaces;
using LeanWork.AppService.ViewModels.Consulta;
using LeanWork.AppService.ViewModels.Inclusao;
using LeanWork.Infrastructure.CrossCutting.Utilities.Results;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LeanWork.Api.Controllers
{
    [Route("empresa-vaga")]
    [ApiController]
    public class EmpresaVagaController : ControllerBase
    {
        private readonly IEmpresaVagaAppService appService;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="_appService"></param>
        public EmpresaVagaController(IEmpresaVagaAppService _appService)
        {
            appService = _appService;
        }

        [HttpGet]
        [Route("obter-por-empresa")]
        public ResultadoPesquisa<IEnumerable<EmpresaVagaConsultaVM>> ObterTodosPorEmpresa(int id) =>
            new ResultadoPesquisa<IEnumerable<EmpresaVagaConsultaVM>> { Resultado = appService.ObterTodosPorEmpresa(id) };

        [HttpGet]
        [Route("obter-por-vaga")]
        public ResultadoPesquisa<IEnumerable<EmpresaVagaConsultaVM>> ObterTodosPorVaga(int id) =>
            new ResultadoPesquisa<IEnumerable<EmpresaVagaConsultaVM>> { Resultado = appService.ObterTodosPorVaga(id) };

        [HttpPost]
        [Route("cadastrar")]
        public ResultadoOperacao Cadastrar(EmpresaVagaInclusaoVM entity) =>
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