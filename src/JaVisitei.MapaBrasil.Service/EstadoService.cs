using JaVisitei.MapaBrasil.Data.Models;
using JaVisitei.MapaBrasil.Repository.Interfaces;
using JaVisitei.MapaBrasil.Service.Base;
using JaVisitei.MapaBrasil.Service.Interfaces;

namespace JaVisitei.MapaBrasil.Service
{
    public class EstadoService : BaseService<Estado>, IEstadoService
    {
        private readonly IEstadoRepository _repository;

        public EstadoService(IEstadoRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
