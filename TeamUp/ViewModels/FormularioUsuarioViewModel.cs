using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TeamUp.CustomValidations;
using TeamUp.Models;

namespace TeamUp.ViewModels
{
    public class FormularioUsuarioViewModel
    {

        public enum Modo { Cadastro, Alteracao}

        public Modo ModoValor { get; set; }

        public Usuario Usuario { get; set; }

        [ImageValidation]
        public HttpPostedFileBase ImagemPerfil { get; set; }

        public String VerificacaoSenhaAlteracao { get; set; }
        

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