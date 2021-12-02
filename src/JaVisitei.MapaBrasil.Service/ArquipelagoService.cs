using JaVisitei.MapaBrasil.Data.Models;
using JaVisitei.MapaBrasil.Repository.Interfaces;
using JaVisitei.MapaBrasil.Service.Base;
using JaVisitei.MapaBrasil.Service.Interfaces;
using System.Collections.Generic;

namespace JaVisitei.MapaBrasil.Service
{
    public class ArquipelagoService : BaseService<Arquipelago>, IArquipelagoService
    {
        private readonly IArquipelagoRepository _repository;

        public ArquipelagoService(IArquipelagoRepository repository) : base(repository)
        {
            _repository = repository;
        }
        public IEnumerable<Arquipelago> PesquisarPorEstado(string id)
        {
            return _repository.PesquisarPorEstado(id);
        }
    }
}
