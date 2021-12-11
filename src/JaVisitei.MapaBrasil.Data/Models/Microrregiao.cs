using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace JaVisitei.MapaBrasil.Data.Models
{
    [Table("TbMicrorregiao")]
    public partial class Microrregiao
    {
        public Microrregiao()
        {
            Municipios = new HashSet<Municipio>();
        }

        [Column("Id")]
        public string Id { get; set; }
        [Column("IdMesorregiao")]
        public string IdMesorregiao { get; set; }
        [Column("Nome")]
        public string Nome { get; set; }
        [Column("Desenho")]
        public string Desenho { get; set; }

        internal virtual Mesorregiao IdMesorregiaoNavigation { get; set; }
        public virtual ICollection<Municipio> Municipios { get; set; }
    }
}
