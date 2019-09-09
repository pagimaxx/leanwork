using System.Collections.Generic;
using LeanWork.AppService.ViewModels.Alteracao;
using LeanWork.AppService.ViewModels.Consulta;
using LeanWork.AppService.ViewModels.Inclusao;

namespace LeanWork.AppService.Interfaces
{
    public interface ICandidatoTecnologiaAppService
    {
        IEnumerable<CandidatoTecnologiaConsultaVM> ObterTodosPorCandidato(int id);
        IEnumerable<CandidatoTecnologiaConsultaVM> ObterTodosPorTecnologia(int id);
        int Cadastrar(CandidatoTecnologiaInclusaoVM entity);
        bool Remover(int id);
    }
}
