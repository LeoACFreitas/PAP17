using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamUp.Models.InternalSystem;

namespace TeamUp.Controllers
{
    public class BaseController : Controller
    {

        protected virtual new UsuarioLogado User
        {
            get { return HttpContext.User as UsuarioLogado; }
        }

    }
}