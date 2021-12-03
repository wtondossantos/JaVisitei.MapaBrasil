using JaVisitei.MapaBrasil.Business;
using JaVisitei.MapaBrasil.Data.Models;
using JaVisitei.MapaBrasil.Mapper.Request;
using JaVisitei.MapaBrasil.Mapper.Response;
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
    [ControllerName("Autenticação")]
    [Route("api/v{version:apiVersion}/perfil")]
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
        [HttpGet("login2", Name = "GetLogin")]
        [ProducesResponseType(statusCode: 201)]
        [ProducesResponseType(statusCode: 404)]
        [ProducesResponseType(statusCode: 500)]
        public IActionResult Autenticacao([FromBody] LoginRequest model)
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
        [HttpPost("login", Name = "PostLogin")]
        [ProducesResponseType(statusCode: 201)]
        [ProducesResponseType(statusCode: 404)]
        [ProducesResponseType(statusCode: 500)]
        public IActionResult Login([FromBody] LoginRequest model)
        {
            if (ModelState.IsValid)
            {
                var validacao = new ValidacaoResponse();
                var usuario = new Usuario
                {
                    Email = model.Email,
                    Senha = model.Senha
                };

                var resultado = _usuario.Autenticacao(usuario);

                if (resultado != null && !String.IsNullOrEmpty(resultado.Senha))
                {
                    var tokenizar = new TokenString(resultado, _configuration);
                    var token = tokenizar.GerarToken();

                    validacao.Mensagem = "Login realizado com sucesso";
                    validacao.Codigo = 1;
                    validacao.Sucesso = true;

                    var retorno = new LoginResponse {
                        Expiracao = DateTime.Now.AddDays(3),
                        Token = token,
                        Validacao = validacao
                    };

                    return Ok(retorno);
                }

                validacao.Mensagem = "Usuário ou senha inválidos.";
                validacao.Codigo = 0;
                validacao.Sucesso = false;

                return Unauthorized(validacao);
            }

            return BadRequest();
        }
    }
}
