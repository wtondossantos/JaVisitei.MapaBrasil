using JaVisitei.MapaBrasil.Data.Models;
using JaVisitei.MapaBrasil.Service.Base;
using System.Collections.Generic;

namespace JaVisitei.MapaBrasil.Service.Interfaces
{
    public interface IMicrorregiaoService : IBaseService<Microrregiao>
    {
        IEnumerable<Microrregiao> PesquisarPorEstado(string id);
    }
}
