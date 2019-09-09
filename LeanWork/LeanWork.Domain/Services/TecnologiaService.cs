﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using LeanWork.Domain.Entities.Domain;
using LeanWork.Domain.Interfaces.Repositories;
using LeanWork.Domain.Interfaces.Services;

namespace LeanWork.Domain.Services
{
    public class TecnologiaService : ITecnologiaService
    {
        private readonly ITecnologiaRepository _repository;

        public TecnologiaService(ITecnologiaRepository repository)
        {
            _repository = repository;
        }

        public bool Atualizar(Tecnologia entity)
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

        public int Cadastrar(Tecnologia entity)
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

        public Tecnologia ObterPorId(int id) =>
            _repository.ObterPorId(id);

        public IEnumerable<Tecnologia> ObterPorTexto(string descricao) =>
            _repository.ObterPorTexto(descricao);

        public IEnumerable<Tecnologia> ObterTodos() =>
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