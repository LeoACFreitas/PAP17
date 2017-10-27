using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamUp.Models;

namespace TeamUp.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {


        public UsuarioRepository(TeamUpContext context) : base(context)
        {
        }


        public Usuario FindDiferente()
        {
            throw new NotImplementedException();
        }
        
    }
}