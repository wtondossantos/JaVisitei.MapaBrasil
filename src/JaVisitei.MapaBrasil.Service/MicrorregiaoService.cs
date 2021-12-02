using JaVisitei.MapaBrasil.Data.Models;
using JaVisitei.MapaBrasil.Repository.Interfaces;
using JaVisitei.MapaBrasil.Service.Base;
using JaVisitei.MapaBrasil.Service.Interfaces;
using System.Collections.Generic;

namespace JaVisitei.MapaBrasil.Service
{
    public class MicrorregiaoService : BaseService<Microrregiao>, IMicrorregiaoService
    {
        private readonly IMicrorregiaoRepository _repository;

        public MicrorregiaoService(IMicrorregiaoRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public IEnumerable<Microrregiao> PesquisarPorEstado(string id)
        { 
            return _repository.PesquisarPorEstado(id);
        }
    }
}
