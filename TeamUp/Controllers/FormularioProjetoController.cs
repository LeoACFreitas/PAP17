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
                Projeto = new Projeto(),
                Categorias = categoriaProjetoRepository.SimpleWhere(c => true)
            };

            return View("FormularioProjetoView", vm);
        }


        public ActionResult AlteraProjeto(int Id)
        {
            var vm = new FormularioProjetoViewModel
            {
                Projeto = projetoRepository.FindByIdWithVagas(Id),
                ModoValor = FormularioProjetoViewModel.Modo.Alteracao                
            };
            
            vm.Categorias = categoriaProjetoRepository.SimpleWhere(c => true);
            vm.Vagas = new List<Vaga>() { new Vaga(), new Vaga(), new Vaga(), new Vaga(), new Vaga() };

            int cont = 0;
            foreach (Vaga vaga in vm.Projeto.Vaga)
            {
                vm.Vagas[cont] = vaga;
                cont++;
            }

            vm.IdCategoriaSelecionada = vm.Projeto.CategoriaProjetoId;

            if (vm.ImagemCapa != null)
                ImageFileService.StoreFile(ImageType.ProjetoCapa, vm.ImagemCapa, vm.Projeto.Id);
            if (vm.ImagemLogo != null)
                ImageFileService.StoreFile(ImageType.ProjetoLogo, vm.ImagemLogo, vm.Projeto.Id);

            return View("FormularioProjetoView", vm);
        }


        public ActionResult EfetuaCadastro(FormularioProjetoViewModel vm)
        {            
            Projeto projeto = vm.Projeto;
            projeto.UsuarioId = User.Id;
            projeto.Vaga = vm.Vagas.Where(v => v.Funcao != null && v.Descricao != null).ToList();
            projeto.CategoriaProjetoId = vm.IdCategoriaSelecionada;

            if (!ModelState.IsValid)
            {
                vm.Categorias = categoriaProjetoRepository.SimpleWhere(c => true);
                return View("FormularioProjetoView", vm);
            }

            if (vm.ModoValor == FormularioProjetoViewModel.Modo.Cadastro)
            {
                projetoRepository.Save(projeto);
            }
            else if (vm.ModoValor == FormularioProjetoViewModel.Modo.Alteracao)
            {
                projetoRepository.UpdateWithVagas(projeto);
            }

            if (vm.ImagemCapa != null)
                ImageFileService.StoreFile(ImageType.ProjetoCapa, vm.ImagemCapa, projeto.Id);
            if (vm.ImagemLogo != null)
                ImageFileService.StoreFile(ImageType.ProjetoLogo, vm.ImagemLogo, projeto.Id);

            return Content("io");
        }

    }
}