using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using LeanWork.Domain.Entities.Domain;
using LeanWork.Domain.Interfaces.Repositories;
using LeanWork.Domain.Interfaces.Services;

namespace LeanWork.Domain.Services
{
    public class VagaService : IVagaService
    {
        private readonly IVagaRepository _repository;

        public VagaService(IVagaRepository repository)
        {
            _repository = repository;
        }

        public bool Atualizar(Vaga entity)
        {
            using (var scope = new TransactionScope())
            {
                var result = false;
                result = _repository.Atualizar(entity);

                if (!result)
                    throw new Exception("Ocorreu um erro ao atualizar");

                scope.Complete();
                return result;
            }
        }

        public int Cadastrar(Vaga entity)
        {
            using (var scope = new TransactionScope())
            {
                var result = _repository.Cadastrar(entity);

                if (result <= 0)
                    throw new Exception("Ocorreu um erro ao cadastrar");

                scope.Complete();
                return result;
            }
        }

        public Vaga ObterPorId(int id) =>
            _repository.ObterPorId(id);

        public IEnumerable<Vaga> ObterPorTexto(string descricao) =>
            _repository.ObterPorTexto(descricao);

        public IEnumerable<Vaga> ObterTodos() =>
            _repository.ObterTodos();

        public bool Remover(int id)
        {
            using (var scope = new TransactionScope())
            {
                var result = _repository.Remover(id);
                scope.Complete();
                return result;
            }
        }
    }
}
