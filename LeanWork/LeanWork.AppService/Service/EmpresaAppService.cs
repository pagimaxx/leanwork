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
    public class EmpresaAppService : IEmpresaAppService
    {
        private readonly IEmpresaService _service;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="service"></param>
        public EmpresaAppService(IEmpresaService service)
        {
            _service = service;
        }

        public bool Atualizar(EmpresaAlteracaoVM entity) => 
            _service.Atualizar(MapperUtils.Map<EmpresaAlteracaoVM, Empresa>(entity));

        public int Cadastrar(EmpresaInclusaoVM entity) => 
            _service.Cadastrar(MapperUtils.Map<EmpresaInclusaoVM, Empresa>(entity));

        public EmpresaConsultaVM ObterPorId(int id) =>
            MapperUtils.Map<Empresa, EmpresaConsultaVM>(_service.ObterPorId(id));

        public IEnumerable<EmpresaConsultaVM> ObterPorTexto(string descricao) =>
            MapperUtils.MapList<Empresa, EmpresaConsultaVM>(_service.ObterPorTexto(descricao));

        public IEnumerable<EmpresaConsultaVM> ObterTodos() =>
            MapperUtils.MapList<Empresa, EmpresaConsultaVM>(_service.ObterTodos());

        public bool Remover(int id) =>
            _service.Remover(id);
    }
}
