﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace JaVisitei.MapaBrasil.Data.Models
{
    [Table("TbIlha")]
    public partial class Ilha
    {
        [Column("Id")]
        public string Id { get; set; }
        [Column("IdArquipelago")]
        public string IdArquipelago { get; set; }
        [Column("Nome")]
        public string Nome { get; set; }
        [Column("Desenho")]
        public string Desenho { get; set; }

        public virtual Arquipelago IdArquipelagoNavigation { get; set; }
    }
}
