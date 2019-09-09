using System;
using System.ComponentModel.DataAnnotations;

namespace LeanWork.AppService.ViewModels.Consulta
{
    public class TecnologiaConsultaVM
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Peso { get; set; }
        public bool Status { get; set; }
    }
}
