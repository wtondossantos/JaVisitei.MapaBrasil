using JaVisitei.MapaBrasil.Data.Models;
using JaVisitei.MapaBrasil.Repository.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JaVisitei.MapaBrasil.Repository.Interfaces
{
    public interface IArquipelagoRepository : IBaseRepository<Arquipelago>
    {
        IEnumerable<Arquipelago> PesquisarPorEstado(string id);
    }
}
