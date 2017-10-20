using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamUp.Models.PartialEntities
{
    [MetadataType(typeof(MetaData))]
    public class VagaPartial
    {

        internal class MetaData
        {
            [MaxLength(40)]
            public string Funcao { get; set; }

            [MaxLength(300)]
            public string Descricao { get; set; }

        }

    }
}