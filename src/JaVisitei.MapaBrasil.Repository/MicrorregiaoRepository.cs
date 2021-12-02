using JaVisitei.MapaBrasil.Data.Base;
using JaVisitei.MapaBrasil.Data.Models;
using JaVisitei.MapaBrasil.Repository.Base;
using JaVisitei.MapaBrasil.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace JaVisitei.MapaBrasil.Repository
{
    public class MicrorregiaoRepository : BaseRepository<Microrregiao>, IMicrorregiaoRepository
    {
        private new readonly dbJaVisiteiBrasilContext _context;
        private IMesorregiaoRepository _mesorregiao;

        public MicrorregiaoRepository(dbJaVisiteiBrasilContext context) : base(context)
        {
            _context = context;
            _mesorregiao = new MesorregiaoRepository(_context);
        }

        public IEnumerable<Microrregiao> PesquisarPorEstado(string id)
        {
            return Pesquisar(x => x.Id.Substring(0,3) == id.Substring(0, 3));
        }
    }
}
