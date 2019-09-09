using System;
using System.ComponentModel.DataAnnotations;

namespace LeanWork.AppService.ViewModels.Alteracao
{
    public class EmpresaVagaAlteracaoVM
    {
        public int Id { get; set; }

        [Display(Name = "Selecione a Empresa")]
        public int IdEmpresa { get; set; }

        [Display(Name = "Selecione a Vaga")]
        public int IdVaga { get; set; }
    }
}
