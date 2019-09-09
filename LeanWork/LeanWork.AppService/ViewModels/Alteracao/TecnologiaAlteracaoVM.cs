using System;
using System.ComponentModel.DataAnnotations;

namespace LeanWork.AppService.ViewModels.Alteracao
{
    public class TecnologiaAlteracaoVM
    {
        public int Id { get; set; }

        [Display(Name = "Informe o nome Nome")]
        [StringLength(250, ErrorMessage = "Tamanho incorreto")]
        public string Nome { get; set; }

        [Display(Name = "Informe o Peso")]
        public int Peso { get; set; }

        [Display(Name = "Status")]
        public bool Status { get; set; }
    }
}
