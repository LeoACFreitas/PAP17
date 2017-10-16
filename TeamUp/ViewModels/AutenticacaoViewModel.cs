using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamUp.ViewModels
{
    public class AutenticacaoViewModel
    {

        [Required]
        [EmailAddress]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(30, MinimumLength=6)]
        public string Senha { get; set; }

    }
}