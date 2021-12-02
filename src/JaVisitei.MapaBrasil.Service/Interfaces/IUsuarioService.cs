using JaVisitei.MapaBrasil.Data.Models;
using JaVisitei.MapaBrasil.Service.Base;

namespace JaVisitei.MapaBrasil.Service.Interfaces
{
    public interface IUsuarioService : IBaseService<Usuario>
    {
        Usuario Autenticacao(Usuario usuario);
    }
}
