using JaVisitei.MapaBrasil.Data.Models;
using JaVisitei.MapaBrasil.Repository.Interfaces;
using JaVisitei.MapaBrasil.Service.Base;
using JaVisitei.MapaBrasil.Service.Interfaces;
using System.Collections.Generic;

namespace JaVisitei.MapaBrasil.Service
{
    public class MunicipioService : BaseService<Municipio>, IMunicipioService
    {
        private readonly IMunicipioRepository _repository;

        public MunicipioService(IMunicipioRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public IEnumerable<Municipio> PesquisarPorEstado(string id)
        {
            return _repository.PesquisarPorEstado(id);
        }
    }
}
