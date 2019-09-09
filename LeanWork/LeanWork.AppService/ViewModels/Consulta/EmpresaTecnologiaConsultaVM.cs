using System;
using System.ComponentModel.DataAnnotations;

namespace LeanWork.AppService.ViewModels.Consulta
{
    public class EmpresaTecnologiaConsultaVM
    {
        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public int IdTecnologia { get; set; }
        public int Peso { get; set; }
    }
}
