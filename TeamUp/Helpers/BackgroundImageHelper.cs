using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeamUp
{

    public enum ImageType { ProjetoCapa, ProjetoLogo, UsuarioPerfil }

    public static class BackgroundImageHelper
    {
        
        /// <summary>
        /// Retorna a propriedade CSS de imagem de fundo para divs (deve ser colocada dentro de um style="")
        /// </summary>
        /// <param name="id">id da imagem</param>
        /// <param name="iType">tipo de imagem</param>
        /// <returns></returns>
        public static string BackgroundImage(this HtmlHelper helper, int id, ImageType iType){
            string propriedade = "background-image:url('";
            propriedade += UrlHelper.GenerateContentUrl("~/UserInputedFiles/" + iType.ToString() + "/"
                                            + id.ToString() + ".jpg?" + DateTime.Now.Millisecond, helper.ViewContext.HttpContext);
            propriedade += "')";

            return propriedade;
        }
    }

    /* TODO: colocar imagens default
    private static string capaProjetoDefault = "~/res/img/defaultCapa.png?";
    private static string logoProjetoDefault = "~/res/img/defaultLogo.png?";
    private static string perfilUsuarioDefault = "~/res/img/funcao.png?";

    /// <summary>
    /// Retorna a propriedade CSS de imagem de fundo para divs (deve ser colocada dentro de um style="")
    /// </summary>
    /// <param name="id">id da imagem</param>
    /// <param name="iType">tipo de imagem</param>
    /// <returns></returns>
    public static string BackgroundImage(this HtmlHelper helper, int id, ImageType iType)
    {
        string caminho = UrlHelper.GenerateContentUrl("~/UserInputedFiles/" + iType.ToString() + "/"
                                        + id.ToString() + ".jpg?" + DateTime.Now.Millisecond, helper.ViewContext.HttpContext);

        string retorno = "background-image:url('" + caminho + "')";




        return retorno;
    }*/
}