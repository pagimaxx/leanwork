using System;
using System.ComponentModel.DataAnnotations;

namespace LeanWork.AppService.ViewModels.Alteracao
{
    public class CandidatoVagaAlteracaoVM
    {
        public int Id { get; set; }

        [Display(Name = "Candidato")]
        public int IdCandidato { get; set; }

        [Display(Name = "Vaga")]
        public int IdVaga { get; set; }
    }
}
