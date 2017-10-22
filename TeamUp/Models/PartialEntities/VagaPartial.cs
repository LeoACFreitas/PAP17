using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TeamUp.CustomValidations;

namespace TeamUp.Models
{
    [MetadataType(typeof(MetaData))]
    public partial class Vaga : IEntity
    {

        internal class MetaData
        {

            [StringLength(maximumLength: 40)]
            public string Funcao { get; set; }

            [StringLength(maximumLength: 300)]
            [ConditionalFill("Funcao")]
            public string Descricao { get; set; }

        }

    }
}