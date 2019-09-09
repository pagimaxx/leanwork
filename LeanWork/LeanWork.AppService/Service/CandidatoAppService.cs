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
    public class CandidatoAppService : ICandidatoAppService
    {
        private readonly ICandidatoService _service;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="service"></param>
        public CandidatoAppService(ICandidatoService service)
        {
            _service = service;
        }

        public bool Atualizar(CandidatoAlteracaoVM entity) =>
            _service.Atualizar(MapperUtils.Map<CandidatoAlteracaoVM, Candidato>(entity));

        public int Cadastrar(CandidatoInclusaoVM entity) =>
            _service.Cadastrar(MapperUtils.Map<CandidatoInclusaoVM, Candidato>(entity));

        public CandidatoConsultaVM ObterPorId(int id) =>
            MapperUtils.Map<Candidato, CandidatoConsultaVM>(_service.ObterPorId(id));

        public IEnumerable<CandidatoConsultaVM> ObterPorTexto(string descricao) =>
            MapperUtils.MapList<Candidato, CandidatoConsultaVM>(_service.ObterPorTexto(descricao));

        public IEnumerable<CandidatoConsultaVM> ObterTodos() =>
            MapperUtils.MapList<Candidato, CandidatoConsultaVM>(_service.ObterTodos());

        public bool Remover(int id) =>
            _service.Remover(id);

        public IEnumerable<TriagemConsultaVM> ObterPontuacaoTriagem() =>
            MapperUtils.MapList<Triagem, TriagemConsultaVM>(_service.ObterPontuacaoTriagem());
    }
}
