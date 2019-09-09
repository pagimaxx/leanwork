using LeanWork.AppService.Interfaces;
using LeanWork.AppService.ViewModels.Alteracao;
using LeanWork.AppService.ViewModels.Consulta;
using LeanWork.AppService.ViewModels.Inclusao;
using LeanWork.Infrastructure.CrossCutting.Utilities.Results;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LeanWork.Api.Controllers
{
    [Route("vaga")]
    [ApiController]
    public class VagaController : ControllerBase
    {
        private readonly IVagaAppService appService;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="_appService"></param>
        public VagaController(IVagaAppService _appService)
        {
            appService = _appService;
        }

        [HttpGet]
        [Route("obter-por-id")]
        public ResultadoPesquisa<VagaConsultaVM> ObterPorId(int id) =>
            new ResultadoPesquisa<VagaConsultaVM> { Resultado = appService.ObterPorId(id) };

        [HttpGet]
        [Route("obter-por-texto")]
        public ResultadoPesquisa<IEnumerable<VagaConsultaVM>> ObterTodos(string texto) =>
            new ResultadoPesquisa<IEnumerable<VagaConsultaVM>> { Resultado = appService.ObterPorTexto(texto) };

        [HttpGet]
        [Route("obter-todos")]
        public ResultadoPesquisa<IEnumerable<VagaConsultaVM>> ObterTodos() =>
            new ResultadoPesquisa<IEnumerable<VagaConsultaVM>> { Resultado = appService.ObterTodos() };

        [HttpPost]
        [Route("cadastrar")]
        public ResultadoOperacao Cadastrar(VagaInclusaoVM entity) =>
            new ResultadoOperacao { Identificador = appService.Cadastrar(entity).ToString(), Sucesso = true };

        [HttpPut]
        [Route("alterar")]
        public ResultadoOperacao Atualizar(VagaAlteracaoVM entity) =>
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