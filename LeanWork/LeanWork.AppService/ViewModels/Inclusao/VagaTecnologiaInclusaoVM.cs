using System.ComponentModel.DataAnnotations;

namespace LeanWork.AppService.ViewModels.Inclusao
{
    public class VagaTecnologiaInclusaoVM
    {
        [Display(Name = "Vaga")]
        public int IdVaga { get; set; }

        [Display(Name = "Tecnologia")]
        public int IdTecnologia { get; set; }

        [Display(Name = "Empresa")]
        public int IdEmpresa { get; set; }

        [Display(Name = "Peso")]
        public int Peso { get; set; }
    }
}
