using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamUp.Models;

namespace TeamUp.Repositories
{
    interface IVagaRepository : IRepository<Vaga>
    {
        Vaga FindVagaByIdWithProjeto(int id);
    }
}
