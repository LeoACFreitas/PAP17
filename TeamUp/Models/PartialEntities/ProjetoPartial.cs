using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamUp.Models
{
    [MetadataType(typeof(MetaData))]
    public partial class Projeto
    {

        internal class MetaData
        {
            [Required]
            public int CategoriaProjetoId { get; set; }
            
            [Required]
            [MaxLength(60)]
            public string Titulo { get; set; }

            [Required]
            [MaxLength(2000)]
            public string Descricao { get; set; }
            
        }

    }
}