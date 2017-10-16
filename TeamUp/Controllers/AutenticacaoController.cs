using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamUp.Services;
using TeamUp.ViewModels;

namespace TeamUp.Controllers
{
    public class AutenticacaoController : Controller
    {
        
        public ActionResult Index()
        {
            return View("AutenticacaoView");
        }
        

        public ActionResult Login(AutenticacaoViewModel vm)
        {
            LoginService.AuthenticateUser(vm.Email, vm.Senha);

            return Content("oi");
        }

    }
}