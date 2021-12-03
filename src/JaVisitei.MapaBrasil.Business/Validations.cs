using JaVisitei.MapaBrasil.Data.Models;
using JaVisitei.MapaBrasil.Mapper.Request;
using System.Text.RegularExpressions;

namespace JaVisitei.MapaBrasil.Business
{
    public class Validations
    {
        private const string regexEmail = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";

        public RetornoValidacao ValidaRegistroUsuario(UsuarioAdicionarRequest model) {

            var retorno = new RetornoValidacao();
            retorno.Sucesso = false;

            Regex regex = new Regex(regexEmail);
            Match match = regex.Match(model.Email);

            if (!match.Success)
                retorno.Mensagem = "Email inválido.";

            else if (model.Email != model.ConfirmarEmail)
                retorno.Mensagem = "A e-mail não confere.";

            else if (model.Senha != model.ConfirmarSenha)
                retorno.Mensagem = "A senha não confere.";

            else if (model.Senha.Length < 8)
                retorno.Mensagem = "A senha deve conter no mínimo 8 caracteres.";

            return retorno;
        }

        public RetornoValidacao ValidaAlteracaoUsuario(UsuarioAlterarRequest model, string email)
        {

            var retorno = new RetornoValidacao();
            retorno.Sucesso = false;

            Regex regex = new Regex(regexEmail);
            Match match = regex.Match(model.Email);

            if (!match.Success)
                retorno.Mensagem = "Email inválido.";

            else if (model.Email != email && model.Email != model.ConfirmarEmail)
                retorno.Mensagem = "A e-mail não confere.";

            else if (!string.IsNullOrEmpty(model.Senha))
            { 
                if(model.Senha != model.ConfirmarSenha)
                    retorno.Mensagem = "A senha não confere.";

                else if(model.Senha.Length < 8)
                    retorno.Mensagem = "A senha deve conter no mínimo 8 caracteres.";
            }

            return retorno;
        }

        public RetornoValidacao ValidaRegistroVisita(VisitaAdicionarRequest model)
        {
            var retorno = new RetornoValidacao();
            retorno.Sucesso = false;

            if (string.IsNullOrEmpty(model.IdRegiao))
                retorno.Mensagem = "Informe uma região.";

            else if (model.IdTipoRegiao == 0)
                retorno.Mensagem = "Informe um tipo de região.";

            return retorno;
        }
    }
}
