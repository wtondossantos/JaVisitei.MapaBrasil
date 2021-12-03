using System;
using System.ComponentModel.DataAnnotations;

namespace JaVisitei.MapaBrasil.Mapper.Request
{
    public class UsuarioAdicionarRequest
    {
        [Required]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "Sobrenome")]
        public string Sobrenome { get; set; }

        [Required]
        [Display(Name = "NomeUsuario")]
        public string NomeUsuario { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "ConfirmarEmail")]
        public string ConfirmarEmail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Senha { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "ConfirmarSenha")]
        public string ConfirmarSenha { get; set; }
    }
}
