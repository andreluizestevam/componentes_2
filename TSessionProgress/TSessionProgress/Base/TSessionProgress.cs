using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using AjaxControlToolkit;

namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// 
    /// </summary>
    [ToolboxData("<{0}:TSessionProgress runat=\"server\"></{0}:TSessionProgress>")]
    [ParseChildren(true)]
    [PersistChildren(true)]
    [Themeable(true)]
    public class TSessionProgress : Control, IScriptControl
    {
        #region Atributos

        /// <summary>
        /// 
        /// </summary>
        private ScriptManager sMgr;

        #endregion

        #region Propriedades

        /// <summary>
        /// 
        /// </summary>
        [PersistenceMode(PersistenceMode.Attribute)]
        [Category("Behavior")]
        [DefaultValue("Sessão expira em:")]
        public string Text
        {
            set { this.ViewState["_!Text"] = value; }
            get
            {
                if (this.ViewState["_!Text"] == null)
                {
                    this.ViewState["_!Text"] = "Sessão expira em:";
                }
                return this.ViewState["_!Text"].ToString();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [PersistenceMode(PersistenceMode.Attribute)]
        [Category("Behavior")]
        [DefaultValue("~/default.aspx")]
        [UrlProperty]
        public string RedirectUrl
        {
            set { this.ViewState["_!RedirectUrl"] = this.ResolveUrl(value); }
            get
            {
                if (this.ViewState["_!RedirectUrl"] == null)
                {
                    this.ViewState["_!RedirectUrl"] = "~/default.aspx";
                }
                return this.ViewState["_!RedirectUrl"].ToString();
            }
        }

        #endregion

        #region IScriptControl

        /// <summary>
        /// Metodo que retorna os descritores de script.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<ScriptDescriptor> GetScriptDescriptors()
        {
            // return descriptor
            return new ScriptDescriptor[] { };
        }

        /// <summary>
        /// Metodo que retorna as referencias de script.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<ScriptReference> GetScriptReferences()
        {
            List<ScriptReference> references = new List<ScriptReference>();

            references.Add(new ScriptReference()
            {
                Assembly = "Arquitetura.Web.WC.TSessionProgress",
                Name = "Arquitetura.Web.WebControls.Resources.TSessionProgress.js"
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
            Panel pnl1 = new Panel();
            pnl1.ID = "SessionProgress";
            pnl1.Attributes.Add("class", "sessionprogress_modalstyle");

            // criando conteudo
            Panel pnl2 = this.CreateBodyChildControls();

            // criando extender
            AlwaysVisibleControlExtender panelextender = new AlwaysVisibleControlExtender();
            panelextender.ID = "SessionProgressExtender";
            panelextender.TargetControlID = "SessionProgress";
            panelextender.VerticalSide = VerticalSide.Top;
            panelextender.VerticalOffset = 10;
            panelextender.HorizontalSide = HorizontalSide.Left;
            panelextender.HorizontalOffset = 10;
            panelextender.ScrollEffectDuration = 0.1f;
            panelextender.UseAnimation = true;

            // adicionando no container
            pnl1.Controls.Add(pnl2);
            pnl1.Controls.Add(panelextender);

            // adicionando na pagina
            this.Controls.Add(pnl1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private Panel CreateBodyChildControls()
        {
            Panel pnl2 = new Panel();
            pnl2.ID = "SessionProgressContent";
            pnl2.Attributes.Add("class", "sessionprogress_contentstyle");

            LiteralControl lc1 = new LiteralControl("<span class=\"sessionprogress_labelstyle\">" + this.Text + "</span>");
            LiteralControl lc2 = new LiteralControl("<br><center><span id=\"SessionProgressCounterTimer\" class=\"sessionprogress_labelstyle\"></span></center>");

            pnl2.Controls.Add(lc1);
            pnl2.Controls.Add(lc2);

            return pnl2;
        }

        /// <summary>
        /// Metodo que renderiza o componente.
        /// </summary>
        /// <param name="writer"></param>
        protected override void Render(HtmlTextWriter writer)
        {
            if (!this.DesignMode)
            {
                sMgr.RegisterScriptDescriptors(this);
            }

            base.Render(writer);
        }

        #endregion

        #region Eventos

        /// <summary>
        /// Evento onload
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            this.Page.ClientScript.RegisterHiddenField("__SESSIONTIMEOUT", this.Page.Session.Timeout.ToString());

            base.OnLoad(e);
        }

        /// <summary>
        /// Evento pre-render
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreRender(EventArgs e)
        {
            if (!this.DesignMode)
            {
                // recuperando instancia
                sMgr = ScriptManager.GetCurrent(Page);

                if (sMgr == null)
                {
                    throw new HttpException("A ScriptManager control must exist on the page.");
                }

                // registrando styles
                HtmlGenericControl l1 = new HtmlGenericControl("link");
                l1.Attributes.Add("type", "text/css");
                l1.Attributes.Add("rel", "stylesheet");
                l1.Attributes.Add("href", this.Page.ClientScript.GetWebResourceUrl(this.GetType(), "Arquitetura.Web.WebControls.Resources.TSessionProgress.css"));

                this.Page.Header.Controls.Add(l1);

                // registrando scripts
                sMgr.RegisterScriptControl(this);
            }

            base.OnPreRender(e);
        }

        #endregion
    }
}
