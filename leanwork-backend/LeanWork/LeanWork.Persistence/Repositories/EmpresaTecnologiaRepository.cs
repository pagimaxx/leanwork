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
    public class EmpresaTecnologiaRepository : BaseConnection, IEmpresaTecnologiaRepository
    {
        private readonly IOptions<KeysConfig> _iChaveConfiguracao;
        private DataBaseType DataBaseType;

        public EmpresaTecnologiaRepository(IConnectionDB connection, IOptions<KeysConfig> chaveConfiguracao) : base(connection)
        {
            _iChaveConfiguracao = chaveConfiguracao;
            DataBaseType = (DataBaseType)Enum.Parse(typeof(DataBaseType), _iChaveConfiguracao.Value.TypeDB, true);
        }

        public int Cadastrar(EmpresaTecnologia entity)
        {
            try
            {
                const string query =
                    @"INSERT INTO EmpresaTecnologia (IdEmpresa, IdTecnologia, Peso) 
                        VALUES (:IdEmpresa, :IdTecnologia, :Peso)";

                var parametros = new
                {
                    entity.IdEmpresa,
                    entity.IdTecnologia,
                    entity.Peso
                };

                string sequenceName = null;

                if (DataBaseType == DataBaseType.Oracle)
                    sequenceName = SequenceHelper.GetSequenceName<EmpresaTecnologia>(entity);

                return Convert.ToInt32(IDbConn.CommandInsert(query, DataBaseType, parametros, sequenceName: sequenceName));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<EmpresaTecnologia> ObterTodosPorEmpresa(int id)
        {
            try
            {
                const string query = @"SELECT * FROM EmpresaTecnologia WHERE IdEmpresa = :id";
                return IDbConn.CommandQuery<EmpresaTecnologia>(query, DataBaseType, new { id }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<EmpresaTecnologia> ObterTodosPorTecnologia(int id)
        {
            try
            {
                const string query = @"SELECT * FROM EmpresaTecnologia WHERE IdTecnologia = :id";
                return IDbConn.CommandQuery<EmpresaTecnologia>(query, DataBaseType, new { id }).ToList();
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
                var query = @"DELETE FROM EmpresaTecnologia
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
