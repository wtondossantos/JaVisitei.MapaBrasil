using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace JaVisitei.MapaBrasil.Data.Models
{
    [Table("TbPais")]
    public partial class Pais
    {
        public Pais()
        {
            Estados = new HashSet<Estado>();
        }

        [Column("Id")]
        public string Id { get; set; }
        [Column("Nome")]
        public string Nome { get; set; }

        public virtual ICollection<Estado> Estados { get; set; }
    }
}
