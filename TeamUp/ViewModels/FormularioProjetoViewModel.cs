using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TeamUp.Models;

namespace TeamUp.ViewModels
{
    public class FormularioProjetoViewModel
    {
                
        public Projeto Projeto { get; set; }

        public HttpPostedFile ImagemCapa { get; set; }
        
        public HttpPostedFile ImagemLogo { get; set; }
        
        public List<Vaga> Vagas { get; set; }

        public List<CategoriaProjeto> Categorias { get; set; } = new List<CategoriaProjeto>();

        [Required]
        public int IdCategoriaSelecionada { get; set; }

    }
}