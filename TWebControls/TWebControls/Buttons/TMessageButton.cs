namespace Arquitetura.Web.WebControls
{
    using System;
    using System.ComponentModel;
    using System.Web.UI;
    using Arquitetura.TechBiz.Messages;

    /// <summary>
    /// Representa um botão com a capacidade de exibir uma mensagem antes de ser dado o submit.
    /// </summary>
    [ToolboxData("<{0}:TMessageButton runat=\"server\"></{0}:TMessageButton>")]
    public class TMessageButton : TButton
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public TMessageButton()
        {
            this.BeforeSubmitMessage = string.Empty;
            this.BeforeSubmitMessageId = string.Empty;
            this.UseGoBackBehavior = false;
            this.ShowMessage = false;
            this.RedirectPageName = string.Empty;
            this.UseSubmitBehavior = false;
        }

        /// <summary>
        /// Informa se será exibida a mensagem.
        /// </summary>
        [Category("Tbiz")]
        [NotifyParentProperty(true), PersistenceMode(PersistenceMode.Attribute)]
        [DefaultValue(true)]
        [Description("Informa se será exibida a mensagem.")]
        public bool ShowMessage
        {
            get
            {
                return Convert.ToBoolean(this.ViewState["_!ShowMessage"].ToString());
            }
            set
            {
                this.ViewState["_!ShowMessage"] = value;
            }
        }

        /// <summary>
        /// Define um método client-side (javascript) customizado a ser usado no controle.
        /// </summary>
        [Category("Tbiz")]
        [DefaultValue("")]
        [Description("Define a mensagem a ser exibida antes do submite da pagina.")]
        public string BeforeSubmitMessage
        {
            get
            {
                return this.ViewState["_!BeforeSubmitMessage"].ToString();
            }
            set
            {
                this.ViewState["_!BeforeSubmitMessage"] = value;
            }
        }

        /// <summary>
        /// Define um método client-side (javascript) customizado a ser usado no controle.
        /// </summary>
        [Category("Tbiz")]
        [DefaultValue("")]
        [Description("Define o MSGID da mensagem a ser exibida antes do submite da pagina.")]
        public string BeforeSubmitMessageId
        {
            get
            {
                return this.ViewState["_!BeforeSubmitMessageId"].ToString();
            }
            set
            {
                this.ViewState["_!BeforeSubmitMessageId"] = value;
            }
        }

        /// <summary>
        /// Define um método client-side (javascript) customizado a ser usado no controle.
        /// </summary>
        [Category("Tbiz")]
        [DefaultValue("")]
        [Description("Define o nome da pagina para onde o sistema será redirecionado caso o usuário clique em sim.")]
        public string RedirectPageName
        {
            get
            {
                return this.ViewState["_!RedirectPageName"].ToString();
            }
            set
            {
                this.ViewState["_!RedirectPageName"] = value;
            }
        }

        /// <summary>
        /// Define um método client-side (javascript) customizado a ser usado no controle.
        /// </summary>
        [Category("Tbiz")]
        [DefaultValue("")]
        [Description("Define se o browser irá voltar para a página anterior.")]
        public bool UseGoBackBehavior
        {
            get
            {
                return Convert.ToBoolean(this.ViewState["_!UseGoBackBehavior"]);
            }
            set
            {
                this.ViewState["_!UseGoBackBehavior"] = value;
            }
        }

        /// <summary>
        /// Método ao incializar a página para registrar os scripts e css
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            ControlUtils.RegisterStaticFiles(this.GetType(), this.Page);

            base.OnInit(e);
        }

        /// <summary>
        /// Renderiza o componente.
        /// </summary>
        /// <param name="writer">O escritor HTML.</param>
        protected override void Render(HtmlTextWriter writer)
        {
            if (this.ShowMessage && string.IsNullOrEmpty(this.BeforeSubmitMessageId) && string.IsNullOrEmpty(this.BeforeSubmitMessage))
            {
                throw new NotImplementedException(String.Concat("Você deve ou colocar o showMessage com false ou preencher o Submit ID ou Submit message", this.ID));
            }

            string cssClass = string.Empty;

            if (this.ShowMessage)
            {
                cssClass = "btnSubmitMessage";

                var msg = string.IsNullOrEmpty(this.BeforeSubmitMessageId)
                                 ? this.BeforeSubmitMessage
                                 : MessageUtil.GetMessage(this.BeforeSubmitMessageId);

                if (UseGoBackBehavior)
                {
                    this.OnClientClick = "javascript:return;";
                    cssClass = "btnGoBackMessage";
                }
                else if (!string.IsNullOrEmpty(RedirectPageName))
                {
                    this.OnClientClick = "javascript:return;";
                    cssClass = "btnRedirectMessage";
                    this.Attributes.Add("tbiz-rdtPg", this.RedirectPageName);
                }
                else
                {
                    this.UseSubmitBehavior = true;
                }

                this.Attributes.Add("tbiz-msg", msg);
            }
            else if (this.UseGoBackBehavior)
            {
                this.OnClientClick = "javascript:return Voltar();";
            }
            else if (!string.IsNullOrEmpty(this.RedirectPageName))
            {
                this.OnClientClick = string.Concat("javascript:return Redirecionar('", this.RedirectPageName, "');");
            }

            this.CssClass = string.IsNullOrEmpty(this.CssClass) ? cssClass : string.Concat(this.CssClass, " ", cssClass);

            base.Render(writer);
        }
    }
}
