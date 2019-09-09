using LeanWork.Domain.Entities.Domain;
using System.Collections.Generic;

namespace LeanWork.Domain.Interfaces.Services
{
    public interface IVagaTecnologiaService
    {
        IEnumerable<VagaTecnologia> ObterTodosPorVaga(int id);
        IEnumerable<VagaTecnologia> ObterTodosPorTecnologia(int id);
        int Cadastrar(VagaTecnologia entity);
        bool Remover(int id);
    }
}
