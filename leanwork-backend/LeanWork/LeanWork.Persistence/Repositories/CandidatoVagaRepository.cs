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
    public class CandidatoVagaRepository : BaseConnection, ICandidatoVagaRepository
    {
        private readonly IOptions<KeysConfig> _iChaveConfiguracao;
        private DataBaseType DataBaseType;

        public CandidatoVagaRepository(IConnectionDB connection, IOptions<KeysConfig> chaveConfiguracao) : base(connection)
        {
            _iChaveConfiguracao = chaveConfiguracao;
            DataBaseType = (DataBaseType)Enum.Parse(typeof(DataBaseType), _iChaveConfiguracao.Value.TypeDB, true);
        }

        public int Cadastrar(CandidatoVaga entity)
        {
            try
            {
                const string query =
                    @"INSERT INTO CandidatoVaga (IdCandidato, IdVaga) 
                        VALUES (:IdCandidato, :IdVaga)";

                var parametros = new
                {
                    entity.IdCandidato,
                    entity.IdVaga
                };

                string sequenceName = null;

                if (DataBaseType == DataBaseType.Oracle)
                    sequenceName = SequenceHelper.GetSequenceName<CandidatoVaga>(entity);

                return Convert.ToInt32(IDbConn.CommandInsert(query, DataBaseType, parametros, sequenceName: sequenceName));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<CandidatoVaga> ObterTodosPorCandidato(int id)
        {
            try
            {
                const string query = @"SELECT * FROM CandidatoVaga WHERE IdCandidato = :id";
                return IDbConn.CommandQuery<CandidatoVaga>(query, DataBaseType, new { id }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<CandidatoVaga> ObterTodosPorVaga(int id)
        {
            try
            {
                const string query = @"SELECT * FROM CandidatoVaga WHERE IdVaga = :id";
                return IDbConn.CommandQuery<CandidatoVaga>(query, DataBaseType, new { id }).ToList();
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
                var query = @"DELETE FROM CandidatoVaga
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
