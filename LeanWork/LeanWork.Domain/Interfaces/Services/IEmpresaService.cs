using LeanWork.Domain.Entities.Domain;
using System.Collections.Generic;

namespace LeanWork.Domain.Interfaces.Services
{
    public interface IEmpresaService
    {
        Empresa ObterPorId(int id);
        IEnumerable<Empresa> ObterTodos();
        IEnumerable<Empresa> ObterPorTexto(string descricao);
        int Cadastrar(Empresa entity);
        bool Atualizar(Empresa entity);
        bool Remover(int id);
    }
}
