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

        void SaveAplicacao(Aplicacao aplicacao);

        IPagedList<Projeto> PagedProjetosWithFilters(int idCategoriaSelecionada, string tituloProjetoBusca, 
                                                        string vagaBusca, int pagina);

        List<Aplicacao> GetAplicacoesByProjeto(int projetoId);

        void DeleteAplicacao(Aplicacao aplicacao);

        Aplicacao FindAplicacao(int vagaId, int usuarioId);

    }
}
