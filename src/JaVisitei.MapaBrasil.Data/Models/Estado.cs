using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace JaVisitei.MapaBrasil.Data.Models
{
    [Table("TbEstado")]
    public partial class Estado
    {
        public Estado()
        {
            Mesorregiaos = new HashSet<Mesorregiao>();
        }

        [Column("Id")]
        public string Id { get; set; }
        [Column("IdPais")]
        public string IdPais { get; set; }
        [Column("Nome")]
        public string Nome { get; set; }
        [Column("Desenho")]
        public string Desenho { get; set; }

        internal virtual Pais IdPaisNavigation { get; set; }
        internal virtual ICollection<Mesorregiao> Mesorregiaos { get; set; }
    }
}
