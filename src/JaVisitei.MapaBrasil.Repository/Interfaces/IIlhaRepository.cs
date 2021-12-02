using JaVisitei.MapaBrasil.Data.Models;
using JaVisitei.MapaBrasil.Repository.Base;
using System.Collections.Generic;

namespace JaVisitei.MapaBrasil.Repository.Interfaces
{
    public interface IIlhaRepository : IBaseRepository<Ilha>
    {
        IEnumerable<Ilha> PesquisarPorEstado(string id);
    }
}
