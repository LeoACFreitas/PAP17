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
    }
}