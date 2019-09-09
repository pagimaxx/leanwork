using LeanWork.Domain.Entities.Domain;
using System.Collections.Generic;

namespace LeanWork.Domain.Interfaces.Services
{
    public interface IVagaService
    {
        Vaga ObterPorId(int id);
        IEnumerable<Vaga> ObterTodos();
        IEnumerable<Vaga> ObterPorTexto(string descricao);
        int Cadastrar(Vaga entity);
        bool Atualizar(Vaga entity);
        bool Remover(int id);
    }
}
