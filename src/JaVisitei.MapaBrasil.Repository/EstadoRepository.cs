using JaVisitei.MapaBrasil.Data.Base;
using JaVisitei.MapaBrasil.Data.Models;
using JaVisitei.MapaBrasil.Repository.Base;
using JaVisitei.MapaBrasil.Repository.Interfaces;

namespace JaVisitei.MapaBrasil.Repository
{
    public class EstadoRepository : BaseRepository<Estado>, IEstadoRepository
    {
        private new readonly dbJaVisiteiBrasilContext _context;

        public EstadoRepository(dbJaVisiteiBrasilContext context) : base(context)
        {
            _context = context;
        }
    }
}