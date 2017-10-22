using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamUp.Models;

namespace TeamUp.Repositories
{
    interface IProjetoRepository : IRepository<Projeto>
    {

        Projeto FindByIdWithVagas(int id);

        void UpdateWithVagas(Projeto projeto);

        IPagedList<Projeto> PagedProjetosWithFilters(int idCategoriaSelecionada, string tituloProjetoBusca, string vagaBusca, int pagina);

    }
}
