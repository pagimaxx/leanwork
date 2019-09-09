using LeanWork.Infrastructure.CrossCutting.Utilities.Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LeanWork.Domain.Entities.Domain
{
    [SqlFilter(SequenceName = "")]
    public class Triagem
    {
        public string NomeCandidato { get; set; }
        public string Curriculo { get; set; }
        public string NomeVaga { get; set; }
        public string NomeEmpresa { get; set; }
        public int Peso { get; set; }
    }
}
