using JaVisitei.MapaBrasil.Data.Base;
using JaVisitei.MapaBrasil.Data.Models;
using JaVisitei.MapaBrasil.Repository.Base;
using JaVisitei.MapaBrasil.Repository.Interfaces;

namespace JaVisitei.MapaBrasil.Repository
{
    public class TipoRegiaoRepository : BaseRepository<TipoRegiao>, ITipoRegiaoRepository
    {
        private new readonly dbJaVisiteiBrasilContext _context;

        public TipoRegiaoRepository(dbJaVisiteiBrasilContext context) : base(context)
        {
            _context = context;
        }
    }
}
