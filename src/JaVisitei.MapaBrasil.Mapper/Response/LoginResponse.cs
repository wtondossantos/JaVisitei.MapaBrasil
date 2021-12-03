using System;
using System.Text.Json.Serialization;

namespace JaVisitei.MapaBrasil.Mapper.Response
{
    public class LoginResponse
    {
        [JsonPropertyName("expiracao")]
        public DateTime Expiracao { get; set; }

        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("validacao")]
        public ValidacaoResponse Validacao { get; set; }
    }
}