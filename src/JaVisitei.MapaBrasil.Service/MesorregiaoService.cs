using JaVisitei.MapaBrasil.Data.Models;
using JaVisitei.MapaBrasil.Repository.Interfaces;
using JaVisitei.MapaBrasil.Service.Base;
using JaVisitei.MapaBrasil.Service.Interfaces;

namespace JaVisitei.MapaBrasil.Service
{
    public class MesorregiaoService : BaseService<Mesorregiao>, IMesorregiaoService
    {
        private readonly IMesorregiaoRepository _repository;

        public MesorregiaoService(IMesorregiaoRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
