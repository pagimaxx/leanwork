using System.Collections.Generic;
using LeanWork.AppService.ViewModels.Alteracao;
using LeanWork.AppService.ViewModels.Consulta;
using LeanWork.AppService.ViewModels.Inclusao;

namespace LeanWork.AppService.Interfaces
{
    public interface IVagaAppService
    {
        VagaConsultaVM ObterPorId(int id);
        IEnumerable<VagaConsultaVM> ObterTodos();
        IEnumerable<VagaConsultaVM> ObterPorTexto(string descricao);
        int Cadastrar(VagaInclusaoVM entity);
        bool Atualizar(VagaAlteracaoVM entity);
        bool Remover(int id);
    }
}
