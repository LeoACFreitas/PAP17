using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TeamUp.CustomValidations;
using TeamUp.Models;

namespace TeamUp.ViewModels
{
    public class FormularioProjetoViewModel
    {

        public enum Modo { Cadastro, Alteracao }

        public Modo ModoValor { get; set; }

        public Projeto Projeto { get; set; }

        [ImageValidation]
        public HttpPostedFileBase ImagemCapa { get; set; }

        [ImageValidation]
        public HttpPostedFileBase ImagemLogo { get; set; }
        
        public List<Vaga> Vagas { get; set; }

        public List<CategoriaProjeto> Categorias { get; set; } = new List<CategoriaProjeto>();

        [Required]
        public int IdCategoriaSelecionada { get; set; }


        public String GetModo()
        {
            switch (ModoValor)
            {
                case Modo.Cadastro:
                    return "Cadastro";
                case Modo.Alteracao:
                    return "Alteração";
            }

            return "";
        }
    }
}