using Microsoft.Extensions.Options;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeanWork.Domain.Entities.Domain;
using LeanWork.Domain.Interfaces.Repositories;
using LeanWork.Infrastructure.CrossCutting.Enums;
using LeanWork.Infrastructure.CrossCutting.Utilities;
using LeanWork.Persistence.Connection;

namespace LeanWork.Persistence.Repositories
{
    public class TecnologiaRepository : BaseConnection, ITecnologiaRepository
    {
        private readonly IOptions<KeysConfig> _iChaveConfiguracao;
        private DataBaseType DataBaseType;

        public TecnologiaRepository(IConnectionDB connection, IOptions<KeysConfig> chaveConfiguracao) : base(connection)
        {
            _iChaveConfiguracao = chaveConfiguracao;
            DataBaseType = (DataBaseType)Enum.Parse(typeof(DataBaseType), _iChaveConfiguracao.Value.TypeDB, true);
        }

        public bool Atualizar(Tecnologia entity)
        {
            try
            {
                const string query =
                        @"UPDATE Tecnologia 
                             SET Nome = :Nome, Peso = :Peso
                           WHERE Id = :Id";

                var parametros = new
                {
                    entity.Id,
                    entity.Nome,
                    entity.Peso
                };

                var resultado = IDbConn.CommandExecute(query, DataBaseType, parametros);

                return resultado > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Cadastrar(Tecnologia entity)
        {
            const string query =
                        @"INSERT INTO Tecnologia (Nome, Peso) 
                          VALUES (:Nome, :Peso)";

            var parametros = new
            {
                entity.Nome,
                entity.Peso
            };

            string sequenceName = null;

            if (DataBaseType == DataBaseType.Oracle)
                sequenceName = SequenceHelper.GetSequenceName<Tecnologia>(entity);

            return Convert.ToInt32(IDbConn.CommandInsert(query, DataBaseType, parametros, sequenceName: sequenceName));
        }

        public Tecnologia ObterPorId(int id)
        {
            try
            {
                const string query = @"SELECT * FROM Tecnologia WHERE Id = :id ORDER BY Nome";
                return IDbConn.CommandQuery<Tecnologia>(query, DataBaseType, new { id }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Tecnologia> ObterPorTexto(string descricao)
        {
            try
            {
                const string query = @"SELECT * FROM Tecnologia WHERE Nome = :Nome ORDER BY Nome";
                return IDbConn.CommandQuery<Tecnologia>(query, DataBaseType, new { Nome = "%" + descricao + "%" }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Tecnologia> ObterTodos()
        {
            try
            {
                const string query = @"SELECT * FROM Tecnologia ORDER BY Nome";
                return IDbConn.CommandQuery<Tecnologia>(query, DataBaseType).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Remover(int id)
        {
            try
            {
                var query = @"DELETE FROM Tecnologia
                               WHERE Id = :id";

                var resultado = IDbConn.CommandExecute(query, DataBaseType, new { id });
                return resultado > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
