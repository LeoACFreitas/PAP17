﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamUp.Models;
using TeamUp.Repositories;
using TeamUp.ViewModels;

namespace TeamUp.Controllers
{
    public class ProjetoController : BaseController
    {
        
        private IProjetoRepository projetoRepository;
        private INotificacaoRepository notificacaoRepository;
        private IVagaRepository vagaRepository;


        public ProjetoController()
        {
            projetoRepository = new ProjetoRepository(context);
            notificacaoRepository = new NotificacaoRepository(context);
            vagaRepository = new VagaRepository(context);
        }


        [AllowAnonymous]
        public ActionResult Index(int Id)
        {
            ProjetoViewModel vm = new ProjetoViewModel
            {
                Projeto = projetoRepository.FindByIdWithVagas(Id)
            };

            foreach (Vaga v in vm.Projeto.Vaga)
            {
                if (v.Aplicacao.Any(a => a.UsuarioId == User.Id))
                {
                    v.Disponivel = false;
                }
                else
                {
                    v.Disponivel = true;
                }
            }

            return View("ProjetoView", vm);
        }
        

        public ActionResult SalvarAplicacao(ProjetoViewModel vm)
        {
            try
            {
                Vaga vaga = vagaRepository.FindById(vm.Aplicacao.VagaId);
                Projeto projeto = projetoRepository.FindById(vm.Projeto.Id);

                Aplicacao aplicacao = new Aplicacao
                {
                    UsuarioId = User.Id,
                    VagaId = vm.Aplicacao.VagaId,
                    Mensagem = vm.Aplicacao.Mensagem
                };

                projetoRepository.SaveAplicacao(aplicacao);
                notificacaoRepository.Save(new Notificacao() {
                    UsuarioId = projeto.UsuarioId,
                    Mensagem = "O usuário " + User.NomeCompleto + " enviou uma aplicação ao projeto " + projeto.Titulo +
                    " para a vaga de " + vaga.Funcao + "."
                });
            }
            catch
            {
                //TODO: Colocar exceção em log
                Response.StatusCode = 500;
                return Content("Falha interna ao enviar a aplicação!");
            }

            return Json(new { responseText = "Aplicação enviada com sucesso!" }, JsonRequestBehavior.AllowGet);
        }

    }
}