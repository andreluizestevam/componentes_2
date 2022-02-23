using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [Serializable]
    public class TDownloadCommand : HyperLink
    {
        /// <summary>
        /// Parametro que será passado para o metodo de download
        /// </summary>
        public object Parameters
        {
            get
            {
                if (this.ViewState["dataItemNames"] == null)
                {
                    return null;
                }

                return this.ViewState["dataItemNames"];
            }
            set
            {
                this.ViewState["dataItemNames"] = value;
            }
        }

        public string WebMethod
        {
            get
            {
                if (this.ViewState["WebMethod"] == null)
                {
                    return string.Empty;
                }

                return (string)this.ViewState["WebMethod"];
            }
            set
            {
                this.ViewState["WebMethod"] = value;
            }
        }

        
        public TDownloadCommand()
        {
            this.NavigateUrl ="http://www.uol.com.br";
        }
        
        protected override void AddAttributesToRender(System.Web.UI.HtmlTextWriter writer)
        {
            base.AddAttributesToRender(writer);
            
            if (this.Parameters != null)
            {
                writer.AddAttribute("parameters", Newtonsoft.Json.JsonConvert.SerializeObject(Parameters));
            }
        }
    }
}