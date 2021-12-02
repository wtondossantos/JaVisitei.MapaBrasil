using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace JaVisitei.MapaBrasil.Data.Models
{
    [Table("TbVisita")]
    public partial class Visita
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("IdUsuario")]
        public int IdUsuario { get; set; }

        [Column("IdTipoRegiao")]
        public int IdTipoRegiao { get; set; }

        [Column("IdRegiao")]
        public string IdRegiao { get; set; }

        [Column("Cor")]
        public string Cor { get; set; }

        [Column("Data")]
        public DateTime Data { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }

        public virtual TipoRegiao IdTipoRegiaoNavigation { get; set; }
    }
}
