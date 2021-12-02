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
    public class IlhasController : ControllerBase
    {
        private readonly IIlhaService _ilha;

        public IlhasController(IIlhaService ilha)
        {
            _ilha = ilha;
        }

        [HttpGet(Name = "GetIlhas")]
        [ProducesResponseType(statusCode: 200, Type = typeof(List<Ilha>))]
        public IActionResult Pesquisar()
        {
            var lista = _ilha.Pesquisar();

            if (lista == null)
                return NotFound();

            return Ok(lista);
        }

        [HttpGet("{id_ilha}", Name = "GetIlha")]
        [ProducesResponseType(statusCode: 200, Type = typeof(Ilha))]
        public IActionResult Pesquisar([FromRoute] string id_ilha)
        {
            var model = _ilha.Pesquisar(x => x.Id == id_ilha).ToList();

            if (model == null)
                return NotFound();

            return Ok(model);
        }
    }
}
