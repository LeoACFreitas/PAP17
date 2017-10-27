using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamUp.Repositories;
using TeamUp.ViewModels;

namespace TeamUp.Controllers
{
    public class PainelControleController : BaseController
    {

        private IProjetoRepository projetoRepository;

        public PainelControleController()
        {
            projetoRepository = new ProjetoRepository(context);
        }

        public ActionResult Index()
        {
            PainelControleViewModel vm = new PainelControleViewModel()
            {
                Projetos = projetoRepository.SimpleWhere(p => p.UsuarioId == User.Id)
            };

            return View("PainelControleView", vm);
        }

    }
}