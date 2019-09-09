using LeanWork.Infrastructure.CrossCutting.Utilities.Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LeanWork.Domain.Entities.Domain
{
    [SqlFilter(SequenceName = "")]
    public partial class EmpresaVaga : BaseDominio
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Empresa")]
        public int IdEmpresa { get; set; }

        [Display(Name = "Vaga")]
        public int IdVaga { get; set; }
    }
}
