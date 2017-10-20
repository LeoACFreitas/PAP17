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
    public class FormularioProjetoController : BaseController
    {

        private ICategoriaProjetoRepository categoriaProjetoRepository;
        private IProjetoRepository projetoRepository;

        public FormularioProjetoController()
        {
            categoriaProjetoRepository = new CategoriaProjetoRepository(context);
            projetoRepository = new ProjetoRepository(context);
        }

        public ActionResult Index()
        {
            FormularioProjetoViewModel vm = new FormularioProjetoViewModel
            {
                Categorias = categoriaProjetoRepository.SimpleWhere(c => true)
            };

            return View("FormularioProjetoView", vm);
        }


        public ActionResult EfetuaCadastro(FormularioProjetoViewModel vm)
        {
            Projeto projeto = vm.Projeto;
            projeto.UsuarioId = User.Id;
            projeto.Vaga = vm.Vagas;

            projetoRepository.Save(projeto);

            return Content("io");
        }

    }
}