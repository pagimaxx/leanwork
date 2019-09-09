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
    public class VagaRepository : BaseConnection, IVagaRepository
    {
        private readonly IOptions<KeysConfig> _iChaveConfiguracao;
        private DataBaseType DataBaseType;

        public VagaRepository(IConnectionDB connection, IOptions<KeysConfig> chaveConfiguracao) : base(connection)
        {
            _iChaveConfiguracao = chaveConfiguracao;
            DataBaseType = (DataBaseType)Enum.Parse(typeof(DataBaseType), _iChaveConfiguracao.Value.TypeDB, true);
        }

        public bool Atualizar(Vaga entity)
        {
            try
            {
                const string query =
                        @"UPDATE Vaga 
                             SET Nome = :Nome, IdEmpresa = :IdEmpresa,
                                 Descricao = :Descricao, Quantidade = :Quantidade
                           WHERE Id = :Id";

                var parametros = new
                {
                    entity.Id,
                    entity.IdEmpresa,
                    entity.Nome,
                    entity.Descricao,
                    entity.Quantidade
                };

                var resultado = IDbConn.CommandExecute(query, DataBaseType, parametros);

                return resultado > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Cadastrar(Vaga entity)
        {
            const string query =
                        @"INSERT INTO Vaga (IdEmpresa, Nome, Descricao, Quantidade) 
                          VALUES (:IdEmpresa, :Nome, :Descricao, :Quantidade)";

            var parametros = new
            {
                entity.IdEmpresa,
                entity.Nome,
                entity.Descricao,
                entity.Quantidade
            };

            string sequenceName = null;

            if (DataBaseType == DataBaseType.Oracle)
                sequenceName = SequenceHelper.GetSequenceName<Vaga>(entity);

            return Convert.ToInt32(IDbConn.CommandInsert(query, DataBaseType, parametros, sequenceName: sequenceName));
        }

        public Vaga ObterPorId(int id)
        {
            try
            {
                const string query = @"SELECT * FROM Vaga WHERE Id = :id ORDER BY Nome";
                return IDbConn.CommandQuery<Vaga>(query, DataBaseType, new { id }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Vaga> ObterPorTexto(string descricao)
        {
            try
            {
                const string query = @"SELECT * FROM Vaga WHERE Nome = :Nome OR Descricao = :Nome ORDER BY Nome";
                return IDbConn.CommandQuery<Vaga>(query, DataBaseType, new { Nome = "%" + descricao + "%" }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Vaga> ObterTodos()
        {
            try
            {
                const string query = @"SELECT * FROM Vaga ORDER BY Nome";
                return IDbConn.CommandQuery<Vaga>(query, DataBaseType).ToList();
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
                var query = @"DELETE FROM Vaga
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
