using LeanWork.Domain.Entities.Domain;
using System.Collections.Generic;

namespace LeanWork.Domain.Interfaces.Repositories
{
    public interface IEmpresaVagaRepository
    {
        IEnumerable<EmpresaVaga> ObterTodosPorEmpresa(int id);
        IEnumerable<EmpresaVaga> ObterTodosPorVaga(int id);
        int Cadastrar(EmpresaVaga entity);
        bool Remover(int id);
    }
}
