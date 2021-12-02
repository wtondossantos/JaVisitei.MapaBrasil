﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace JaVisitei.MapaBrasil.Data.Models
{
    [Table("TbMesorregiao")]
    public partial class Mesorregiao
    {
        public Mesorregiao()
        {
            Arquipelagos = new HashSet<Arquipelago>();
            Microrregiaos = new HashSet<Microrregiao>();
        }

        [Column("Id")]
        public string Id { get; set; }
        [Column("IdEstado")]
        public string IdEstado { get; set; }
        [Column("Nome")]
        public string Nome { get; set; }
        [Column("Desenho")]
        public string Desenho { get; set; }

        public virtual Estado IdEstadoNavigation { get; set; }
        public virtual ICollection<Arquipelago> Arquipelagos { get; set; }
        public virtual ICollection<Microrregiao> Microrregiaos { get; set; }
    }
}
