using System;
using System.ComponentModel.DataAnnotations;

namespace LeanWork.AppService.ViewModels.Inclusao
{
    public class VagaInclusaoVM
    {
        [Display(Name = "Selecione a empresa Empresa")]
        public int IdEmpresa { get; set; }

        [Display(Name = "Informe o Nome")]
        [StringLength(250, ErrorMessage = "Tamanho incorreto")]
        public string Nome { get; set; }

        [Display(Name = "Informe a Descrição")]
        [StringLength(1000, ErrorMessage = "Tamanho incorreto")]
        public string Descricao { get; set; }

        [Display(Name = "Informe a Quantidade")]
        public int Quantidade { get; set; }
    }
}
