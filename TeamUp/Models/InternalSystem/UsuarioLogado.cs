using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Principal;
using System.Web;

namespace TeamUp.Models.InternalSystem
{
    public class UsuarioLogado : IPrincipal
    {
        public IIdentity Identity { get; private set; }
        public bool IsInRole(string role) { return false; } //Não utilizado

        public string Nome { get; set; }
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string ClienteNome { get; set; }
        public string ClienteCod { get; set; }
        public string IpLogin { get; set; }
        public bool HasRegistros { get; set; }

        /*public UsuarioLogado(string login, UserSerializeModel serializeModel)
        {
            Identity = new GenericIdentity(login);

            Nome = serializeModel.Nome;
            Id = serializeModel.Id;
            ClienteId = serializeModel.ClienteId;
            ClienteNome = serializeModel.ClienteNome;
            ClienteCod = serializeModel.ClienteCod;
            IpLogin = serializeModel.IpLogin;
            HasRegistros = serializeModel.HasRegistros;
        }*/

        /*public Usuario GetEntity()
        {
            using (UsuarioRepository repo = new UsuarioRepository())
                return repo.FindUsuarioById(Id);
        }*/

    }
}