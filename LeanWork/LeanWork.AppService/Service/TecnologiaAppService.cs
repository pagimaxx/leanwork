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
    public class TecnologiaAppService : ITecnologiaAppService
    {
        private readonly ITecnologiaService _service;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="service"></param>
        public TecnologiaAppService(ITecnologiaService service)
        {
            _service = service;
        }

        public bool Atualizar(TecnologiaAlteracaoVM entity) =>
            _service.Atualizar(MapperUtils.Map<TecnologiaAlteracaoVM, Tecnologia>(entity));

        public int Cadastrar(TecnologiaInclusaoVM entity) =>
            _service.Cadastrar(MapperUtils.Map<TecnologiaInclusaoVM, Tecnologia>(entity));

        public TecnologiaConsultaVM ObterPorId(int id) =>
            MapperUtils.Map<Tecnologia, TecnologiaConsultaVM>(_service.ObterPorId(id));

        public IEnumerable<TecnologiaConsultaVM> ObterPorTexto(string descricao) =>
            MapperUtils.MapList<Tecnologia, TecnologiaConsultaVM>(_service.ObterPorTexto(descricao));

        public IEnumerable<TecnologiaConsultaVM> ObterTodos() =>
            MapperUtils.MapList<Tecnologia, TecnologiaConsultaVM>(_service.ObterTodos());

        public bool Remover(int id) =>
            _service.Remover(id);
    }
}
