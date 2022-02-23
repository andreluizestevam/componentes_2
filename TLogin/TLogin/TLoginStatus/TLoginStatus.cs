using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using Arquitetura.Web.Security;
using Arquitetura.Web.WebControls.Designer;
using Arquitetura.Web.WebControls.Utils;

namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// 
    /// </summary>
    [Bindable(false)]
    [Designer(typeof(TLoginStatusDesigner))]
    public sealed class TLoginStatus : WebControl
    {
        #region Propriedades

        /// <summary>
        /// 
        /// </summary>
        [Category("Appearance")]
        [DefaultValue("Entrar")]
        public string LoginText
        {
            get
            {
                if (this.ViewState["_!LoginText"] == null)
                {
                    this.ViewState["_!LoginText"] = "Entrar";
                }
                return Convert.ToString(this.ViewState["_!LoginText"]);
            }
            set { this.ViewState["_!LoginText"] = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Appearance")]
        [UrlProperty]
        public string LoginPageUrl
        {
            get
            {
                if (this.ViewState["_!LoginPageUrl"] == null)
                {
                    if (this.Page is SecPage)
                    {
                        this.ViewState["_!LoginPageUrl"] = LoginUtil.GetLoginUrl();
                    }
                }
                return Convert.ToString(this.ViewState["_!LoginPageUrl"]);
            }
            set { this.ViewState["_!LoginPageUrl"] = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Appearance")]
        [DefaultValue("Sair")]
        public string LogoutText
        {
            get
            {
                if (this.ViewState["_!LogoutText"] == null)
                {
                    this.ViewState["_!LogoutText"] = "Sair";
                }
                return Convert.ToString(this.ViewState["_!LogoutText"]);
            }
            set { this.ViewState["_!LogoutText"] = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Appearance")]
        [UrlProperty]
        public string LogoutPageUrl
        {
            get
            {
                if (this.ViewState["_!LogoutPageUrl"] == null)
                {
                    if (this.Page is SecPage)
                    {
                        this.ViewState["_!LogoutPageUrl"] = LoginUtil.GetLogoutUrl();
                    }
                }
                return Convert.ToString(this.ViewState["_!LogoutPageUrl"]);
            }
            set { this.ViewState["_!LogoutPageUrl"] = value; }
        }

        #endregion

        #region Metodos

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreRender(EventArgs e)
        {
            LinkButton link = new LinkButton();

            if (!LoginUtil.HasAuthenticatedUser(this.Page))
            {
                link.Text = this.LoginText;
                link.PostBackUrl = this.Page.ResolveClientUrl(this.LoginPageUrl);
            }
            else
            {
                link.Text = this.LogoutText;
                link.PostBackUrl = this.Page.ResolveClientUrl(this.LogoutPageUrl);
            }

            this.Controls.Clear();
            this.Controls.Add(link);
        }

        #endregion
    }
}
