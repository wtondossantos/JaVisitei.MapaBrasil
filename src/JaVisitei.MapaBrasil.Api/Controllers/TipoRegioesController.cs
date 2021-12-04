using JaVisitei.MapaBrasil.Data.Models;
using JaVisitei.MapaBrasil.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace JaVisitei.MapaBrasil.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1")]
    [ControllerName("Regiões")]
    [Route("api/v{version:apiVersion}/regiao")]
    public class TipoRegioesController : ControllerBase
    {
        private readonly ITipoRegiaoService _tiporegiao;

        public TipoRegioesController(ITipoRegiaoService tiporegiao)
        {
            _tiporegiao = tiporegiao;
        }

        [HttpGet("tipo", Name = "GetTipoRegioes")]
        [ProducesResponseType(statusCode: 200, Type = typeof(List<TipoRegiao>))]
        public IActionResult Pesquisar()
        {
            var lista = _tiporegiao.Pesquisar();

            if (lista == null)
                return NotFound();

            return Ok(lista);
        }
    }
}
