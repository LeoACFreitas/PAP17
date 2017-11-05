using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamUp.Models;

namespace TeamUp.Repositories
{
    interface IUsuarioRepository : IRepository<Usuario>
    {

        Usuario FindWithProjetosAndVagas(int id);

    }
}
