using JaVisitei.MapaBrasil.Data.Base;
using JaVisitei.MapaBrasil.Data.Models;
using JaVisitei.MapaBrasil.Repository.Base;
using JaVisitei.MapaBrasil.Repository.Interfaces;
using System.Collections.Generic;

namespace JaVisitei.MapaBrasil.Repository
{
    public class MunicipioRepository : BaseRepository<Municipio>, IMunicipioRepository
    {
        private new readonly dbJaVisiteiBrasilContext _context;

        public MunicipioRepository(dbJaVisiteiBrasilContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Municipio> PesquisarPorEstado(string id)
        {
            return Pesquisar(x => x.Id.Substring(0, 3) == id.Substring(0, 3));
        }
    }
}
