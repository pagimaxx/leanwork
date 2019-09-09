using LeanWork.Domain.Entities.Domain;
using System.Collections.Generic;

namespace LeanWork.Domain.Interfaces.Repositories
{
    public interface ICandidatoVagaRepository
    {
        IEnumerable<CandidatoVaga> ObterTodosPorCandidato(int id);
        IEnumerable<CandidatoVaga> ObterTodosPorVaga(int id);
        int Cadastrar(CandidatoVaga entity);
        bool Remover(int id);
    }
}
