using System.Collections.Generic;
using LeanWork.AppService.ViewModels.Alteracao;
using LeanWork.AppService.ViewModels.Consulta;
using LeanWork.AppService.ViewModels.Inclusao;

namespace LeanWork.AppService.Interfaces
{
    public interface ITecnologiaAppService
    {
        TecnologiaConsultaVM ObterPorId(int id);
        IEnumerable<TecnologiaConsultaVM> ObterTodos();
        IEnumerable<TecnologiaConsultaVM> ObterPorTexto(string descricao);
        int Cadastrar(TecnologiaInclusaoVM entity);
        bool Atualizar(TecnologiaAlteracaoVM entity);
        bool Remover(int id);
    }
}
