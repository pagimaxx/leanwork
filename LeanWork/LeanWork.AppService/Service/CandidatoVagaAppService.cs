using LeanWork.AppService.Interfaces;
using LeanWork.AppService.ViewModels.Alteracao;
using LeanWork.AppService.ViewModels.Consulta;
using LeanWork.AppService.ViewModels.Inclusao;
using LeanWork.Domain.Entities.Domain;
using LeanWork.Domain.Interfaces.Services;
using LeanWork.Infrastructure.CrossCutting.Mapper;
using System.Collections.Generic;

namespace LeanWork.AppService.Service
{
    public class CandidatoVagaAppService : ICandidatoVagaAppService
    {
        private readonly ICandidatoVagaService _service;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="service"></param>
        public CandidatoVagaAppService(ICandidatoVagaService service)
        {
            _service = service;
        }

        public int Cadastrar(CandidatoVagaInclusaoVM entity) =>
            _service.Cadastrar(MapperUtils.Map<CandidatoVagaInclusaoVM, CandidatoVaga>(entity));

        public IEnumerable<CandidatoVagaConsultaVM> ObterTodosPorCandidato(int id) =>
            MapperUtils.MapList<CandidatoVaga, CandidatoVagaConsultaVM>(_service.ObterTodosPorCandidato(id));

        public IEnumerable<CandidatoVagaConsultaVM> ObterTodosPorVaga(int id) =>
            MapperUtils.MapList<CandidatoVaga, CandidatoVagaConsultaVM>(_service.ObterTodosPorVaga(id));

        public bool Remover(int id) =>
            _service.Remover(id);
    }
}
