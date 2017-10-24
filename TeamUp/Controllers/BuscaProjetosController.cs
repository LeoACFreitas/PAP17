using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            vm.Projetos = projetoRepository.PagedProjetosWithFilters(vm.IdCategoriaSelecionada, vm.TituloProjetoBusca, vm.VagaBusca, vm.Pagina);            

            return View("BuscaProjetosView", vm);
        }

    }
}