using JaVisitei.MapaBrasil.Data.Models;
using JaVisitei.MapaBrasil.Repository.Base;
using System;
using System.Collections.Generic;


namespace JaVisitei.MapaBrasil.Repository.Interfaces
{
    public interface IMicrorregiaoRepository : IBaseRepository<Microrregiao>
    {
        IEnumerable<Microrregiao> PesquisarPorEstado(string id);
    }
}
