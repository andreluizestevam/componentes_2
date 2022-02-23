using System;
using System.ComponentModel;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Arquitetura.Web.WebControls.Designer;
using Arquitetura.Web.WebControls.Utils;

namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// 
    /// </summary>
    [Bindable(false)]
    [Designer(typeof(TLoginNameDesigner))]
    [DefaultProperty("FormatString")]
    public sealed class TLoginName : WebControl
    {
        #region Propriedades

        /// <summary>
        /// Propriedade que define o formato adotado para exibição do nome do usuário.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue("{0}")]
        [Localizable(true)]
        public string FormatString
        {
            get
            {
                if (this.ViewState["FormatString"] == null)
                {
                    this.ViewState["FormatString"] = "{0}";
                }
                return Convert.ToString(this.ViewState["FormatString"]);
            }
            set { this.ViewState["FormatString"] = value; }
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Método de renderização
        /// </summary>
        /// <param name="writer">O renderizador html.</param>
        protected override void Render(HtmlTextWriter writer)
        {
            if (!string.IsNullOrEmpty(LoginUtil.GetUserName(this.Page)))
            {
                base.Render(writer);
            }
        }

        /// <summary>
        /// Método de renderização
        /// </summary>
        /// <param name="writer">O renderizador html.</param>
        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            if (!string.IsNullOrEmpty(LoginUtil.GetUserName(this.Page)))
            {
                base.RenderBeginTag(writer);
            }
        }

        /// <summary>
        /// Método de renderização
        /// </summary>
        /// <param name="writer">O renderizador html.</param>
        protected override void RenderContents(HtmlTextWriter writer)
        {
            string userName = LoginUtil.GetUserName(this.Page);

            if (!string.IsNullOrEmpty(userName))
            {
                userName = HttpUtility.HtmlEncode(userName);

                string formatString = this.FormatString;

                if (formatString.Length == 0)
                {
                    writer.Write(userName);
                }
                else
                {
                    try
                    {
                        writer.Write(string.Format(CultureInfo.CurrentCulture, formatString, new object[] { userName }));
                    }
                    catch (FormatException ex)
                    {
                        throw new FormatException("O formato de login é inválido.", ex);
                    }
                }
            }
        }

        /// <summary>
        /// Método de renderização
        /// </summary>
        /// <param name="writer">O renderizador html.</param>
        public override void RenderEndTag(HtmlTextWriter writer)
        {
            if (!string.IsNullOrEmpty(LoginUtil.GetUserName(this.Page)))
            {
                base.RenderEndTag(writer);
            }
        }

        #endregion
    }
}
