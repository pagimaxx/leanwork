using LeanWork.Domain.Entities.Domain;
using System.Collections.Generic;

namespace LeanWork.Domain.Interfaces.Repositories
{
    public interface ICandidatoTecnologiaRepository
    {
        IEnumerable<CandidatoTecnologia> ObterTodosPorCandidato(int id);
        IEnumerable<CandidatoTecnologia> ObterTodosPorTecnologia(int id);
        int Cadastrar(CandidatoTecnologia entity);
        bool Remover(int id);
    }
}
