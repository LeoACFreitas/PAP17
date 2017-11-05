using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamUp.Models
{

    [MetadataType(typeof(MetaData))]
    public partial class Projeto : IEntity
    {

        internal class MetaData
        {
            [Required]
            public int CategoriaProjetoId { get; set; }
            
            [Required]
            [MaxLength(40)]
            public string Nome { get; set; }

            [Required]
            [MaxLength(2000)]
            public string Sobre { get; set; }

            [Required]
            [MaxLength(50)]
            public string Descricao { get; set; }

        }

    }
}