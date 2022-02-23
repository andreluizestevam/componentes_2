using System;
using System.ComponentModel;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using Arquitetura.TechBiz.Web.Utils;
using Arquitetura.Web.WebControls.Design;

namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// 
    /// </summary>
    [ParseChildren(true)]
    [PersistChildren(true)]
    [Designer(typeof(TPopupDesigner))]
    [Themeable(true)]
    public abstract class TPopup : Control, INamingContainer
    {
        #region Atributos

        /// <summary>
        /// 
        /// </summary>
        private bool isPropertyChanged = false;

        /// <summary>
        /// 
        /// </summary>
        private bool isCreateChildControls = false;

        #endregion

        #region Propriedades

        /// <summary>
        /// 
        /// </summary>
        [Category("Appearance")]
        [DefaultValue("Caixa Modal")]
        public virtual string Title
        {
            get
            {
                if (this.ViewState["_!Title"] == null)
                {
                    this.ViewState["_!Title"] = "Caixa Modal";
                }

                return Convert.ToString(this.ViewState["_!Title"]);
            }
            set { this.ViewState["_!Title"] = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Behavior")]
        [DefaultValue("ButtonOk")]
        protected virtual string DefaultButtonID
        {
            get
            {
                if (this.ViewState["_!DefaultButtonID"] == null)
                {
                    this.ViewState["_!DefaultButtonID"] = string.Concat(this.ID, "_ButtonOk");
                }

                return Convert.ToString(this.ViewState["_!DefaultButtonID"]);
            }
            set { this.ViewState["_!DefaultButtonID"] = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Behavior")]
        [DefaultValue(true)]
        public virtual bool Closable
        {
            get
            {
                if (this.ViewState["_!Closable"] == null)
                {
                    this.ViewState["_!Closable"] = true;
                }
                return Convert.ToBoolean(this.ViewState["_!Closable"]);
            }
            set { this.ViewState["_!Closable"] = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Behavior")]
        [DefaultValue(true)]
        public virtual bool Scrollable
        {
            get
            {
                if (this.ViewState["_!Scrollable"] == null)
                {
                    this.ViewState["_!Scrollable"] = true;
                }
                return Convert.ToBoolean(this.ViewState["_!Scrollable"]);
            }
            set { this.ViewState["_!Scrollable"] = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Behavior")]
        [DefaultValue(true)]
        public virtual bool ShowHeader
        {
            get
            {
                if (this.ViewState["_!ShowHeader"] == null)
                {
                    this.ViewState["_!ShowHeader"] = true;
                }
                return Convert.ToBoolean(this.ViewState["_!ShowHeader"]);
            }
            set { this.ViewState["_!ShowHeader"] = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Behavior")]
        [DefaultValue(true)]
        public virtual bool ShowFooter
        {
            get
            {
                if (this.ViewState["_!ShowFooter"] == null)
                {
                    this.ViewState["_!ShowFooter"] = true;
                }
                return Convert.ToBoolean(this.ViewState["_!ShowFooter"]);
            }
            set { this.ViewState["_!ShowFooter"] = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Layout")]
        [DefaultValue("300px")]
        public virtual int Width
        {
            get
            {
                if (this.ViewState["_!Width"] == null)
                {
                    this.ViewState["_!Width"] = 300;
                }
                return Convert.ToInt32(this.ViewState["_!Width"]);
            }
            set { this.ViewState["_!Width"] = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Layout")]
        [DefaultValue("150px")]
        public virtual int Height
        {
            get
            {
                if (this.ViewState["_!Height"] == null)
                {
                    this.ViewState["_!Height"] = 150;
                }
                return Convert.ToInt32(this.ViewState["_!Height"]);
            }
            set { this.ViewState["_!Height"] = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Layout")]
        [DefaultValue(-1)]
        public virtual int Top
        {
            get
            {
                if (this.ViewState["_!Top"] == null)
                {
                    this.ViewState["_!Top"] = -1;
                }
                return Convert.ToInt32(this.ViewState["_!Top"]);
            }
            set { this.ViewState["_!Top"] = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Layout")]
        [DefaultValue(-1)]
        public virtual int Left
        {
            get
            {
                if (this.ViewState["_!Left"] == null)
                {
                    this.ViewState["_!Left"] = -1;
                }
                return Convert.ToInt32(this.ViewState["_!Left"]);
            }
            set { this.ViewState["_!Left"] = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected bool IsShowing
        {
            get
            {
                if (this.ViewState["_!IsShowing"] == null)
                {
                    this.ViewState["_!IsShowing"] = false;
                }
                return Convert.ToBoolean(this.ViewState["_!IsShowing"]);
            }
            private set { this.ViewState["_!IsShowing"] = value; }
        }

        #endregion

        #region Propriedades de Estilos

        #region Atributos

        /// <summary>
        /// 
        /// </summary>
        private TPopupContainerStyle _containerStyle;

        /// <summary>
        /// 
        /// </summary>
        private TPopupHeaderStyle _headerStyle;

        /// <summary>
        /// 
        /// </summary>
        private TPopupBodyStyle _bodyStyle;

        /// <summary>
        /// 
        /// </summary>
        private TPopupFooterStyle _footerStyle;

        /// <summary>
        /// 
        /// </summary>
        private TPopupExtenderStyle _modalStyle;

        #endregion

        /// <summary>
        /// 
        /// </summary>
        [Category("Styles")]
        [NotifyParentProperty(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public TPopupContainerStyle ContainerStyle
        {
            get
            {
                if (this._containerStyle == null)
                {
                    this._containerStyle = new TPopupContainerStyle();
                    if (base.IsTrackingViewState)
                    {
                        ((IStateManager)this._containerStyle).TrackViewState();
                    }
                }
                return this._containerStyle;
            }
            set { this._containerStyle = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Styles")]
        [NotifyParentProperty(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public TPopupHeaderStyle HeaderStyle
        {
            get
            {
                if (this._headerStyle == null)
                {
                    this._headerStyle = new TPopupHeaderStyle();
                    if (base.IsTrackingViewState)
                    {
                        ((IStateManager)this._headerStyle).TrackViewState();
                    }
                }
                return this._headerStyle;
            }
            set { this._headerStyle = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Styles")]
        [NotifyParentProperty(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public TPopupBodyStyle BodyStyle
        {
            get
            {
                if (this._bodyStyle == null)
                {
                    this._bodyStyle = new TPopupBodyStyle();
                    if (base.IsTrackingViewState)
                    {
                        ((IStateManager)this._bodyStyle).TrackViewState();
                    }
                }
                return this._bodyStyle;
            }
            set { this._bodyStyle = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Styles")]
        [NotifyParentProperty(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public TPopupFooterStyle FooterStyle
        {
            get
            {
                if (this._footerStyle == null)
                {
                    this._footerStyle = new TPopupFooterStyle();
                    if (base.IsTrackingViewState)
                    {
                        ((IStateManager)this._footerStyle).TrackViewState();
                    }
                }
                return this._footerStyle;
            }
            set { this._footerStyle = value; }
        }

        [Category("Styles")]
        [NotifyParentProperty(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public TPopupExtenderStyle ModalStyle
        {
            get
            {
                if (this._modalStyle == null)
                {
                    this._modalStyle = new TPopupExtenderStyle();
                    if (base.IsTrackingViewState)
                    {
                        ((IStateManager)this._modalStyle).TrackViewState();
                    }
                }
                return this._modalStyle;
            }
            set { this._modalStyle = value; }
        }

        #endregion

        #region Metodos

        /// <summary>
        /// 
        /// </summary>
        public void Show()
        {
            ModalPopupExtender modal1 = (ModalPopupExtender)this.FindControl(string.Concat(this.ID, "_ModalExtender"));

            modal1.Show();

            this.IsShowing = true;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Close()
        {
            ModalPopupExtender modal1 = (ModalPopupExtender)this.FindControl(string.Concat(this.ID, "_ModalExtender"));

            modal1.Hide();

            this.IsShowing = false;
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void CreateChildControls()
        {
            // criando container
            Panel pnlcontainer = this.CreateContainerControls();

            // criando cabecalho
            Panel pnlheader = this.CreateHeaderControls();

            // criado corpo
            Panel pnlbody = this.CreateBodyControls();

            // criando rodape
            Panel pnlfooter = this.CreateFooterControls();

            // criando botao disparador
            Control modaltarget = this.CreateModalTargetControls();

            // criando popup extender
            ModalPopupExtender modalextender = this.CreateModalControls(modaltarget);

            // adicionando controles ao container
            if (this.ShowHeader)
            {
                pnlcontainer.Controls.Add(pnlheader);
            }

            pnlcontainer.Controls.Add(pnlbody);

            pnlcontainer.Controls.Add(modaltarget);

            pnlcontainer.Controls.Add(modalextender);

            if (this.ShowFooter)
            {
                pnlcontainer.Controls.Add(pnlfooter);
            }

            // adicionando container ao contexto
            this.Controls.Add(pnlcontainer);

            // notificando criação dos controles
            this.isCreateChildControls = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private Panel CreateContainerControls()
        {
            // criando panel container
            Panel pnlcontainer = new Panel();
            pnlcontainer.ID = string.Concat(this.ID, "_Container");
            pnlcontainer.Width = Unit.Pixel(this.Width);
            pnlcontainer.Height = Unit.Pixel(this.Height);

            if (!this.ContainerStyle.IsEmpty)
            {
                pnlcontainer.ApplyStyle(this.ContainerStyle);
            }

            pnlcontainer.Attributes["style"] = string.Concat(pnlcontainer.Attributes["style"], "display: none;");

            return pnlcontainer;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected virtual Panel CreateHeaderControls()
        {
            // criando panel do cabecalho
            Panel pnlheader = new Panel();
            pnlheader.ID = string.Concat(this.ID, "_Header");
            pnlheader.Width = Unit.Pixel(this.Width);
            pnlheader.Height = Unit.Pixel(25);

            if (!this.HeaderStyle.IsEmpty)
            {
                pnlheader.ApplyStyle(this.HeaderStyle);
            }

            Table htable = new Table();
            htable.Width = pnlheader.Width;
            htable.Height = pnlheader.Height;

            TableRow hrow = new TableRow();
            hrow.VerticalAlign = (this.HeaderStyle.IsEmpty ||
                                  this.HeaderStyle.VerticalAlign == VerticalAlign.NotSet)
                                    ? VerticalAlign.Middle
                                    : this.HeaderStyle.VerticalAlign;
            hrow.HorizontalAlign = (this.HeaderStyle.IsEmpty) ? HorizontalAlign.NotSet : this.HeaderStyle.HorizontalAlign;

            TableCell hceel1 = new TableCell();
            hceel1.Width = Unit.Percentage(95);
            hceel1.HorizontalAlign = HorizontalAlign.Left;
            hceel1.VerticalAlign = VerticalAlign.Middle;
            hceel1.Wrap = (this.HeaderStyle.IsEmpty) ? false : this.HeaderStyle.Wrap;

            TableCell hceel2 = new TableCell();
            hceel2.Width = Unit.Percentage(5);
            hceel2.HorizontalAlign = HorizontalAlign.Center;
            hceel2.VerticalAlign = VerticalAlign.Middle;
            hceel2.Wrap = (this.HeaderStyle.IsEmpty) ? false : this.HeaderStyle.Wrap;

            LinkButton linkclose = new LinkButton();
            linkclose.ID = string.Concat(this.ID, "_Close");
            linkclose.Attributes.Add("style", string.Concat((this.Closable ? string.Empty : "display: none;"), "text-decoration:none;"));
            linkclose.Text = "X";
            linkclose.Click += new System.EventHandler(delegate(object sender, EventArgs e)
            {
                this.OnClosing();
            });

            if (!this.HeaderStyle.IsEmpty)
            {
                linkclose.ForeColor = this.HeaderStyle.ForeColor;
            }

            Label lbltitle = new Label();
            lbltitle.ID = string.Concat(this.ID, "_Title");
            lbltitle.Text = this.Title;

            hceel1.Controls.Add(lbltitle);
            hceel2.Controls.Add(linkclose);

            hrow.Cells.Add(hceel1);
            hrow.Cells.Add(hceel2);

            htable.Rows.Add(hrow);

            pnlheader.Controls.Add(htable);

            return pnlheader;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected virtual Panel CreateBodyControls()
        {
            // criado panel do corpo
            Panel pnlbody = new Panel();
            pnlbody.ID = string.Concat(this.ID, "_Body");
            pnlbody.Width = Unit.Pixel(this.Width);
            pnlbody.Height = Unit.Pixel(this.Height);

            if (this.ShowHeader)
            {
                pnlbody.Height = Unit.Pixel((int)pnlbody.Height.Value - 25);
            }

            if (this.ShowFooter)
            {
                pnlbody.Height = Unit.Pixel((int)pnlbody.Height.Value - 25);
            }

            if (!this.BodyStyle.IsEmpty)
            {
                pnlbody.ApplyStyle(this.BodyStyle);
            }

            pnlbody.Attributes["style"] = string.Concat(pnlbody.Attributes["style"], (this.Scrollable ? "overflow: auto;" : "overflow: hidden;"));

            Control pnlBodyChild = this.CreateBodyChildControls();

            if (pnlBodyChild != null)
            {
                pnlbody.Controls.Add(pnlBodyChild);
            }

            return pnlbody;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private ModalPopupExtender CreateModalControls(Control _target)
        {
            // criando popup extender
            ModalPopupExtender modalextender = new ModalPopupExtender();
            modalextender.ID = string.Concat(this.ID, "_ModalExtender");
            //modalextender.CancelControlID = (this.ShowHeader) ? string.Concat(this.ID, "_Close") : string.Empty;
            modalextender.PopupControlID = string.Concat(this.ID, "_Container");
            modalextender.X = this.Left;
            modalextender.Y = this.Top;
            modalextender.RepositionMode = ModalPopupRepositionMode.RepositionOnWindowResizeAndScroll;
            modalextender.TargetControlID = _target.ID;
            modalextender.DropShadow = false;

            if (!this.ModalStyle.IsEmpty)
            {
                modalextender.BackgroundCssClass = this.ModalStyle.CssClass;
            }

            return modalextender;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private Control CreateModalTargetControls()
        {
            // criando botao disparador
            Button btntarget = new Button();
            btntarget.ID = string.Concat(this.ID, "_Target");
            btntarget.Attributes.Add("style", "display: none;");
            btntarget.UseSubmitBehavior = true;
            btntarget.Click += new EventHandler(delegate(object sender, EventArgs e)
            {
                this.Show();
            });

            return btntarget;
        }

        /// <summary>
        /// 
        /// </summary>
        protected abstract Control CreateBodyChildControls();

        /// <summary>
        /// 
        /// </summary>
        protected virtual Panel CreateFooterControls()
        {
            Panel pnlfooter = new Panel();
            pnlfooter.Width = Unit.Pixel(this.Width);
            pnlfooter.Height = Unit.Pixel(25);

            if (!this.FooterStyle.IsEmpty)
            {
                pnlfooter.ApplyStyle(this.FooterStyle);
            }

            return pnlfooter;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreRender(EventArgs e)
        {
            if (this.isPropertyChanged)
            {
                this.Controls.Clear();

                this.CreateChildControls();
            }

            if (this.IsShowing)
            {
                this.Show();

                this.SetFocus();
            }

            base.OnPreRender(e);
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetFocus()
        {
            Control control = ControlUtil.FindControl(this, this.DefaultButtonID, EFindControlStrategy.TopDown);

            if (control != null)
            {
                this.Page.SetFocus(control);

                ModalPopupExtender modal1 = (ModalPopupExtender)this.FindControl(string.Concat(this.ID, "_ModalExtender"));

                if (modal1 != null)
                {
                    StringBuilder builder = new StringBuilder();

                    builder.Append("Sys.Application.add_load(fn_ModalFocusSetup); ");
                    builder.Append("function fn_SetFocusOnControl() { ");
                    builder.AppendFormat("var control = $get('{0}'); ", control.ClientID);
                    builder.Append("if(control != null && control.focus) { ");
                    builder.Append("control.focus(); ");
                    builder.Append("} ");
                    builder.Append("} ");
                    builder.Append("function fn_ModalFocusSetup() { ");
                    builder.AppendFormat("var modalPopup = $find('{0}'); ", modal1.ClientID);
                    builder.Append("if(modalPopup != null) { ");
                    builder.Append("modalPopup.add_shown(fn_SetFocusOnControl); ");
                    builder.Append("} ");
                    builder.Append("} ");

                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), string.Concat(this.ID, "_ModalFocusSetup"), builder.ToString(), true);
                }
            }
        }

        #endregion

        #region Eventos

        #region Declaração

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        public event TPopupEventHandler Closing;

        #endregion

        #region Implementação

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        public void OnClosing()
        {
            if (this.Closing != null)
            {
                this.Closing(this, TPopupEventArgs.Empty);
            }

            this.Close();
        }

        #endregion

        #endregion

        #region Metodos Notificacao

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected void CheckPropertyChanged(string propertyName, object value1, object value2)
        {
            // se não criou os controles cancela
            if (!this.isCreateChildControls)
            {
                return;
            }

            // se já notificado 1 vez cancela
            if (this.isPropertyChanged)
            {
                return;
            }

            // se valores diferentes então notifica.
            if (value1 != value2)
            {
                this.isPropertyChanged = true;
            }
        }

        #endregion
    }
}

