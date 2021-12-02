using JaVisitei.MapaBrasil.Data.Base;
using JaVisitei.MapaBrasil.Data.Models;
using JaVisitei.MapaBrasil.Repository.Base;
using JaVisitei.MapaBrasil.Repository.Interfaces;
using JaVisitei.MapaBrasil.Security;
using System.Linq;

namespace JaVisitei.MapaBrasil.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private new readonly dbJaVisiteiBrasilContext _context;

        public UsuarioRepository(dbJaVisiteiBrasilContext context) : base(context)
        {
            _context = context;
        }

        public Usuario Autenticacao(Usuario usuario)
        {
            var senha = LoginHash.Sha256encrypt(usuario.Senha);

            return Pesquisar(x => x.Senha == senha && x.Email == usuario.Email).FirstOrDefault();
        }

    }
}
