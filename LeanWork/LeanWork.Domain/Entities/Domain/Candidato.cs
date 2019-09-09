using LeanWork.Infrastructure.CrossCutting.Utilities.Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LeanWork.Domain.Entities.Domain
{
    [SqlFilter(SequenceName = "")]
    public partial class Candidato : BaseDominio
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [StringLength(250)]
        public string Nome { get; set; }

        [Display(Name = "Currículo")]
        [StringLength(250)]
        public string Curriculo { get; set; }

        [Display(Name = "Status")]
        public bool Status { get; set; }
    }
}
