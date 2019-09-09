using System;
using System.ComponentModel.DataAnnotations;

namespace LeanWork.AppService.ViewModels.Alteracao
{
    public class CandidatoAlteracaoVM
    {
        [Required]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [StringLength(250, ErrorMessage = "Tamanho não Permitido")]
        public string Nome { get; set; }

        [Display(Name = "Currículo")]
        [StringLength(250, ErrorMessage = "Tamanho não Permitido")]
        public string Curriculo { get; set; }

        [Display(Name = "Status")]
        public bool Status { get; set; }
    }
}
