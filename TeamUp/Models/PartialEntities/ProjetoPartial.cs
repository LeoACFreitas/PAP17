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
            [Display(Name = "Sobre o Projeto")]
            public string Sobre { get; set; }

            [Required]
            [MaxLength(50)]
            [Display(Name = "Descrição")]
            public string Descricao { get; set; }

        }

    }
}