using JaVisitei.MapaBrasil.Data.Models;
using JaVisitei.MapaBrasil.Repository.Interfaces;
using JaVisitei.MapaBrasil.Service.Base;
using JaVisitei.MapaBrasil.Service.Interfaces;

namespace JaVisitei.MapaBrasil.Service
{
    public class VisitaService : BaseService<Visita>, IVisitaService
    {
        private readonly IVisitaRepository _repository;

        public VisitaService(IVisitaRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
