using JaVisitei.MapaBrasil.Data.Models;
using JaVisitei.MapaBrasil.Service.Base;
using System.Collections.Generic;

namespace JaVisitei.MapaBrasil.Service.Interfaces
{
    public interface IIlhaService : IBaseService<Ilha>
    {
        IEnumerable<Ilha> PesquisarPorEstado(string id);
    }
}
