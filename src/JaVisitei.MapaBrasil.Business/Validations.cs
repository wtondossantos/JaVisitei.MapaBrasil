using JaVisitei.MapaBrasil.Data.Models;
using JaVisitei.MapaBrasil.Mapper.Request;
using JaVisitei.MapaBrasil.Mapper.Response;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace JaVisitei.MapaBrasil.Business
{
    public class Validations
    {
        private const string regexEmail = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";

        public List<string> ValidaRegistroUsuario(UsuarioAdicionarRequest model) {

            var retorno = new List<string>();

            Regex regex = new Regex(regexEmail);
            Match match = regex.Match(model.Email);

            if (!match.Success)
                retorno.Add("Email inválido.");

            else if (model.Email != model.ConfirmarEmail)
                retorno.Add("Confirmação do e-mail não confere.");

            else if (model.Senha != model.ConfirmarSenha)
                retorno.Add("Confirmação da senha não confere.");

            else if (model.Senha.Length < 8)
                retorno.Add("A senha deve conter no mínimo 8 caracteres.");

            return retorno;
        }

        public List<string> ValidaAlteracaoUsuario(UsuarioAlterarRequest model, string email)
        {
            var retorno = new List<string>();

            Regex regex = new Regex(regexEmail);
            Match match = regex.Match(model.Email);

            if (!match.Success)
                retorno.Add("Email inválido.");

            else if (model.Email != email && model.Email != model.ConfirmarEmail)
                retorno.Add("Confirmação do e-mail não confere.");

            else if (!string.IsNullOrEmpty(model.Senha))
            { 
                if(model.Senha != model.ConfirmarSenha)
                    retorno.Add("Confirmação da senha não confere.");

                else if(model.Senha.Length < 8)
                    retorno.Add("A senha deve conter no mínimo 8 caracteres.");
            }

            return retorno;
        }

        public List<string> ValidaRegistroVisita(VisitaAdicionarRequest model)
        {
            var retorno = new List<string>();

            if (string.IsNullOrEmpty(model.IdRegiao))
                retorno.Add("Informe uma região.");

            else if (model.IdTipoRegiao == 0)
                retorno.Add("Informe um tipo de região.");

            return retorno;
        }
    }
}
