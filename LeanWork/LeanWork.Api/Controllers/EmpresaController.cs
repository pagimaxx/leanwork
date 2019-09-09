using LeanWork.AppService.Interfaces;
using LeanWork.AppService.ViewModels.Alteracao;
using LeanWork.AppService.ViewModels.Consulta;
using LeanWork.AppService.ViewModels.Inclusao;
using LeanWork.Infrastructure.CrossCutting.Utilities.Results;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LeanWork.Api.Controllers
{
    [Route("empresa")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaAppService appService;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="_appService"></param>
        public EmpresaController(IEmpresaAppService _appService)
        {
            appService = _appService;
        }

        [HttpGet]
        [Route("obter-por-id")]
        public ResultadoPesquisa<EmpresaConsultaVM> ObterPorId(int id) =>
            new ResultadoPesquisa<EmpresaConsultaVM> { Resultado = appService.ObterPorId(id) };

        [HttpGet]
        [Route("obter-por-texto")]
        public ResultadoPesquisa<IEnumerable<EmpresaConsultaVM>> ObterTodos(string texto) =>
            new ResultadoPesquisa<IEnumerable<EmpresaConsultaVM>> { Resultado = appService.ObterPorTexto(texto) };

        [HttpGet]
        [Route("obter-todos")]
        public ResultadoPesquisa<IEnumerable<EmpresaConsultaVM>> ObterTodos() =>
            new ResultadoPesquisa<IEnumerable<EmpresaConsultaVM>> { Resultado = appService.ObterTodos() };

        [HttpPost]
        [Route("cadastrar")]
        public ResultadoOperacao Cadastrar(EmpresaInclusaoVM entity) =>
            new ResultadoOperacao { Identificador = appService.Cadastrar(entity).ToString(), Sucesso = true };

        [HttpPut]
        [Route("alterar")]
        public ResultadoOperacao Atualizar(EmpresaAlteracaoVM entity) =>
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