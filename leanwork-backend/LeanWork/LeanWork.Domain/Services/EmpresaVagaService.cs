using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using LeanWork.Domain.Entities.Domain;
using LeanWork.Domain.Interfaces.Repositories;
using LeanWork.Domain.Interfaces.Services;

namespace LeanWork.Domain.Services
{
    public class EmpresaVagaService : IEmpresaVagaService
    {
        private readonly IEmpresaVagaRepository _repository;

        public EmpresaVagaService(IEmpresaVagaRepository repository)
        {
            _repository = repository;
        }

        public int Cadastrar(EmpresaVaga entity)
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

        public IEnumerable<EmpresaVaga> ObterTodosPorEmpresa(int id) =>
            _repository.ObterTodosPorEmpresa(id);

        public IEnumerable<EmpresaVaga> ObterTodosPorVaga(int id) =>
            _repository.ObterTodosPorVaga(id);

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
