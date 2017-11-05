using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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


        public Projeto FindByIdWithVagas(int id)
        {
            return context.projeto.Where(p => p.Id == id).Include(p => p.Vaga).FirstOrDefault();
        }
        

        public void UpdateWithVagas(Projeto projeto)
        {
            var entity = context.projeto.Where(p => p.Id == projeto.Id).First();
            context.Entry(entity).CurrentValues.SetValues(projeto);

            context.SaveChanges();

            foreach (Vaga vaga in projeto.Vaga)
            {
                var original = context.vaga.Where(v => v.Id == vaga.Id).First();

                vaga.ProjetoId = original.ProjetoId;
                vaga.UsuarioId = original.UsuarioId;

                context.Entry(original).CurrentValues.SetValues(vaga);

                context.SaveChanges();
            }
            
        }


        public IPagedList<Projeto> PagedProjetosWithFilters(int idCategoriaSelecionada, string tituloProjetoBusca, 
                                                            string vagaBusca, int pagina)
        {
            var query = context.projeto.Where(p => true);

            if (idCategoriaSelecionada != 0)
                query = query.Where(p => p.CategoriaProjetoId == idCategoriaSelecionada);

            if (!String.IsNullOrEmpty(tituloProjetoBusca))
                query = query.Where(p => p.Nome.Contains(tituloProjetoBusca));

            if (!String.IsNullOrEmpty(vagaBusca))
                query = query.Where(p => p.Vaga.Any(v => v.Funcao.Contains(vagaBusca)));

            query = query.Include(p => p.Vaga).Include(p => p.CategoriaProjeto).Include(p => p.Usuario)
                                                                            .OrderByDescending(p => p.Id);

            return query.ToPagedList(pagina, 6);
        }


        public void SaveAplicacao(Aplicacao aplicacao)
        {
            context.aplicacao.Add(aplicacao);
            context.SaveChanges();
        }


        public List<Aplicacao> GetAplicacoesByProjeto(int projetoId)
        {
            return context.aplicacao.Where(a => a.Vaga.ProjetoId == projetoId)
                    .Include(a => a.Vaga).Include(a => a.Vaga.Projeto).ToList();
        }


        public void DeleteAplicacao(Aplicacao aplicacao)
        {
            context.Entry(aplicacao).State = EntityState.Deleted;

            context.SaveChanges();
        }


        public Aplicacao FindAplicacao(int vagaId, int usuarioId)
        {
            return context.aplicacao.Where(a => a.VagaId == vagaId && a.UsuarioId == usuarioId)
                    .Include(a => a.Vaga).Include(a => a.Vaga.Projeto).Include(a => a.Usuario).FirstOrDefault();
        }

    }
}