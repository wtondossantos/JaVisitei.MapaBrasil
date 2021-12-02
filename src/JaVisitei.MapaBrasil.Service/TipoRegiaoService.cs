using JaVisitei.MapaBrasil.Data.Models;
using JaVisitei.MapaBrasil.Repository.Interfaces;
using JaVisitei.MapaBrasil.Service.Base;
using JaVisitei.MapaBrasil.Service.Interfaces;

namespace JaVisitei.MapaBrasil.Service
{
    public class TipoRegiaoService : BaseService<TipoRegiao>, ITipoRegiaoService
    {
        private readonly ITipoRegiaoRepository _repository;

        public TipoRegiaoService(ITipoRegiaoRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
