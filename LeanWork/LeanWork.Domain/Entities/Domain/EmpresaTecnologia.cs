using LeanWork.Infrastructure.CrossCutting.Utilities.Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LeanWork.Domain.Entities.Domain
{
    [SqlFilter(SequenceName = "")]
    public partial class EmpresaTecnologia : BaseDominio
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Empresa")]
        public int IdEmpresa { get; set; }

        [Display(Name = "Tecnologia")]
        public int IdTecnologia { get; set; }

        [Display(Name = "Peso")]
        public int Peso { get; set; }
    }
}
