namespace Arquitetura.Web.WebControls
{
    using System;
    using System.ComponentModel;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Arquitetura.TechBiz.Messages;

    /// <summary>
    /// Representa um botão com a capacidade de exibir uma mensagem antes de ser dado o submit.
    /// </summary>
    [ToolboxData("<{0}:TMessageImageButton runat=\"server\"></{0}:TMessageImageButton>")]
    public class TMessageImageButton : ImageButton
    {

        /// <summary>
        /// Construtor
        /// </summary>
        public TMessageImageButton()
        {
            this.BeferoSubmitMessage = string.Empty;
            this.BeferoSubmitMessageId = string.Empty;
            this.ShowMessage = true;
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
        public string BeferoSubmitMessage
        {
            get
            {
                return this.ViewState["_!BeferoSubmitMessage"].ToString();
            }
            set
            {
                this.ViewState["_!BeferoSubmitMessage"] = value;
            }
        }

        /// <summary>
        /// Define um método client-side (javascript) customizado a ser usado no controle.
        /// </summary>
        [Category("Tbiz")]
        [DefaultValue("")]
        [Description("Define o MSGID da mensagem a ser exibida antes do submite da pagina.")]
        public string BeferoSubmitMessageId
        {
            get
            {
                return this.ViewState["_!BeferoSubmitMessageId"].ToString();
            }
            set
            {
                this.ViewState["_!BeferoSubmitMessageId"] = value;
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
            if (this.ShowMessage && string.IsNullOrEmpty(this.BeferoSubmitMessageId) && string.IsNullOrEmpty(this.BeferoSubmitMessage))
            {
                throw new NotImplementedException("Você deve ou colocar o showMessage com false ou preencher o Submit ID ou Submit message");
            }

            if (this.ShowMessage)
            {
                var msg = string.IsNullOrEmpty(BeferoSubmitMessageId)
                                 ? BeferoSubmitMessage
                                 : MessageUtil.GetMessage(this.BeferoSubmitMessageId);

                string script = string.Concat("return ShowSubmitMessage('", msg, "','", this.ClientID, "');");

                this.OnClientClick = script;
            }

            base.Render(writer);
        }

    }
}
