using System;
using System.ComponentModel.DataAnnotations;

namespace LeanWork.AppService.ViewModels.Consulta
{
    public class VagaConsultaVM
    {
        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
    }
}
