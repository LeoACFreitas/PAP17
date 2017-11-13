using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamUp.Models
{
    [MetadataType(typeof(Usuario.MetaData))]
    public partial class Usuario : IEntity
    {

        public string NomeCompleto { get { return PrimeiroNome + " " + UltimoNome; } }

        internal class MetaData
        {
            [Required]
            [StringLength(maximumLength: 50)]
            [EmailAddress]
            [Display(Name = "E-mail")]
            public String Email { get; set; }

            [Required]
            [StringLength(maximumLength: 64, MinimumLength = 6)]
            public String Senha { get; set; }

            [Required]
            [StringLength(maximumLength: 25)]
            [Display(Name = "Primeiro nome")]
            public String PrimeiroNome { get; set; }

            [Required]
            [StringLength(maximumLength: 25)]
            [Display(Name = "Ultimo nome")]
            public String UltimoNome { get; set; }
            
            [StringLength(maximumLength: 500)]
            [Display(Name = "Descrição pessoal")]
            public String DescricaoPessoal { get; set; }
        }

    }
}