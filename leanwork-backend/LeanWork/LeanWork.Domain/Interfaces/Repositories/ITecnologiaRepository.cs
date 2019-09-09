using LeanWork.Domain.Entities.Domain;
using System.Collections.Generic;

namespace LeanWork.Domain.Interfaces.Repositories
{
    public interface ITecnologiaRepository
    {
        Tecnologia ObterPorId(int id);
        IEnumerable<Tecnologia> ObterTodos();
        IEnumerable<Tecnologia> ObterPorTexto(string descricao);
        int Cadastrar(Tecnologia entity);
        bool Atualizar(Tecnologia entity);
        bool Remover(int id);
    }
}
