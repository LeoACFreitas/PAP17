using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;
using TeamUp.Models;
using TeamUp.Util;

namespace TeamUp.Services
{
    public class LoginService
    {


        public static HttpCookie AuthenticateUser(string email, string senha)
        {
            Usuario result;
            string senhaHash = GetHash(senha);

            using (TeamUpContext context = new TeamUpContext())            
                result = context.usuario.Where(u => u.Email == email && u.Senha == senhaHash).FirstOrDefault();

            if (result == null)
                throw new InternalException("Usuário inexistente ou senha inválida");            

            string userData = new JavaScriptSerializer().Serialize(result);

            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                1, result.Email, DateTime.Now, DateTime.Now.AddHours(2), false, userData);

            string encTicket = FormsAuthentication.Encrypt(authTicket);

            HttpContext.Current.User = result;

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


    }
}