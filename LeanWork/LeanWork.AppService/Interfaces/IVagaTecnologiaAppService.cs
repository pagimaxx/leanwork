using System.Collections.Generic;
using LeanWork.AppService.ViewModels.Consulta;
using LeanWork.AppService.ViewModels.Inclusao;

namespace LeanWork.AppService.Interfaces
{
    public interface IVagaTecnologiaAppService
    {
        IEnumerable<VagaTecnologiaConsultaVM> ObterTodosPorVaga(int id);
        IEnumerable<VagaTecnologiaConsultaVM> ObterTodosPorTecnologia(int id);
        int Cadastrar(VagaTecnologiaInclusaoVM entity);
        bool Remover(int id);
    }
}
