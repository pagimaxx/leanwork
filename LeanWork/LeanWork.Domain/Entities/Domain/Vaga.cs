using LeanWork.Infrastructure.CrossCutting.Utilities.Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LeanWork.Domain.Entities.Domain
{
    [SqlFilter(SequenceName = "")]
    public partial class Vaga : BaseDominio
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Empresa")]
        public int IdEmpresa { get; set; }

        [Display(Name = "Nome")]
        [StringLength(250)]
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        [StringLength(1000)]
        public string Descricao { get; set; }

        [Display(Name = "Quantidade")]
        public int Quantidade { get; set; }

        [Display(Name = "Status")]
        public bool Status { get; set; }
    }
}
