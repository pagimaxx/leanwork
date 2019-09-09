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
    public class EmpresaRepository : BaseConnection, IEmpresaRepository
    {
        private readonly IOptions<KeysConfig> _iChaveConfiguracao;
        private DataBaseType DataBaseType;

        public EmpresaRepository(IConnectionDB connection, IOptions<KeysConfig> chaveConfiguracao) : base(connection)
        {
            _iChaveConfiguracao = chaveConfiguracao;
            DataBaseType = (DataBaseType)Enum.Parse(typeof(DataBaseType), _iChaveConfiguracao.Value.TypeDB, true);
        }

        public bool Atualizar(Empresa entity)
        {
            try
            {
                const string query =
                        @"UPDATE Empresa 
                             SET Nome = :Nome, QuantidadeVagas = :QuantidadeVagas 
                           WHERE Id = :Id";

                var parametros = new
                {
                    entity.Id,
                    entity.Nome,
                    entity.QuantidadeVagas
                };

                var resultado = IDbConn.CommandExecute(query, DataBaseType, parametros);

                return resultado > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Cadastrar(Empresa entity)
        {
            const string query =
                        @"INSERT INTO Empresa (Nome, QuantidadeVagas) 
                          VALUES (:Nome, :QuantidadeVagas)";

            var parametros = new
            {
                entity.Nome,
                entity.QuantidadeVagas
            };

            string sequenceName = null;

            if (DataBaseType == DataBaseType.Oracle)
                sequenceName = SequenceHelper.GetSequenceName<Empresa>(entity);

            return Convert.ToInt32(IDbConn.CommandInsert(query, DataBaseType, parametros, sequenceName: sequenceName));
        }

        public Empresa ObterPorId(int id)
        {
            try
            {
                const string query = @"SELECT * FROM Empresa WHERE Id = :id ORDER BY Nome";
                return IDbConn.CommandQuery<Empresa>(query, DataBaseType, new { id }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Empresa> ObterPorTexto(string descricao)
        {
            try
            {
                const string query = @"SELECT * FROM Empresa WHERE Nome = :Nome ORDER BY Nome";
                return IDbConn.CommandQuery<Empresa>(query, DataBaseType, new { Nome = "%" + descricao + "%" }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Empresa> ObterTodos()
        {
            try
            {
                const string query = @"SELECT * FROM Empresa ORDER BY Nome";
                return IDbConn.CommandQuery<Empresa>(query, DataBaseType).ToList();
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
                var query = @"DELETE FROM Empresa
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
