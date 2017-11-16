using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TeamUp.CustomValidations;

namespace TeamUp.Models
{

    public enum DisponibilidadeVaga { Disponivel, AplicacaoEnviada, OcupandoEla, VagaOcupada }

    [MetadataType(typeof(MetaData))]
    public partial class Vaga : IEntity
    {

        public DisponibilidadeVaga Disponibilidade { get; set; }

        internal class MetaData
        {

            [Display(Name = "Função")]
            [StringLength(maximumLength: 40)]
            public string Funcao { get; set; }

            [StringLength(maximumLength: 300)]
            [ConditionalFill("Funcao")]
            [Display(Name = "Descrição")]
            public string Descricao { get; set; }

        }

    }
}