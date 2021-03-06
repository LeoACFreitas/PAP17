﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamUp.Models.InternalSystem
{
    public class UsuarioLogadoSerializable
    {
        
        public UsuarioLogadoSerializable()
        {
        }

        public UsuarioLogadoSerializable(Usuario usuario)
        {
            Id = usuario.Id;
            Email = usuario.Email;
            PrimeiroNome = usuario.PrimeiroNome;
            UltimoNome = usuario.UltimoNome;
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }

    }
}