using System.Collections.Generic;
using LeanWork.AppService.ViewModels.Alteracao;
using LeanWork.AppService.ViewModels.Consulta;
using LeanWork.AppService.ViewModels.Inclusao;

namespace LeanWork.AppService.Interfaces
{
    public interface ICandidatoAppService
    {
        CandidatoConsultaVM ObterPorId(int id);
        IEnumerable<CandidatoConsultaVM> ObterTodos();
        IEnumerable<CandidatoConsultaVM> ObterPorTexto(string descricao);
        int Cadastrar(CandidatoInclusaoVM entity);
        bool Atualizar(CandidatoAlteracaoVM entity);
        bool Remover(int id);
        IEnumerable<TriagemConsultaVM> ObterPontuacaoTriagem();
    }
}
