using JaVisitei.MapaBrasil.Mapper.Response;

namespace JaVisitei.MapaBrasil.WebApp.HttpClients
{
    public class LoginResult
    {
        LoginResponse _loginResponse;

        public LoginResult(LoginResponse loginResponse)
        {
            _loginResponse = loginResponse;
        }
    }
}
