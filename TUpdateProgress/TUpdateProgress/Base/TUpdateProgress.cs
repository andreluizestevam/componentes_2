using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// Componente customizado para UpdateProgress.
    /// </summary>
    [ToolboxData("<{0}:TUpdateProgress runat=\"server\"></{0}:TUpdateProgress>")]
    [ParseChildren(true)]
    [PersistChildren(true)]
    [Themeable(true)]
    public class TUpdateProgress : Control, IScriptControl
    {
        #region Atributos

        /// <summary>
        /// Atributo com o scriptmanager
        /// </summary>
        private ScriptManager sMgr;

        #endregion

        #region Propriedades

        /// <summary>
        /// Propriedade que descreve o texto de processamento.
        /// </summary>
        [PersistenceMode(PersistenceMode.Attribute)]
        [Category("Behavior")]
        [DefaultValue("Processando...")]
        public string ProcessText
        {
            get
            {
                if (this.ViewState["_!ProcessText"] == null)
                {
                    this.ViewState["_!ProcessText"] = "Processando...";
                }
                return this.ViewState["_!ProcessText"].ToString();
            }
            set { this.ViewState["_!ProcessText"] = value; }
        }

        /// <summary>
        /// Propriedade que descreve a url da imagem de processamento.
        /// </summary>
        [PersistenceMode(PersistenceMode.Attribute)]
        [Category("Behavior")]
        [UrlProperty]
        public string ProcessImageUrl
        {
            get
            {
                if (this.ViewState["_!ProcessImageUrl"] == null)
                {
                    this.ViewState["_!ProcessImageUrl"] = this.Page.ClientScript.GetWebResourceUrl(this.GetType(), "Arquitetura.Web.WebControls.Resources.TUpdateProgress.gif");
                }
                return this.ViewState["_!ProcessImageUrl"].ToString();
            }
            set { this.ViewState["_!ProcessImageUrl"] = this.ResolveUrl(value); }
        }

        /// <summary>
        /// Propriedade que descreve a opção para (des)habilitar a exibição do tempo de processamento.
        /// </summary>
        [PersistenceMode(PersistenceMode.Attribute)]
        [Category("Behavior")]
        [DefaultValue(false)]
        public bool ShowCounterTimer
        {
            get
            {
                if (this.ViewState["_!ShowCounterTimer"] == null)
                {
                    this.ViewState["_!ShowCounterTimer"] = false;
                }
                return (bool)this.ViewState["_!ShowCounterTimer"];
            }
            set { this.ViewState["_!ShowCounterTimer"] = value; }
        }

        /// <summary>
        /// Propriedade que descreve o conteúdo customizado de processamento.
        /// </summary>
        [Browsable(false)]
        [DefaultValue(null)]
        [TemplateContainer(typeof(TUpdateProgressTemplate))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TemplateInstance(TemplateInstance.Single)]
        public ITemplate ProgressTemplate { get; set; }

        #endregion

        #region IScriptControl

        /// <summary>
        /// Metodo que retorna os descritores de script.
        /// </summary>
        /// <returns>IEnumerable</returns>
        public virtual IEnumerable<ScriptDescriptor> GetScriptDescriptors()
        {
            // return descriptor
            return new ScriptDescriptor[] { };
        }

        /// <summary>
        /// Metodo que retorna as referencias de script.
        /// </summary>
        /// <returns>IEnumerable</returns>
        public virtual IEnumerable<ScriptReference> GetScriptReferences()
        {
            List<ScriptReference> references = new List<ScriptReference>();

            references.Add(new ScriptReference()
            {
                Assembly = "Arquitetura.Web.WC.TUpdateProgress",
                Name = "Arquitetura.Web.WebControls.Resources.JQuery.Pack.js"
            });

            references.Add(new ScriptReference()
            {
                Assembly = "Arquitetura.Web.WC.TUpdateProgress",
                Name = "Arquitetura.Web.WebControls.Resources.TUpdateProgress.js"
            });

            return references.ToArray();
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Método que cria os controles filhos
        /// </summary>
        protected override void CreateChildControls()
        {
            Panel pnlMain = new Panel();
            pnlMain.ID = "UpdateProgress";
            pnlMain.Attributes.Add("class", "updateprogress_mainstyle");

            // adicionando conteudo
            pnlMain.Controls.Add(this.CreateContent());

            // adicionando modal
            pnlMain.Controls.Add(this.CreateModal());

            // adicionando na pagina
            this.Controls.Add(pnlMain);
        }

        /// <summary>
        /// Método que cris os controles de conteúdo
        /// </summary>
        /// <returns>Panel</returns>
        private Panel CreateContent()
        {
            Panel pnlContent = new Panel();
            pnlContent.ID = "UpdateProgressContent";
            pnlContent.Attributes.Add("class", "updateprogress_contentstyle");

            if (this.ProgressTemplate != null)
            {
                TUpdateProgressTemplate contentTemplate = new TUpdateProgressTemplate();

                this.ProgressTemplate.InstantiateIn(contentTemplate);

                pnlContent.Controls.Add(contentTemplate);
            }
            else
            {
                LiteralControl lc1 = new LiteralControl("<img src=\"" + this.ProcessImageUrl + "\" class=\"updateprogress_imagestyle\" alt=\"" + this.ProcessText + "\" />");
                LiteralControl lc2 = new LiteralControl("<span class=\"updateprogress_labelstyle\">" + this.ProcessText + "</span>");

                pnlContent.Controls.Add(lc1);
                pnlContent.Controls.Add(lc2);
            }

            if (this.ShowCounterTimer)
            {
                LiteralControl lc3 = new LiteralControl("<br/><center><span id=\"UpdateProgressCounterTimer\" class=\"updateprogress_labelstyle\"></span></center>");
                pnlContent.Controls.Add(lc3);
            }

            return pnlContent;
        }

        /// <summary>
        /// Método que cris os controles do modal popup
        /// </summary>
        /// <returns>Panel</returns>
        private Panel CreateModal()
        {
            Panel pnlModal = new Panel();
            pnlModal.ID = "UpdateProgressModal";
            pnlModal.Attributes.Add("class", "updateprogress_modalstyle");

            return pnlModal;
        }

        /// <summary>
        /// Metodo que renderiza o componente.
        /// </summary>
        /// <param name="writer">Escritor</param>
        protected override void Render(HtmlTextWriter writer)
        {
            if (!this.DesignMode)
            {
                this.sMgr.RegisterScriptDescriptors(this);
            }

            base.Render(writer);
        }

        #endregion

        #region Eventos

        /// <summary>
        /// Evento pre-render
        /// </summary>
        /// <param name="e">O evento.</param>
        protected override void OnPreRender(EventArgs e)
        {
            if (!this.DesignMode)
            {
                // recuperando instancia
                this.sMgr = ScriptManager.GetCurrent(Page);

                if (this.sMgr == null)
                {
                    throw new HttpException("A ScriptManager control must exist on the page.");
                }

                // registrando styles
                HtmlGenericControl l1 = new HtmlGenericControl("link");
                l1.Attributes.Add("type", "text/css");
                l1.Attributes.Add("rel", "stylesheet");
                l1.Attributes.Add("href", this.Page.ClientScript.GetWebResourceUrl(this.GetType(), "Arquitetura.Web.WebControls.Resources.TUpdateProgress.css"));

                this.Page.Header.Controls.Add(l1);

                // registrando scripts
                this.sMgr.RegisterScriptControl(this);
            }

            base.OnPreRender(e);
        }

        #endregion
    }
}
