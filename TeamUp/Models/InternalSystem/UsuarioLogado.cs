using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Principal;
using System.Web;
using TeamUp.Repositories;

namespace TeamUp.Models.InternalSystem
{
    public class UsuarioLogado : UsuarioLogadoSerializable, IPrincipal
    {

        public UsuarioLogado(UsuarioLogadoSerializable usuario)
        {
            Identity = new GenericIdentity(usuario.Email);

            Id = usuario.Id;
            Email = usuario.Email;
            PrimeiroNome = usuario.PrimeiroNome;
            UltimoNome = usuario.UltimoNome;
        }

        public UsuarioLogado(Usuario usuario) : base(usuario)
        {
            Identity = new GenericIdentity(usuario.Email);
        }

        public IIdentity Identity { get; private set; }
        public bool IsInRole(string role) { return false; } //Não utilizado
        
    }
}