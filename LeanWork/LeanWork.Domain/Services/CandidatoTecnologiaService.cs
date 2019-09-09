using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using LeanWork.Domain.Entities.Domain;
using LeanWork.Domain.Interfaces.Repositories;
using LeanWork.Domain.Interfaces.Services;

namespace LeanWork.Domain.Services
{
    public class CandidatoTecnologiaService : ICandidatoTecnologiaService
    {
        private readonly ICandidatoTecnologiaRepository _repository;

        public CandidatoTecnologiaService(ICandidatoTecnologiaRepository repository)
        {
            _repository = repository;
        }

        public int Cadastrar(CandidatoTecnologia entity)
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

        public IEnumerable<CandidatoTecnologia> ObterTodosPorCandidato(int id) =>
            _repository.ObterTodosPorCandidato(id);

        public IEnumerable<CandidatoTecnologia> ObterTodosPorTecnologia(int id) =>
            _repository.ObterTodosPorTecnologia(id);

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
