using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JaVisitei.MapaBrasil.Mapper.Request
{
    public class VisitaAdicionarRequest
    {

        [Required]
        [Display(Name = "IdTipoRegiao")]
        public int IdTipoRegiao { get; set; }

        [Required]
        [Display(Name = "IdRegiao")]
        public string IdRegiao { get; set; }

        [Display(Name = "Cor")]
        public string Cor { get; set; }

        [Display(Name = "Data")]
        public DateTime? Data { get; set; }
    }
}
