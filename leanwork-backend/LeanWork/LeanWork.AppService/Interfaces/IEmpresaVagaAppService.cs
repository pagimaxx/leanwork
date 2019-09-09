using System.Collections.Generic;
using LeanWork.AppService.ViewModels.Alteracao;
using LeanWork.AppService.ViewModels.Consulta;
using LeanWork.AppService.ViewModels.Inclusao;

namespace LeanWork.AppService.Interfaces
{
    public interface IEmpresaVagaAppService
    {
        IEnumerable<EmpresaVagaConsultaVM> ObterTodosPorEmpresa(int id);
        IEnumerable<EmpresaVagaConsultaVM> ObterTodosPorVaga(int id);
        int Cadastrar(EmpresaVagaInclusaoVM entity);
        bool Remover(int id);
    }
}
