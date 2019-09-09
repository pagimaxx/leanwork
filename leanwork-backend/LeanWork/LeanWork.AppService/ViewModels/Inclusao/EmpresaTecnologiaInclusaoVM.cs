using System;
using System.ComponentModel.DataAnnotations;

namespace LeanWork.AppService.ViewModels.Inclusao
{
    public class EmpresaTecnologiaInclusaoVM
    {
        [Display(Name = "Seleciona a Empresa")]
        public int IdEmpresa { get; set; }

        [Display(Name = "Selecione a Tecnologia")]
        public int IdTecnologia { get; set; }

        [Display(Name = "Informe o Peso")]
        public int Peso { get; set; }
    }
}
