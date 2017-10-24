using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamUp.Models;
using TeamUp.Repositories;
using TeamUp.Services;
using TeamUp.Util;
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


        [AllowAnonymous]
        public ActionResult Index()
        {
            var vm = new FormularioUsuarioViewModel
            {
                ModoValor = FormularioUsuarioViewModel.Modo.Cadastro
            };

            return View("FormularioUsuarioView", vm);
        }


        public ActionResult AlteraUsuario()
        {
            var vm = new FormularioUsuarioViewModel
            {
                Usuario = usuarioRepository.FindById(User.Id),
                ModoValor = FormularioUsuarioViewModel.Modo.Alteracao
            };

            return View("FormularioUsuarioView", vm);
        }


        [AllowAnonymous]
        public ActionResult EfetuaCadastro(FormularioUsuarioViewModel vm)
        {
            Usuario usuario = vm.Usuario;

            if (vm.ModoValor == FormularioUsuarioViewModel.Modo.Cadastro)
            {
                usuario.Senha = LoginService.GetHash(usuario.Senha);

                usuarioRepository.Save(usuario);
            }
            else if (vm.ModoValor == FormularioUsuarioViewModel.Modo.Alteracao)
            {
                usuario.Senha = usuarioRepository.FindById(usuario.Id).Senha;

                usuarioRepository.Update(usuario);
            }

            if (vm.ImagemPerfil != null)
                ImageFileService.StoreFile(ImageType.UsuarioPerfil, vm.ImagemPerfil, usuario.Id);

            return Content("oi");
        }


        public ActionResult AlteraSenha(FormularioUsuarioViewModel vm)
        {
            using (LoginService loginService = new LoginService())
            {
                try
                {
                    loginService.AuthenticateUser(User.Email, vm.VerificacaoSenhaAlteracao);
                }
                catch (InternalException)
                {
                    return Json(new { success = false, responseText = "Senha incorreta." });
                }
            }
            
            usuarioRepository.Update(vm.Usuario);

            return Json(new { success = true, responseText = "A sua senha foi alterada com sucesso." });
        }
        

    }
}