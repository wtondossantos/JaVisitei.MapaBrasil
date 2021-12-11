using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace JaVisitei.MapaBrasil.Data.Models
{
    [Table("TbTipoRegiao")]
    public partial class TipoRegiao
    {
        public TipoRegiao()
        {
            Visitas = new HashSet<Visita>();
        }

        [Column("Id")]
        public int Id { get; set; }

        [Column("Nome")]
        public string Nome { get; set; }

        internal virtual ICollection<Visita> Visitas { get; set; }

    }
}
