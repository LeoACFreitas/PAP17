using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamUp.Models;
using TeamUp.Repositories;
using TeamUp.Services;
using TeamUp.ViewModels;

namespace TeamUp.Controllers
{
    public class FormularioUsuarioController : BaseController
    {

        private IUsuarioRepository usuarioRepository;


        public FormularioUsuarioController()
        {
            usuarioRepository = new UsuarioRepository(context);
        }


        public ActionResult Index()
        {
            return View("FormularioUsuarioView");
        }


        public ActionResult AlteraUsuario()
        {
            var vm = new FormularioUsuarioViewModel
            {
                Usuario = usuarioRepository.FindById(User.Id)
            };

            return View("FormularioUsuarioView");
        }


        public ActionResult EfetuaCadastro(FormularioUsuarioViewModel vm)
        {
            Usuario usuario = vm.Usuario;
            usuario.Senha = LoginService.GetHash(usuario.Senha);
            
            usuarioRepository.Save(usuario);            

            return Content("oi");
        }
        

    }
}