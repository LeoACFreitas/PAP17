using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamUp.Models;

namespace TeamUp.Repositories
{
    public class CategoriaProjetoRepository : BaseRepository<CategoriaProjeto>, ICategoriaProjetoRepository
    {
        public CategoriaProjetoRepository(TeamUpContext context) : base(context)
        {
        }

        public override List<CategoriaProjeto> SimpleWhere(Func<CategoriaProjeto, bool> where)
        {
            return context.categoria_projeto.Where(where).ToList();
        }
    }
}