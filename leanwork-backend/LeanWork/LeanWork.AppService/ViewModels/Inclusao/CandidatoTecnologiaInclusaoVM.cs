using System;
using System.ComponentModel.DataAnnotations;

namespace LeanWork.AppService.ViewModels.Inclusao
{
    public class CandidatoTecnologiaInclusaoVM
    {
        [Display(Name = "Candidato")]
        public int IdCandidato { get; set; }

        [Display(Name = "Tecnologia")]
        public int IdTecnologia { get; set; }
    }
}
