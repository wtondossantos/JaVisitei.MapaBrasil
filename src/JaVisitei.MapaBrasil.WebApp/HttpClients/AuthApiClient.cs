using JaVisitei.MapaBrasil.Mapper.Request;
using JaVisitei.MapaBrasil.Mapper.Response;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JaVisitei.MapaBrasil.WebApp.HttpClients
{
    public class AuthApiClient
    {
        private readonly HttpClient _httpClient;

        public AuthApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<LoginResult> PostLoginAsync(LoginRequest model)
        {
            string json = JsonConvert.SerializeObject(model);

            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var resposta = await _httpClient.PostAsync("api/v1/perfil/login", httpContent);

            //return new LoginResult(await resposta.Content.ReadAsStringAsync(), resposta.StatusCode);
            return null;
        }

        //public async Task PostRegisterAsync(RegisterViewModel model)
        //{
        //    var resposta = await _httpClient.PostAsJsonAsync<RegisterViewModel>("usuarios", model);
        //    resposta.EnsureSuccessStatusCode();
        //}

    }
}
