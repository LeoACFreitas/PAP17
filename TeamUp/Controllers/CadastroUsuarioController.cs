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
    public class CadastroUsuarioController : Controller
    {

        public ActionResult Index()
        {
            return View("CadastroUsuarioView");
        }

        public ActionResult EfetuaCadastro(CadastroUsuarioViewModel vm)
        {

            Usuario usuario = new Usuario
            {
                Email = vm.Email,
                Senha = LoginService.GetHash(vm.Senha),
                PrimeiroNome = vm.PrimeiroNome,
                UltimoNome = vm.UltimoNome
            };


            using (TeamUpContext context = new TeamUpContext())
            {
                UsuarioRepository repo = new UsuarioRepository(context);
                repo.Save(usuario);
            }

            return Content("oi");
        }

    }
}