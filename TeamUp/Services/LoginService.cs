using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;
using TeamUp.Models;
using TeamUp.Models.InternalSystem;
using TeamUp.Repositories;
using TeamUp.Util;

namespace TeamUp.Services
{
    public class LoginService : IDisposable
    {

        private TeamUpContext context;
        private IUsuarioRepository usuarioRepository;
        private bool isDisposed = false;

        public LoginService()
        {
            context = new TeamUpContext();
            usuarioRepository = new UsuarioRepository(context);
        }

        public HttpCookie AuthenticateUser(string email, string senha)
        {
            Usuario result;
            string senhaHash = GetHash(senha);

            result = usuarioRepository.SimpleWhere(u => u.Email == email && u.Senha == senhaHash).FirstOrDefault();

            if (result == null)
                throw new InternalException("Usuário inexistente ou senha inválida");

            UsuarioLogado usuarioLogado = new UsuarioLogado(result);
            UsuarioLogadoSerializable serializable = new UsuarioLogadoSerializable(result);

            string userData = new JavaScriptSerializer().Serialize(serializable);

            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                1, result.Email, DateTime.Now, DateTime.Now.AddHours(2), false, userData);

            string encTicket = FormsAuthentication.Encrypt(authTicket);

            HttpContext.Current.User = usuarioLogado;

            return new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
        }


        public static string GetHash(String entrada)
        {
            byte[] bytesHash = new byte[entrada.Length];

            for (int i = 0; i < entrada.Length; i++)
                bytesHash[i] = (byte)entrada[i];

            bytesHash = new SHA256CryptoServiceProvider().ComputeHash(bytesHash);

            var sb = new StringBuilder();
            foreach (byte b in bytesHash)
            {
                sb.Append(b.ToString("x2")); //x2 = formato hexadecimal minusculo (ff)
            }

            return sb.ToString();
        }


        public void Dispose()
        {
            if (!isDisposed)
            {
                context.Dispose();
                isDisposed = true;
            }
        }

    }
}