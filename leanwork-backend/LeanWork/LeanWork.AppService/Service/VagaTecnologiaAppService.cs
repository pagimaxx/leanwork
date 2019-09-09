using LeanWork.AppService.Interfaces;
using LeanWork.AppService.ViewModels.Consulta;
using LeanWork.AppService.ViewModels.Inclusao;
using LeanWork.Domain.Entities.Domain;
using LeanWork.Domain.Interfaces.Services;
using LeanWork.Infrastructure.CrossCutting.Mapper;
using System.Collections.Generic;

namespace LeanWork.AppService.Service
{
    public class VagaTecnologiaAppService : IVagaTecnologiaAppService
    {
        private readonly IVagaTecnologiaService _service;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="service"></param>
        public VagaTecnologiaAppService(IVagaTecnologiaService service)
        {
            _service = service;
        }

        public int Cadastrar(VagaTecnologiaInclusaoVM entity) =>
            _service.Cadastrar(MapperUtils.Map<VagaTecnologiaInclusaoVM, VagaTecnologia>(entity));

        public IEnumerable<VagaTecnologiaConsultaVM> ObterTodosPorTecnologia(int id) =>
            MapperUtils.MapList<VagaTecnologia, VagaTecnologiaConsultaVM>(_service.ObterTodosPorTecnologia(id));

        public IEnumerable<VagaTecnologiaConsultaVM> ObterTodosPorVaga(int id) =>
            MapperUtils.MapList<VagaTecnologia, VagaTecnologiaConsultaVM>(_service.ObterTodosPorVaga(id));

        public bool Remover(int id) =>
            _service.Remover(id);
    }
}
