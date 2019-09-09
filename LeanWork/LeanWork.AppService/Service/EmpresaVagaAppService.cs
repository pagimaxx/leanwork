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
    public class EmpresaVagaAppService : IEmpresaVagaAppService
    {
        private readonly IEmpresaVagaService _service;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="service"></param>
        public EmpresaVagaAppService(IEmpresaVagaService service)
        {
            _service = service;
        }

        public int Cadastrar(EmpresaVagaInclusaoVM entity) =>
            _service.Cadastrar(MapperUtils.Map<EmpresaVagaInclusaoVM, EmpresaVaga>(entity));

        public IEnumerable<EmpresaVagaConsultaVM> ObterTodosPorEmpresa(int id) =>
            MapperUtils.MapList<EmpresaVaga, EmpresaVagaConsultaVM>(_service.ObterTodosPorEmpresa(id));

        public IEnumerable<EmpresaVagaConsultaVM> ObterTodosPorVaga(int id) =>
            MapperUtils.MapList<EmpresaVaga, EmpresaVagaConsultaVM>(_service.ObterTodosPorVaga(id));

        public bool Remover(int id) =>
            _service.Remover(id);
    }
}
