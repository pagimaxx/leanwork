using System;
using System.ComponentModel.DataAnnotations;

namespace LeanWork.AppService.ViewModels.Alteracao
{
    public class EmpresaAlteracaoVM
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [StringLength(250, ErrorMessage = "Tamanho não Permitido")]
        public string Nome { get; set; }

        [Display(Name = "Quantidade de Vagas")]
        public int QuantidadeVagas { get; set; }
    }
}
