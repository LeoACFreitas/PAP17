using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TeamUp.Services;
using TeamUp.Util;
using TeamUp.ViewModels;

namespace TeamUp.Controllers
{
    [AllowAnonymous]
    public class AutenticacaoController : BaseController
    {
        
        public ActionResult Index()
        {
            return View("AutenticacaoView");
        }
        

        public ActionResult Login(AutenticacaoViewModel vm)
        {
            using (LoginService loginService = new LoginService())
            {
                try
                {
                    HttpCookie ck = loginService.AuthenticateUser(vm.Email, vm.Senha);
                    Response.Cookies.Add(ck);
                }
                catch (InternalException inEx)
                {
                    ModelState.AddModelError("FalhaAutenticacao", inEx.Message);
                    return View("AutenticacaoView", vm);
                }
            }

            return RedirectToAction("Index", "BuscaProjetos");
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "BuscaProjetos");
        }

    }
}