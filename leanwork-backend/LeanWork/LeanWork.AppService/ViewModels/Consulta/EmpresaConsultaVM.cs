using System;
using System.ComponentModel.DataAnnotations;

namespace LeanWork.AppService.ViewModels.Consulta
{
    public class EmpresaConsultaVM
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int QuantidadeVagas { get; set; }
    }
}
