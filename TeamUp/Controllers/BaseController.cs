using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamUp.Models;
using TeamUp.Models.InternalSystem;

namespace TeamUp.Controllers
{
    public abstract class BaseController : Controller
    {

        protected TeamUpContext context;

        public BaseController()
        {
            //Organizado dessa maneira para facilitar o eventual uso de dependency injection
            context = new TeamUpContext();
        }

        protected virtual new UsuarioLogado User
        {
            get { return HttpContext.User as UsuarioLogado; }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }

            base.Dispose(disposing);
        }

    }
}