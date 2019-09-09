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
    public class VagaAppService : IVagaAppService
    {
        private readonly IVagaService _service;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="service"></param>
        public VagaAppService(IVagaService service)
        {
            _service = service;
        }

        public bool Atualizar(VagaAlteracaoVM entity) =>
            _service.Atualizar(MapperUtils.Map<VagaAlteracaoVM, Vaga>(entity));

        public int Cadastrar(VagaInclusaoVM entity) =>
            _service.Cadastrar(MapperUtils.Map<VagaInclusaoVM, Vaga>(entity));

        public VagaConsultaVM ObterPorId(int id) =>
            MapperUtils.Map<Vaga, VagaConsultaVM>(_service.ObterPorId(id));

        public IEnumerable<VagaConsultaVM> ObterPorTexto(string descricao) =>
            MapperUtils.MapList<Vaga, VagaConsultaVM>(_service.ObterPorTexto(descricao));

        public IEnumerable<VagaConsultaVM> ObterTodos() =>
            MapperUtils.MapList<Vaga, VagaConsultaVM>(_service.ObterTodos());

        public bool Remover(int id) =>
            _service.Remover(id);
    }
}
