using System;
using System.ComponentModel.DataAnnotations;

namespace LeanWork.AppService.ViewModels.Inclusao
{
    public class CandidatoVagaInclusaoVM
    {
        [Display(Name = "Candidato")]
        public int IdCandidato { get; set; }

        [Display(Name = "Vaga")]
        public int IdVaga { get; set; }
    }
}
