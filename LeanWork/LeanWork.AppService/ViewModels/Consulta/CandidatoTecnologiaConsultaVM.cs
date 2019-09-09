using System;
using System.ComponentModel.DataAnnotations;

namespace LeanWork.AppService.ViewModels.Consulta
{
    public class CandidatoTecnologiaConsultaVM
    {
        public int Id { get; set; }
        public int IdCandidato { get; set; }
        public int IdTecnologia { get; set; }
    }
}
