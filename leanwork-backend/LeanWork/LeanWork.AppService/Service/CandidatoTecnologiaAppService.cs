using LeanWork.AppService.Interfaces;
using LeanWork.AppService.ViewModels.Consulta;
using LeanWork.AppService.ViewModels.Inclusao;
using LeanWork.Domain.Entities.Domain;
using LeanWork.Domain.Interfaces.Services;
using LeanWork.Infrastructure.CrossCutting.Mapper;
using System.Collections.Generic;

namespace LeanWork.AppService.Service
{
    public class CandidatoTecnologiaAppService : ICandidatoTecnologiaAppService
    {
        private readonly ICandidatoTecnologiaService _service;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="service"></param>
        public CandidatoTecnologiaAppService(ICandidatoTecnologiaService service)
        {
            _service = service;
        }

        public int Cadastrar(CandidatoTecnologiaInclusaoVM entity) => 
            _service.Cadastrar(MapperUtils.Map<CandidatoTecnologiaInclusaoVM, CandidatoTecnologia>(entity));

        public IEnumerable<CandidatoTecnologiaConsultaVM> ObterTodosPorCandidato(int id) =>
            MapperUtils.MapList<CandidatoTecnologia, CandidatoTecnologiaConsultaVM>(_service.ObterTodosPorCandidato(id));

        public IEnumerable<CandidatoTecnologiaConsultaVM> ObterTodosPorTecnologia(int id) =>
            MapperUtils.MapList<CandidatoTecnologia, CandidatoTecnologiaConsultaVM>(_service.ObterTodosPorTecnologia(id));

        public bool Remover(int id) =>
            _service.Remover(id);
    }
}
