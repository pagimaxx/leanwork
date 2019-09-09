using System.Collections.Generic;

namespace LeanWork.Infrastructure.CrossCutting.Utilities.Results
{
    public class ResultadoOperacao : ResultadoBase
    {
        public ResultadoOperacao()
        {
            Excecao = new List<Excecao>();
        }

        public string Identificador { get; set; }
        public bool Sucesso { get; set; }
    }
}
