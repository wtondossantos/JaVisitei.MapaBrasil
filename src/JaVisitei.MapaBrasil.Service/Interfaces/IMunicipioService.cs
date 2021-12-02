using JaVisitei.MapaBrasil.Data.Models;
using JaVisitei.MapaBrasil.Service.Base;
using System.Collections.Generic;

namespace JaVisitei.MapaBrasil.Service.Interfaces
{
    public interface IMunicipioService : IBaseService<Municipio>
    {
        IEnumerable<Municipio> PesquisarPorEstado(string id);
    }
}
