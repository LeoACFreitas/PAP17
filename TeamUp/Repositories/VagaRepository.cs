using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamUp.Models;

namespace TeamUp.Repositories
{
    public class VagaRepository : BaseRepository<Vaga>, IVagaRepository
    {
        public VagaRepository(TeamUpContext context) : base(context)
        {
        }
    }
}