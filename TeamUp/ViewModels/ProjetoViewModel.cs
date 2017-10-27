using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TeamUp.Models;

namespace TeamUp.ViewModels
{
    public class ProjetoViewModel
    {

        public Projeto Projeto { get; set; }

        public Aplicacao Aplicacao { get; set; }

    }
}