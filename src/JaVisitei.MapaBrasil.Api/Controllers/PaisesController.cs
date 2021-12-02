﻿using JaVisitei.MapaBrasil.Data.Models;
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
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PaisesController : ControllerBase
    {
        private readonly IPaisService _pais;
        private readonly IEstadoService _estado;

        public PaisesController(IPaisService pais, IEstadoService estado)
        {
            _pais = pais;
            _estado = estado;
        }

        [HttpGet(Name = "GetPaises")]
        [ProducesResponseType(statusCode: 200, Type = typeof(List<Pais>))]
        [ProducesResponseType(statusCode: 404)]
        [ProducesResponseType(statusCode: 500)]
        public IActionResult Pesquisar()
        {
            var lista = _pais.Pesquisar();

            if (lista == null)
                return NotFound();

            return Ok(lista);
        }

        [HttpGet("{id_pais}", Name = "GetPais")]
        [ProducesResponseType(statusCode: 200, Type = typeof(Pais))]
        [ProducesResponseType(statusCode: 404)]
        [ProducesResponseType(statusCode: 500)]
        public IActionResult Pesquisar([FromRoute] string id_pais)
        {
            var model = _pais.Pesquisar(x => x.Id == id_pais).ToList();

            if (model == null)
                return NotFound();

            return Ok(model);
        }

        [HttpGet("{id_pais}/estados/", Name = "GetPaisEstados")]
        [ProducesResponseType(statusCode: 200, Type = typeof(List<Estado>))]
        [ProducesResponseType(statusCode: 404)]
        [ProducesResponseType(statusCode: 500)]
        public IActionResult PesquisarEstados([FromRoute] string id_pais)
        {
            var model = _estado.Pesquisar(x => x.IdPais == id_pais).ToList();

            if (model == null)
                return NotFound();

            return Ok(model);
        }
    }
}
