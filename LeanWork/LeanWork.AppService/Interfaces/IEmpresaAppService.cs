using System.Collections.Generic;
using LeanWork.AppService.ViewModels.Alteracao;
using LeanWork.AppService.ViewModels.Consulta;
using LeanWork.AppService.ViewModels.Inclusao;

namespace LeanWork.AppService.Interfaces
{
    public interface IEmpresaAppService
    {
        EmpresaConsultaVM ObterPorId(int id);
        IEnumerable<EmpresaConsultaVM> ObterTodos();
        IEnumerable<EmpresaConsultaVM> ObterPorTexto(string descricao);
        int Cadastrar(EmpresaInclusaoVM entity);
        bool Atualizar(EmpresaAlteracaoVM entity);
        bool Remover(int id);
    }
}
