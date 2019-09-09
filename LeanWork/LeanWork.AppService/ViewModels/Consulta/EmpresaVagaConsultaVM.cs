using System;
using System.ComponentModel.DataAnnotations;

namespace LeanWork.AppService.ViewModels.Consulta
{
    public class EmpresaVagaConsultaVM
    {
        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public int IdVaga { get; set; }
    }
}
