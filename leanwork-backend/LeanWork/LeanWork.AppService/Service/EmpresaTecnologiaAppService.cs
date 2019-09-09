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
    public class EmpresaTecnologiaAppService : IEmpresaTecnologiaAppService
    {
        private readonly IEmpresaTecnologiaService _service;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="service"></param>
        public EmpresaTecnologiaAppService(IEmpresaTecnologiaService service)
        {
            _service = service;
        }

        public int Cadastrar(EmpresaTecnologiaInclusaoVM entity) =>
            _service.Cadastrar(MapperUtils.Map<EmpresaTecnologiaInclusaoVM, EmpresaTecnologia>(entity));

        public IEnumerable<EmpresaTecnologiaConsultaVM> ObterTodosPorEmpresa(int id) =>
            MapperUtils.MapList<EmpresaTecnologia, EmpresaTecnologiaConsultaVM>(_service.ObterTodosPorEmpresa(id));

        public IEnumerable<EmpresaTecnologiaConsultaVM> ObterTodosPorTecnologia(int id) =>
            MapperUtils.MapList<EmpresaTecnologia, EmpresaTecnologiaConsultaVM>(_service.ObterTodosPorTecnologia(id));

        public bool Remover(int id) =>
            _service.Remover(id);
    }
}
