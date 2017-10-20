using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TeamUp.Models;

namespace TeamUp.ViewModels
{
    public class FormularioUsuarioViewModel
    {

        public Usuario Usuario { get; set; }

        public HttpPostedFile ImagemPerfil { get; set; }

    }
}