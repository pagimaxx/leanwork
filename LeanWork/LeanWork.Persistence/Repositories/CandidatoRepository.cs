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
    public class CandidatoRepository : BaseConnection, ICandidatoRepository
    {
        private readonly IOptions<KeysConfig> _iChaveConfiguracao;
        private DataBaseType DataBaseType;

        public CandidatoRepository(IConnectionDB connection, IOptions<KeysConfig> chaveConfiguracao) : base(connection)
        {
            _iChaveConfiguracao = chaveConfiguracao;
            DataBaseType = (DataBaseType)Enum.Parse(typeof(DataBaseType), _iChaveConfiguracao.Value.TypeDB, true);
        }

        public bool Atualizar(Candidato entity)
        {
            try
            {
                const string query =
                        @"UPDATE Candidato 
                             SET Nome = :Nome, Curriculo = :Curriculo, Status = :Status 
                           WHERE Id = :id";

                var parametros = new
                {
                    entity.Id,
                    entity.Nome,
                    entity.Curriculo,
                    entity.Status
                };

                var resultado = IDbConn.CommandExecute(query, DataBaseType, parametros);

                return resultado > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Cadastrar(Candidato entity)
        {
            try
            {
                const string query =
                        @"INSERT INTO Candidato (Nome, Curriculo, Status) 
                          VALUES (:Nome, :Curriculo, :Status)";

                var parametros = new
                {
                    entity.Nome,
                    entity.Curriculo,
                    entity.Status
                };

                string sequenceName = null;

                if (DataBaseType == DataBaseType.Oracle)
                    sequenceName = SequenceHelper.GetSequenceName<Candidato>(entity);

                return Convert.ToInt32(IDbConn.CommandInsert(query, DataBaseType, parametros, sequenceName: sequenceName));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Candidato ObterPorId(int id)
        {
            try
            {
                const string query = @"SELECT * FROM Candidato WHERE Id = :id ORDER BY Nome";
                return IDbConn.CommandQuery<Candidato>(query, DataBaseType, new { id }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Candidato> ObterPorTexto(string descricao)
        {
            try
            {
                const string query = @"SELECT * FROM Candidato WHERE Nome = :Nome ORDER BY Nome";
                return IDbConn.CommandQuery<Candidato>(query, DataBaseType, new { Nome = "%" + descricao + "%" }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Candidato> ObterTodos()
        {
            try
            {
                const string query = @"SELECT * FROM Candidato ORDER BY Nome";
                return IDbConn.CommandQuery<Candidato>(query, DataBaseType).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Triagem> ObterPontuacaoTriagem()
        {
            try
            {
                const string query = @"
                    SELECT C.Id, C.Nome AS NomeCandidato, C.Curriculo, 
                           V.Nome AS NomeVaga, E.Nome AS NomeEmpresa, 
                           SUM(VT.Peso) AS Peso
                      FROM Candidato C
                           INNER JOIN Vaga V ON V.Id = (SELECT IdVaga FROM CandidatoVaga WHERE IdCandidato = C.Id)
	                       INNER JOIN VagaTecnologia VT ON VT.IdVaga = V.Id
	                       INNER JOIN Empresa E ON E.Id = VT.IdEmpresa
                     GROUP BY C.Id, C.Nome, C.Curriculo, V.Nome, E.Nome
                     ORDER BY Peso DESC";
                return IDbConn.CommandQuery<Triagem>(query, DataBaseType).ToList();
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
                var query = @"DELETE FROM Candidato
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
