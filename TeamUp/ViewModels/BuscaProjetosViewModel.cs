using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TeamUp.Models;

namespace TeamUp.ViewModels
{
    public class BuscaProjetosViewModel
    {

        public List<CategoriaProjeto> Categorias { get; set; } = new List<CategoriaProjeto>();

        public IPagedList<Projeto> Projetos { get; set; }

        [Display(Name = "Categoria")]
        public int IdCategoriaSelecionada { get; set; }

        [Display(Name = "Título do projeto")]
        public string TituloProjetoBusca { get; set; }

        [Display(Name = "Vaga")]
        public string VagaBusca { get; set; }

        public int Pagina { get; set; } = 1;

    }
}