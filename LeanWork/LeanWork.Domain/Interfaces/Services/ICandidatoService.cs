using LeanWork.Domain.Entities.Domain;
using System.Collections.Generic;

namespace LeanWork.Domain.Interfaces.Services
{
    public interface ICandidatoService
    {
        Candidato ObterPorId(int id);
        IEnumerable<Candidato> ObterTodos();
        IEnumerable<Candidato> ObterPorTexto(string descricao);
        int Cadastrar(Candidato entity);
        bool Atualizar(Candidato entity);
        bool Remover(int id);
        IEnumerable<Triagem> ObterPontuacaoTriagem();
    }
}
