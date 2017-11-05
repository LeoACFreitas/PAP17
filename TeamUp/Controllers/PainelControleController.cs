using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using TeamUp.Models;
using TeamUp.Repositories;
using TeamUp.ViewModels;

namespace TeamUp.Controllers
{
    public class PainelControleController : BaseController
    {

        private IProjetoRepository projetoRepository;
        private INotificacaoRepository notificacaoRepository;
        private IVagaRepository vagaRepository;


        public PainelControleController()
        {
            projetoRepository = new ProjetoRepository(context);
            notificacaoRepository = new NotificacaoRepository(context);
            vagaRepository = new VagaRepository(context);
        }


        public ActionResult Index()
        {
            PainelControleViewModel vm = new PainelControleViewModel()
            {
                Projetos = projetoRepository.SimpleWhere(p => p.UsuarioId == User.Id)
            };

            return View("PainelControleView", vm);
        }


        public ActionResult ExcluirProjeto(int Id)
        {
            try
            {
                projetoRepository.Delete(Id);
            }
            catch
            {
                //TODO: Registrar a exceção em log
                Response.StatusCode = 500;
                return Content("Não foi possível excluir o projeto por falha interna.");
            }

            return Json(new { responseText = "Projeto excluído com sucesso." }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult ConsultaAplicacoes(int Id)
        {
            List<Aplicacao> aplicacoes = projetoRepository.GetAplicacoesByProjeto(Id);

            PainelControleViewModel vm = new PainelControleViewModel() { Aplicacoes = aplicacoes };

            return View("AplicacoesView", vm);
        }


        public ActionResult RejeitarAplicacao(int vagaId, int usuarioId)
        {
            try
            {
                Aplicacao aplicacao = projetoRepository.FindAplicacao(vagaId, usuarioId);

                Notificacao notificacao = new Notificacao() {
                    UsuarioId = aplicacao.UsuarioId,
                    Mensagem = "A aplicação enviada para a vaga \"" + aplicacao.Vaga.Funcao + "\" do projeto \"" +
                                aplicacao.Vaga.Projeto.Nome + "\" foi rejeitada."
                };

                notificacaoRepository.Save(notificacao);

                projetoRepository.DeleteAplicacao(aplicacao);
            }
            catch
            {
                //TODO: Registrar a exceção em log
                Response.StatusCode = 500;
                return Content("Não foi possível rejeitar a aplicação por falha interna.");
            }

            return Json(new { responseText = "A aplicação foi rejeitada com sucesso."}, JsonRequestBehavior.AllowGet);
        }


        public ActionResult AceitarAplicacao(int vagaId, int usuarioId)
        {
            try
            {
                Aplicacao aplicacao = projetoRepository.FindAplicacao(vagaId, usuarioId);

                Vaga vaga = aplicacao.Vaga;
                vaga.UsuarioId = aplicacao.UsuarioId;

                vagaRepository.Update(vaga);

                Notificacao notificacao = new Notificacao()
                {
                    UsuarioId = aplicacao.UsuarioId,
                    Mensagem = "A aplicação enviada para a vaga \"" + aplicacao.Vaga.Funcao + "\" do projeto \"" +
                                aplicacao.Vaga.Projeto.Nome + "\" foi aceita."
                };

                notificacaoRepository.Save(notificacao);

                projetoRepository.DeleteAplicacao(aplicacao);

            }
            catch
            {
                //TODO: Registrar a exceção em log
                Response.StatusCode = 500;
                return Content("Não foi possível aceitar a aplicação por falha interna.");
            }

            return Json(new { responseText = "A aplicação foi rejeitada com sucesso." }, JsonRequestBehavior.AllowGet);
        }

    }
}