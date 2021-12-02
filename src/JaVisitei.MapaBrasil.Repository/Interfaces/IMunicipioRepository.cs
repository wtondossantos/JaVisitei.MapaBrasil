using JaVisitei.MapaBrasil.Data.Models;
using JaVisitei.MapaBrasil.Repository.Base;
using System.Collections.Generic;


namespace JaVisitei.MapaBrasil.Repository.Interfaces
{
    public interface IMunicipioRepository : IBaseRepository<Municipio>
    {
        IEnumerable<Municipio> PesquisarPorEstado(string id);
    }
}
