using LeanWork.Domain.Entities.Domain;
using System.Collections.Generic;

namespace LeanWork.Domain.Interfaces.Repositories
{
    public interface IEmpresaTecnologiaRepository
    {
        IEnumerable<EmpresaTecnologia> ObterTodosPorEmpresa(int id);
        IEnumerable<EmpresaTecnologia> ObterTodosPorTecnologia(int id);
        int Cadastrar(EmpresaTecnologia entity);
        bool Remover(int id);
    }
}
