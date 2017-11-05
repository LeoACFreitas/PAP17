using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        
        public Usuario FindWithProjetosAndVagas(int id)
        {
            return context.usuario.Where(u => u.Id == id)
                    .Include(u => u.Projeto).Include(u => u.Vaga.Select(v => v.Projeto)).FirstOrDefault();
        }

    }
}