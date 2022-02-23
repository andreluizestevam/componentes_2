using System;
using System.Web;
using System.Web.UI;

namespace Arquitetura.Web.WebControls.Modules
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class TFileUploadModule : IHttpModule
    {
        /// <summary>
        /// Método que inicializa o módulo.
        /// </summary>
        /// <param name="context">O contexto do módulo.</param>
        public void Init(HttpApplication application)
        {
            application.PreRequestHandlerExecute += new EventHandler(application_PreRequestHandlerExecute);
            application.PostRequestHandlerExecute += new EventHandler(application_PostRequestHandlerExecute);
        }

        /// <summary>
        /// Método que captura o evento PostRequestHandlerExecute do HttpApplication.
        /// </summary>
        /// <param name="sender">O objeto chamador.</param>
        /// <param name="e">O evento chamador.</param>
        private void application_PostRequestHandlerExecute(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;

            if (!(application.Context.Handler is Page))
            {
                return;
            }

            Page page = application.Context.Handler as Page;

            try
            {
                if (page.Cache[TFileUploadStrategy.STRATEGY_PAGE_ID] != null)
                {
                    if (!string.Equals(page.Cache[TFileUploadStrategy.STRATEGY_PAGE_ID].ToString(), page.AppRelativeVirtualPath, StringComparison.InvariantCultureIgnoreCase))
                    {
                        page.Cache.Remove(TFileUploadStrategy.STRATEGY_PAGE_ID);
                        page.Cache.Remove(TFileUploadStrategy.STRATEGY_FILE_ID);
                    }
                }
            }
            catch { }
        }

        /// <summary>
        /// Método que captura o evento PreRequestHandlerExecute do HttpApplication.
        /// </summary>
        /// <param name="sender">O objeto chamador.</param>
        /// <param name="e">O evento chamador.</param>
        private void application_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;

            if (!(application.Context.Handler is Page))
            {
                return;
            }

            Page page = application.Context.Handler as Page;

            try
            {
                if (page.Session[TFileUploadStrategy.STRATEGY_PAGE_ID] != null)
                {
                    if (!string.Equals(page.Session[TFileUploadStrategy.STRATEGY_PAGE_ID].ToString(), page.AppRelativeVirtualPath, StringComparison.InvariantCultureIgnoreCase))
                    {
                        page.Session.Remove(TFileUploadStrategy.STRATEGY_PAGE_ID);
                        page.Session.Remove(TFileUploadStrategy.STRATEGY_FILE_ID);
                    }
                }
            }
            catch { }
        }

        /// <summary>
        /// Método que libera os recursos do módulo.
        /// </summary>
        public void Dispose()
        {
        }
    }
}
