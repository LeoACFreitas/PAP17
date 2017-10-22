using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamUp.Models;

namespace TeamUp.ViewModels
{
    public class BuscaProjetosViewModel
    {

        public List<CategoriaProjeto> Categorias { get; set; } = new List<CategoriaProjeto>();

        public IPagedList<Projeto> Projetos { get; set; }

        public int IdCategoriaSelecionada { get; set; }

        public string TituloProjetoBusca { get; set; }

        public string VagaBusca { get; set; }

        public int Pagina { get; set; } = 1;

    }
}