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
    public class VagaTecnologiaRepository : BaseConnection, IVagaTecnologiaRepository
    {
        private readonly IOptions<KeysConfig> _iChaveConfiguracao;
        private DataBaseType DataBaseType;

        public VagaTecnologiaRepository(IConnectionDB connection, IOptions<KeysConfig> chaveConfiguracao) : base(connection)
        {
            _iChaveConfiguracao = chaveConfiguracao;
            DataBaseType = (DataBaseType)Enum.Parse(typeof(DataBaseType), _iChaveConfiguracao.Value.TypeDB, true);
        }

        public int Cadastrar(VagaTecnologia entity)
        {
            try
            {
                const string query =
                        @"INSERT INTO VagaTecnologia (IdVaga, IdTecnologia, IdEmpresa, Peso) 
                          VALUES (:IdVaga, :IdTecnologia, :IdEmpresa, :Peso)";

                var parametros = new
                {
                    entity.IdVaga,
                    entity.IdTecnologia,
                    entity.IdEmpresa,
                    entity.Peso
                };

                string sequenceName = null;

                if (DataBaseType == DataBaseType.Oracle)
                    sequenceName = SequenceHelper.GetSequenceName<VagaTecnologia>(entity);

                return Convert.ToInt32(IDbConn.CommandInsert(query, DataBaseType, parametros, sequenceName: sequenceName));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<VagaTecnologia> ObterTodosPorTecnologia(int id)
        {
            try
            {
                const string query = @"SELECT * FROM VagaTecnologia WHERE IdTecnologia = :id";
                return IDbConn.CommandQuery<VagaTecnologia>(query, DataBaseType, new { id }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<VagaTecnologia> ObterTodosPorVaga(int id)
        {
            try
            {
                const string query = @"SELECT * FROM VagaTecnologia WHERE IdVaga = :id";
                return IDbConn.CommandQuery<VagaTecnologia>(query, DataBaseType, new { id }).ToList();
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
                var query = @"DELETE FROM VagaTecnologia
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
