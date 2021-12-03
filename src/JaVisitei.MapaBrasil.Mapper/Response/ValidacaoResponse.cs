using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace JaVisitei.MapaBrasil.Mapper.Response
{
    public class ValidacaoResponse
    {
        [JsonPropertyName("codigo")]
        public int Codigo { get; set; }

        [JsonPropertyName("mensagem")]
        public string Mensagem { get; set; }

        [JsonPropertyName("sucesso")]
        public bool Sucesso { get; set; }
    }
}
