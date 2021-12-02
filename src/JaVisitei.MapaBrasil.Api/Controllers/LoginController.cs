using JaVisitei.MapaBrasil.Business;
using JaVisitei.MapaBrasil.Data.Models;
using JaVisitei.MapaBrasil.Mapper;
using JaVisitei.MapaBrasil.Security;
using JaVisitei.MapaBrasil.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace JaVisitei.MapaBrasil.Api.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class LoginController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IUsuarioService _usuario;

        public LoginController(IConfiguration configuration, IUsuarioService usuario)
        {
            _configuration = configuration;
            _usuario = usuario;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index() => Ok("Oi");

        [AllowAnonymous]
        [HttpPost(Name = "PostLogin")]
        [ProducesResponseType(statusCode: 201)]
        [ProducesResponseType(statusCode: 404)]
        [ProducesResponseType(statusCode: 500)]
        public IActionResult Autenticacao([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var retorno = new RetornoValidacao();
                retorno.Sucesso = false;

                var usuario = new Usuario
                {
                    Email = model.Email,
                    Senha = model.Senha
                };

                var resultado = _usuario.Autenticacao(usuario);

                if (resultado != null && !String.IsNullOrEmpty(resultado.Senha))
                {
                    retorno.Mensagem = "Login realizado com sucesso!";
                    retorno.Sucesso = true;
                    return Ok(retorno);
                }

                retorno.Mensagem = "Usuário ou senha inválidos.";
                return Unauthorized();
            }
            return BadRequest();
        }

        [AllowAnonymous]
        [HttpPost("token", Name = "PostToken")]
        [ProducesResponseType(statusCode: 201)]
        [ProducesResponseType(statusCode: 404)]
        [ProducesResponseType(statusCode: 500)]
        public IActionResult Token([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var usuario = new Usuario
                {
                    Email = model.Email,
                    Senha = model.Senha
                };

                var result = _usuario.Autenticacao(usuario);

                if (result != null && !String.IsNullOrEmpty(result.Senha))
                {
                    var token = new TokenString(result, _configuration);
                    return Ok(token.GerarToken());
                }
                return Unauthorized();
            }
            return BadRequest();
        }
    }
}
