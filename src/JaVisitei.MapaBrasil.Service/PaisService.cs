using JaVisitei.MapaBrasil.Data.Models;
using JaVisitei.MapaBrasil.Repository.Interfaces;
using JaVisitei.MapaBrasil.Service.Base;
using JaVisitei.MapaBrasil.Service.Interfaces;

namespace JaVisitei.MapaBrasil.Service
{
    public class PaisService : BaseService<Pais>, IPaisService
    {
        private readonly IPaisRepository _repository;

        public PaisService(IPaisRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
