using System;
using System.ComponentModel.DataAnnotations;

namespace LeanWork.AppService.ViewModels.Alteracao
{
    public class CandidatoTecnologiaAlteracaoVM
    {
        public int Id { get; set; }

        [Display(Name = "Candidato")]
        public int IdCandidato { get; set; }

        [Display(Name = "Tecnologia")]
        public int IdTecnologia { get; set; }
    }
}
