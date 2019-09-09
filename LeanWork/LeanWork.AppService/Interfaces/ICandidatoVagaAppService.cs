using System.Collections.Generic;
using LeanWork.AppService.ViewModels.Alteracao;
using LeanWork.AppService.ViewModels.Consulta;
using LeanWork.AppService.ViewModels.Inclusao;

namespace LeanWork.AppService.Interfaces
{
    public interface ICandidatoVagaAppService
    {
        IEnumerable<CandidatoVagaConsultaVM> ObterTodosPorCandidato(int id);
        IEnumerable<CandidatoVagaConsultaVM> ObterTodosPorVaga(int id);
        int Cadastrar(CandidatoVagaInclusaoVM entity);
        bool Remover(int id);
    }
}
