using LeanWork.Domain.Entities.Domain;
using System.Collections.Generic;

namespace LeanWork.Domain.Interfaces.Services
{
    public interface ICandidatoTecnologiaService
    {
        IEnumerable<CandidatoTecnologia> ObterTodosPorCandidato(int id);
        IEnumerable<CandidatoTecnologia> ObterTodosPorTecnologia(int id);
        int Cadastrar(CandidatoTecnologia entity);
        bool Remover(int id);
    }
}
