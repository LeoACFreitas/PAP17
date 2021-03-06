﻿using System;
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
            vm.Vagas = new List<Vaga>(Enumerable.Repeat<Vaga>(new Vaga(), 5));

            int cont = 0;
            foreach (Vaga vaga in vm.Projeto.Vaga)
            {
                vm.Vagas[cont] = vaga;
                cont++;
            }

            vm.IdCategoriaSelecionada = vm.Projeto.CategoriaProjetoId;
            
            return View("FormularioProjetoView", vm);
        }

        
        public ActionResult EfetuaCadastro(FormularioProjetoViewModel vm)
        {            
            Projeto projeto = vm.Projeto;
            projeto.UsuarioId = User.Id;
            projeto.Vaga = vm.Vagas.Where(v => v.Funcao != null && v.Descricao != null).ToList();
            projeto.CategoriaProjetoId = vm.IdCategoriaSelecionada;

            if (vm.ModoValor == FormularioProjetoViewModel.Modo.Cadastro && projetoRepository.SimpleWhere(p => p.Nome.Equals(projeto.Nome)).Count() != 0)
                ModelState.AddModelError("Projeto.Nome", "Já existe um projeto com este título.");

            if (projeto.Vaga.Count < 1)
                ModelState.AddModelError("other", "É necessário cadastrar ao menos uma vaga.");
            
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

            TempData["mensagemRetorno"] = "Projeto " + (vm.ModoValor == FormularioProjetoViewModel.Modo.Cadastro ?
                                                        "cadastrado" : "alterado") + " com sucesso!";
            
            return RedirectToAction("Index", "Projeto", new { Id = projeto.Id });
        }

    }
}
