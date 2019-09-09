using LeanWork.Domain.Entities.Domain;
using System.Collections.Generic;

namespace LeanWork.Domain.Interfaces.Services
{
    public interface ITecnologiaService
    {
        Tecnologia ObterPorId(int id);
        IEnumerable<Tecnologia> ObterTodos();
        IEnumerable<Tecnologia> ObterPorTexto(string descricao);
        int Cadastrar(Tecnologia entity);
        bool Atualizar(Tecnologia entity);
        bool Remover(int id);
    }
}
