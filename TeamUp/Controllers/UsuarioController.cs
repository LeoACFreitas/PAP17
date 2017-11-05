using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamUp.Repositories;
using TeamUp.ViewModels;

namespace TeamUp.Controllers
{
    public class UsuarioController : BaseController
    {

        private IUsuarioRepository usuarioRepository;

        
        public UsuarioController()
        {
            usuarioRepository = new UsuarioRepository(context);
        }


        public ActionResult Index(int id)
        {

            UsuarioViewModel vm = new UsuarioViewModel()
            {
                Usuario = usuarioRepository.FindWithProjetosAndVagas(id)
            };

            return View("UsuarioView", vm);
        }

    }
}