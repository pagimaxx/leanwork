using LeanWork.Domain.Entities.Domain;
using System.Collections.Generic;

namespace LeanWork.Domain.Interfaces.Repositories
{
    public interface IVagaTecnologiaRepository
    {
        IEnumerable<VagaTecnologia> ObterTodosPorVaga(int id);
        IEnumerable<VagaTecnologia> ObterTodosPorTecnologia(int id);
        int Cadastrar(VagaTecnologia entity);
        bool Remover(int id);
    }
}
