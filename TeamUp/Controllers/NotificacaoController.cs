using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamUp.Models;
using TeamUp.Repositories;

namespace TeamUp.Controllers
{
    public class NotificacaoController : BaseController
    {

        private INotificacaoRepository notificacaoRepository;

        public NotificacaoController()
        {
            notificacaoRepository = new NotificacaoRepository(context);
        }


        public ActionResult Index()
        {

            List<Notificacao> list = notificacaoRepository.SimpleWhere(n => n.UsuarioId == User.Id);

            return View("NotificacaoView", list);
        }


        public ActionResult ExcluirNotificacao(int id)
        {
            try
            {
                notificacaoRepository.Delete(id);
            }
            catch
            {
                //TODO: Registrar exceção em log
                Response.StatusCode = 500;
                return Content("Não foi possível excluir a notificação por falha interna.");
            }
            
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

    }
}