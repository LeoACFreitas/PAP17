using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamUp.Models
{
    [MetadataType(typeof(MetaData))]
    public partial class Aplicacao
    {

        internal class MetaData
        {
            [MaxLength(300)]
            public string Mensagem { get; set; }
        }

    }
}