using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamUp.Models;
using TeamUp.Repositories;
using TeamUp.ViewModels;

namespace TeamUp.Controllers
{
    [AllowAnonymous]
    public class BuscaProjetosController : BaseController
    {

        private ICategoriaProjetoRepository categoriaProjetoRepository;
        private IProjetoRepository projetoRepository;


        public BuscaProjetosController()
        {
            categoriaProjetoRepository = new CategoriaProjetoRepository(context);
            projetoRepository = new ProjetoRepository(context);
        }


        public ActionResult Index(BuscaProjetosViewModel vm)
        {
            if (vm == null)
                vm = new BuscaProjetosViewModel();

            vm.Categorias = categoriaProjetoRepository.SimpleWhere(c => true);
            vm.Projetos = projetoRepository.PagedProjetosWithFilters(vm.IdCategoriaSelecionada, vm.TituloProjetoBusca,
                                                                        vm.VagaBusca, vm.Pagina);

            #region Ordenação para a apresentação
            //List<Projeto> ord = new List<Projeto>();
            //ord.Add(vm.Projetos.Where(p => p.Nome.Contains("Ghost")).First());
            //ord.Add(vm.Projetos.Where(p => p.Nome.Contains("Canary")).First());
            //ord.Add(vm.Projetos.Where(p => p.Nome.Contains("Macaw")).First());
            //ord.Add(vm.Projetos.Where(p => p.Nome.Contains("Goodful")).First());
            //ord.Add(vm.Projetos.Where(p => p.Nome.Contains("Pebble Time")).First());
            //ord.Add(vm.Projetos.Where(p => p.Nome.Contains("Mighty No. 9")).First());
            //vm.Projetos = new PagedList<Projeto>(ord, 1, 6);
            #endregion

            return View("BuscaProjetosView", vm);
        }

    }
}