using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamUp.Models;

namespace TeamUp.Repositories
{
    public class ProjetoRepository : BaseRepository<Projeto>, IProjetoRepository
    {
        public ProjetoRepository(TeamUpContext context) : base(context)
        {
        }

        public override List<Projeto> SimpleWhere(Func<Projeto, bool> where)
        {
            return context.projeto.Where(where).ToList();
        }
    }
}