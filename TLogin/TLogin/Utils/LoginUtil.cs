using System.Security.Principal;
using System.Web;
using System.Web.UI;
using Arquitetura.Configurations;
using Arquitetura.Web.Security;
using Arquitetura.Web.Security.Configurations;

namespace Arquitetura.Web.WebControls.Utils
{
    /// <summary>
    /// 
    /// </summary>
    internal sealed class LoginUtil
    {
        #region Construtores

        /// <summary>
        /// Construto9r padrão.
        /// </summary>
        private LoginUtil()
        {
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Método que recupera a url da página de login da seção de configuração.
        /// </summary>
        /// <returns>string</returns>
        public static string GetLoginUrl()
        {
            SecurityMap map = ConfigManager.GetMap<SecurityMap>();

            if (map != null
                && map.PageSection != null)
            {
                return map.PageSection.LoginUrl;
            }

            return string.Empty;
        }

        /// <summary>
        /// Método que recupera a url da página de login da seção de configuração.
        /// </summary>
        /// <returns>string</returns>
        public static string GetLogoutUrl()
        {
            SecurityMap map = ConfigManager.GetMap<SecurityMap>();

            if (map != null
                && map.PageSection != null)
            {
                return map.PageSection.LogoutUrl;
            }

            return string.Empty;
        }

        /// <summary>
        /// Método que verifica se existe um usuário autenticado na página.
        /// </summary>
        /// <param name="page">A página a ser verificada.</param>
        /// <returns>bool</returns>
        public static bool HasAuthenticatedUser(Page page)
        {
            IPrincipal user = GetUser(page);

            return (user != null
                    && user.Identity != null
                    && user.Identity.IsAuthenticated);
        }

        /// <summary>
        /// Método que recupera o usuário registrado.
        /// </summary>
        /// <returns></returns>
        public static IPrincipal GetUser(Page page)
        {
            if (page is SecPage)
            {
                SecPage sPage = (SecPage)page;

                if (sPage.User != null)
                {
                    return sPage.User;
                }

                return (HttpContext.Current != null)
                        ? HttpContext.Current.User
                        : new GenericPrincipal(new GenericIdentity(string.Empty), null);
            }

            return (page != null)
                    ? page.User
                    : (HttpContext.Current != null)
                        ? HttpContext.Current.User
                        : new GenericPrincipal(new GenericIdentity(string.Empty), null);
        }

        /// <summary>
        /// Método que recupera o nome do usuário registrado.
        /// </summary>
        /// <returns>string</returns>
        public static string GetUserName(Page page)
        {
            IPrincipal user = GetUser(page);

            if (user != null
                && user.Identity != null)
            {
                if (user is ISecPrincipal)
                {
                    SecIdentity identity = (SecIdentity)user.Identity;

                    if (identity.User != null)
                    {
                        return (!string.IsNullOrEmpty(identity.User.FullName))
                                ? identity.User.FullName
                                : identity.Name;
                    }
                }

                return user.Identity.Name;
            }

            return string.Empty;
        }

        #endregion
    }
}
