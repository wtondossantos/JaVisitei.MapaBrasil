using JaVisitei.MapaBrasil.Data.Models;
using JaVisitei.MapaBrasil.Repository.Interfaces;
using JaVisitei.MapaBrasil.Service.Base;
using JaVisitei.MapaBrasil.Service.Interfaces;
using System.Collections.Generic;

namespace JaVisitei.MapaBrasil.Service
{
    public class IlhaService : BaseService<Ilha>, IIlhaService
    {
        private readonly IIlhaRepository _repository;

        public IlhaService(IIlhaRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public IEnumerable<Ilha> PesquisarPorEstado(string id)
        {
            return _repository.PesquisarPorEstado(id);
        }
    }
}
