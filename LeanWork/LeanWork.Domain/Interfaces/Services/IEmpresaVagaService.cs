using LeanWork.Domain.Entities.Domain;
using System.Collections.Generic;

namespace LeanWork.Domain.Interfaces.Services
{
    public interface IEmpresaVagaService
    {
        IEnumerable<EmpresaVaga> ObterTodosPorEmpresa(int id);
        IEnumerable<EmpresaVaga> ObterTodosPorVaga(int id);
        int Cadastrar(EmpresaVaga entity);
        bool Remover(int id);
    }
}
