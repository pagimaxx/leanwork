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
    public class EmpresaVagaRepository : BaseConnection, IEmpresaVagaRepository
    {
        private readonly IOptions<KeysConfig> _iChaveConfiguracao;
        private DataBaseType DataBaseType;

        public EmpresaVagaRepository(IConnectionDB connection, IOptions<KeysConfig> chaveConfiguracao) : base(connection)
        {
            _iChaveConfiguracao = chaveConfiguracao;
            DataBaseType = (DataBaseType)Enum.Parse(typeof(DataBaseType), _iChaveConfiguracao.Value.TypeDB, true);
        }

        public int Cadastrar(EmpresaVaga entity)
        {
            try
            {
                const string query =
                    @"INSERT INTO EmpresaVaga (IdEmpresa, IdVaga) 
                        VALUES (:IdEmpresa, :IdVaga)";

                var parametros = new
                {
                    entity.IdEmpresa,
                    entity.IdVaga
                };

                string sequenceName = null;

                if (DataBaseType == DataBaseType.Oracle)
                    sequenceName = SequenceHelper.GetSequenceName<EmpresaVaga>(entity);

                return Convert.ToInt32(IDbConn.CommandInsert(query, DataBaseType, parametros, sequenceName: sequenceName));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<EmpresaVaga> ObterTodosPorEmpresa(int id)
        {
            try
            {
                const string query = @"SELECT * FROM EmpresaVaga WHERE IdEmpresa = :id";
                return IDbConn.CommandQuery<EmpresaVaga>(query, DataBaseType, new { id }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<EmpresaVaga> ObterTodosPorVaga(int id)
        {
            try
            {
                const string query = @"SELECT * FROM EmpresaVaga WHERE IdVaga = :id";
                return IDbConn.CommandQuery<EmpresaVaga>(query, DataBaseType, new { id }).ToList();
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
                var query = @"DELETE FROM EmpresaVaga
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
