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
    public class CandidatoTecnologiaRepository : BaseConnection, ICandidatoTecnologiaRepository
    {
        private readonly IOptions<KeysConfig> _iChaveConfiguracao;
        private DataBaseType DataBaseType;

        public CandidatoTecnologiaRepository(IConnectionDB connection, IOptions<KeysConfig> chaveConfiguracao) : base(connection)
        {
            _iChaveConfiguracao = chaveConfiguracao;
            DataBaseType = (DataBaseType)Enum.Parse(typeof(DataBaseType), _iChaveConfiguracao.Value.TypeDB, true);
        }

        public int Cadastrar(CandidatoTecnologia entity)
        {
            try
            {
                const string query =
                        @"INSERT INTO CandidatoTecnologia (IdCandidato, IdTecnologia) 
                          VALUES (:IdCandidato, :IdTecnologia)";

                var parametros = new
                {
                    entity.IdCandidato,
                    entity.IdTecnologia
                };

                string sequenceName = null;

                if (DataBaseType == DataBaseType.Oracle)
                    sequenceName = SequenceHelper.GetSequenceName<CandidatoTecnologia>(entity);

                return Convert.ToInt32(IDbConn.CommandInsert(query, DataBaseType, parametros, sequenceName: sequenceName));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<CandidatoTecnologia> ObterTodosPorCandidato(int id)
        {
            try
            {
                const string query = @"SELECT * FROM CandidatoTecnologia WHERE IdCandidato = :id";
                return IDbConn.CommandQuery<CandidatoTecnologia>(query, DataBaseType, new { id }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<CandidatoTecnologia> ObterTodosPorTecnologia(int id)
        {
            try
            {
                const string query = @"SELECT * FROM CandidatoTecnologia WHERE IdTecnologia = :id";
                return IDbConn.CommandQuery<CandidatoTecnologia>(query, DataBaseType, new { id }).ToList();
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
                var query = @"DELETE FROM CandidatoTecnologia
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
