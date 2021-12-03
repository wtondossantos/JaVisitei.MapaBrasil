using AutoMapper;
using JaVisitei.MapaBrasil.Business;
using JaVisitei.MapaBrasil.Data.Models;
using JaVisitei.MapaBrasil.Mapper.Request;
using JaVisitei.MapaBrasil.Security;
using JaVisitei.MapaBrasil.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace JaVisitei.MapaBrasil.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [ControllerName("Usuários")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuario;

        public UsuariosController(IUsuarioService usuario)
        {
            _usuario = usuario;
        }

        [Authorize]
        [HttpGet("{username}", Name = "GetUsuarioUsername")]
        [ProducesResponseType(statusCode: 200, Type = typeof(List<Usuario>))]
        [ProducesResponseType(statusCode: 404)]
        [ProducesResponseType(statusCode: 500)]
        public IActionResult PesquisarUsuarioUsername(string username)
        {
            var model = _usuario.Pesquisar(x => x.NomeUsuario == username).ToList();
            
            if (model == null)
                return NotFound();

            return Ok(model);
        }

        [AllowAnonymous]
        [HttpPost(Name = "PostUsuario")]
        [ProducesResponseType(statusCode: 201)]
        [ProducesResponseType(statusCode: 404)]
        [ProducesResponseType(statusCode: 500)]
        public IActionResult AdicionarUsuario([FromBody] UsuarioAdicionarRequest model)
        {
            if (ModelState.IsValid)
            {
                var validacao = new Validations();
                var retorno = new RetornoValidacao();
                retorno.Sucesso = false;

                try
                {
                    if (_usuario.Pesquisar(x => x.Email == model.Email).ToList().Count > 0)
                        retorno.Mensagem = "Já existe usuário com este e-mail.";

                    else
                    {
                        retorno = validacao.ValidaRegistroUsuario(model);

                        if (!string.IsNullOrEmpty(retorno.Mensagem))
                            return Ok(retorno);

                        var usuario = new Usuario()
                        {
                            Nome = model.Nome,
                            Sobrenome = model.Sobrenome,
                            NomeUsuario = model.NomeUsuario,
                            Email = model.Email,
                            Senha = LoginHash.Sha256encrypt(model.Senha)
                        };

                        _usuario.Adicionar(usuario);
                        retorno.Sucesso = true;
                        retorno.Mensagem = $"Usuário {model.Email} registrado com sucesso.";
                    }
                }
                catch(Exception ex)
                {
                    retorno.Mensagem = "Erro ao registrar usuário.";
                }

                return Ok(retorno);
            }
            return BadRequest();
        }

        [AllowAnonymous]
        [HttpPost("{id_usuario}", Name = "PostUsuarioId")]
        [ProducesResponseType(statusCode: 201)]
        [ProducesResponseType(statusCode: 404)]
        [ProducesResponseType(statusCode: 500)]
        public IActionResult AlterarUsuario([FromRoute] int id_usuario, [FromBody] UsuarioAlterarRequest model)
        {
            if (ModelState.IsValid)
            {
                var validacao = new Validations();
                var retorno = new RetornoValidacao();
                retorno.Sucesso = false;

                try
                {
                    var usuario = _usuario.Pesquisar(x => x.Id == id_usuario).FirstOrDefault();

                    if (usuario == null)
                    {
                        retorno.Mensagem = $"Usuário não encontrato.";
                        return Ok(retorno);
                    }

                    var resultado = _usuario.Autenticacao(new Usuario() { 
                        Email = usuario.Email,
                        Senha = LoginHash.Sha256encrypt(model.SenhaAntiga)
                    });

                    if (resultado == null && String.IsNullOrEmpty(resultado.Senha))
                    {
                        retorno.Mensagem = $"Senha antiga incorreta.";
                        return Ok(retorno);
                    }

                    retorno = validacao.ValidaAlteracaoUsuario(model, usuario.Email);

                    if (!string.IsNullOrEmpty(retorno.Mensagem))
                        return Ok(retorno);

                    usuario.Nome = model.Nome;
                    usuario.Sobrenome = model.Sobrenome;

                    if (_usuario.Pesquisar(x => x.Id != id_usuario && x.NomeUsuario == model.NomeUsuario).ToList().Count > 0)
                    {
                        retorno.Mensagem = "Já existe usuário cadastrado com esse nome de usuário.";
                        return Ok(retorno);
                    }
                    else
                        usuario.NomeUsuario = model.NomeUsuario;

                    if (_usuario.Pesquisar(x => x.Id != id_usuario && x.Email == model.Email).ToList().Count > 0)
                    {
                        retorno.Mensagem = "Já existe usuário cadastrado com esse e-mail.";
                        return Ok(retorno);
                    }
                    else
                        usuario.Email = model.Email;

                    if (!string.IsNullOrEmpty(model.Senha))
                        usuario.Senha = LoginHash.Sha256encrypt(model.Senha);
                    
                    _usuario.Alterar(usuario);
                    retorno.Sucesso = true;
                    retorno.Mensagem = $"Usuário {model.Email} atualizado com sucesso.";
                }
                catch (Exception ex)
                {
                    retorno.Mensagem = "Erro ao alterar usuário.";
                }

                return Ok(retorno);
            }
            return BadRequest();
        }
    }
}
