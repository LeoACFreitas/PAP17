using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamUp.Models
{
    [MetadataType(typeof(Usuario.MetaData))]
    public partial class Usuario
    {

        [Compare(nameof(Senha))]
        public String SenhaConfirmacao { get; set; }


        internal class MetaData
        {
            [Required]
            [StringLength(maximumLength: 50)]
            [EmailAddress]
            public String Email { get; set; }

            [Required]
            [StringLength(maximumLength: 30, MinimumLength = 6)]
            public String Senha { get; set; }

            [Required]
            [StringLength(maximumLength: 25)]
            public String PrimeiroNome { get; set; }

            [Required]
            [StringLength(maximumLength: 25)]
            public String UltimoNome { get; set; }
        }

    }
}