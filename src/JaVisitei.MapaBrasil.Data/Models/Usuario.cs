using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace JaVisitei.MapaBrasil.Data.Models
{
    [Table("TbUsuario")]
    public partial class Usuario
    {
        public Usuario()
        {
            Visitas = new HashSet<Visita>();
        }

        [Column("Id")]
        public int Id { get; set; }
        [Column("Nome")]
        public string Nome { get; set; }
        [Column("Sobrenome")]
        public string Sobrenome { get; set; }
        [Column("NomeUsuario")]
        public string NomeUsuario { get; set; }
        [Column("Email")]
        public string Email { get; set; }
        [Column("Senha")]
        public string Senha { get; set; }

        public virtual ICollection<Visita> Visitas { get; set; }

    }
}
