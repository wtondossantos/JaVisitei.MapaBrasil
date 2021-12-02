using JaVisitei.MapaBrasil.Data.Base;
using JaVisitei.MapaBrasil.Data.Models;
using JaVisitei.MapaBrasil.Repository.Base;
using JaVisitei.MapaBrasil.Repository.Interfaces;

namespace JaVisitei.MapaBrasil.Repository
{
    public class MesorregiaoRepository : BaseRepository<Mesorregiao>, IMesorregiaoRepository
    {
        private new readonly dbJaVisiteiBrasilContext _context;

        public MesorregiaoRepository(dbJaVisiteiBrasilContext context) : base(context)
        {
            _context = context;
        }
    }
}