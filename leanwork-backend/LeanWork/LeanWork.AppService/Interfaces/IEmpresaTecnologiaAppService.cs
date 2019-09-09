using System.Collections.Generic;
using LeanWork.AppService.ViewModels.Alteracao;
using LeanWork.AppService.ViewModels.Consulta;
using LeanWork.AppService.ViewModels.Inclusao;

namespace LeanWork.AppService.Interfaces
{
    public interface IEmpresaTecnologiaAppService
    {
        IEnumerable<EmpresaTecnologiaConsultaVM> ObterTodosPorEmpresa(int id);
        IEnumerable<EmpresaTecnologiaConsultaVM> ObterTodosPorTecnologia(int id);
        int Cadastrar(EmpresaTecnologiaInclusaoVM entity);
        bool Remover(int id);
    }
}
