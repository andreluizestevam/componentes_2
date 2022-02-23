using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// 
    /// </summary>
    [ToolboxData("<{0}:TConfirmBox runat=\"server\"></{0}:TConfirmBox>")]
    public sealed class TConfirmBox : TPopup
    {
        #region Propriedades

        /// <summary>
        /// 
        /// </summary>
        [Category("Appearance")]
        [DefaultValue("")]
        public string Message
        {
            get { return Convert.ToString(this.ViewState["_!Message"]); }
            set
            {
                this.CheckPropertyChanged("Message", this.ViewState["_!Message"], value);

                this.ViewState["_!Message"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Appearance")]
        [DefaultValue("OK")]
        public string ButtonOkText
        {
            get
            {
                if (this.ViewState["_!ButtonOkText"] == null)
                {
                    this.ViewState["_!ButtonOkText"] = "OK";
                }
                return Convert.ToString(this.ViewState["_!ButtonOkText"]);
            }
            set
            {
                this.CheckPropertyChanged("ButtonOkText", this.ViewState["_!ButtonOkText"], value);

                this.ViewState["_!ButtonOkText"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Appearance")]
        [DefaultValue("CANCEL")]
        public string ButtonCancelText
        {
            get
            {
                if (this.ViewState["_!ButtonCancelText"] == null)
                {
                    this.ViewState["_!ButtonCancelText"] = "CANCEL";
                }
                return Convert.ToString(this.ViewState["_!ButtonCancelText"]);
            }
            set
            {
                this.CheckPropertyChanged("ButtonCancelText", this.ViewState["_!ButtonCancelText"], value);

                this.ViewState["_!ButtonCancelText"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Behavior")]
        [DefaultValue(EButton.ButtonOk)]
        public EButton DefaultButton
        {
            get
            {
                if (this.ViewState["_!DefaultButton"] == null)
                {
                    this.ViewState["_!DefaultButton"] = EButton.ButtonOk;
                }

                return (EButton)this.ViewState["_!DefaultButton"];
            }
            set
            {
                switch (value)
                {
                    case EButton.ButtonCancel:
                        {
                            this.DefaultButtonID = string.Concat(this.ID, "_ButtonCancel");
                            break;
                        }
                    case EButton.ButtonOk:
                        {
                            this.DefaultButtonID = string.Concat(this.ID, "_ButtonOk");
                            break;
                        }
                }

                this.CheckPropertyChanged("DefaultButton", this.ViewState["_!DefaultButton"], value);

                this.ViewState["_!DefaultButton"] = value;
            }
        }

        #endregion

        #region Propriedades de Estilo

        #region Variaveis

        /// <summary>
        /// 
        /// </summary>
        private TPopupButtonStyle _buttonOkStyle;

        /// <summary>
        /// 
        /// </summary>
        private TPopupButtonStyle _buttonCancelStyle;

        #endregion

        /// <summary>
        /// 
        /// </summary>
        [Category("Styles")]
        [NotifyParentProperty(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public TPopupButtonStyle ButtonOkStyle
        {
            get
            {
                if (this._buttonOkStyle == null)
                {
                    this._buttonOkStyle = new TPopupButtonStyle();
                    if (base.IsTrackingViewState)
                    {
                        ((IStateManager)this._buttonOkStyle).TrackViewState();
                    }
                }
                return this._buttonOkStyle;
            }
            set { this._buttonOkStyle = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Styles")]
        [NotifyParentProperty(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public TPopupButtonStyle ButtonCancelStyle
        {
            get
            {
                if (this._buttonCancelStyle == null)
                {
                    this._buttonCancelStyle = new TPopupButtonStyle();
                    if (base.IsTrackingViewState)
                    {
                        ((IStateManager)this._buttonCancelStyle).TrackViewState();
                    }
                }
                return this._buttonCancelStyle;
            }
            set { this._buttonCancelStyle = value; }
        }

        #endregion

        #region Metodos

        /// <summary>
        /// 
        /// </summary>
        /// <param name="container"></param>
        protected override Control CreateBodyChildControls()
        {
            Table table = new Table();
            table.Width = (this.Scrollable) ? Unit.Pixel(this.Width - 16) : Unit.Pixel(this.Width);
            table.Height = Unit.Percentage(100);

            TableRow row1 = new TableRow();
            row1.VerticalAlign = (this.BodyStyle.IsEmpty ||
                                  this.BodyStyle.VerticalAlign == VerticalAlign.NotSet)
                                    ? VerticalAlign.Bottom
                                    : this.BodyStyle.VerticalAlign;

            TableCell cell1 = new TableCell();
            cell1.Width = Unit.Percentage(100);
            cell1.HorizontalAlign = (this.BodyStyle.IsEmpty ||
                                     this.BodyStyle.HorizontalAlign == HorizontalAlign.NotSet)
                                        ? HorizontalAlign.Justify
                                        : this.BodyStyle.HorizontalAlign;
            cell1.Wrap = (this.BodyStyle.IsEmpty) ? false : this.BodyStyle.Wrap;

            LiteralControl label1 = new LiteralControl(this.Message);

            cell1.Controls.Add(label1);

            row1.Cells.Add(cell1);

            table.Rows.Add(row1);

            return table;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override Panel CreateFooterControls()
        {
            Panel pnlfooter = new Panel();
            pnlfooter.Width = Unit.Pixel(this.Width);
            pnlfooter.Height = Unit.Pixel(25);
            pnlfooter.HorizontalAlign = (this.FooterStyle.IsEmpty)
                                            ? HorizontalAlign.Center
                                            : this.FooterStyle.HorizontalAlign;

            if (!this.FooterStyle.IsEmpty)
            {
                pnlfooter.ApplyStyle(this.FooterStyle);
            }

            pnlfooter.Controls.Add(this.CreateButtonControls());

            return pnlfooter;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private Control CreateButtonControls()
        {
            Control button1 = (!this.ButtonOkStyle.IsEmpty && !string.IsNullOrEmpty(this.ButtonOkStyle.ImageUrl))
                                ? this.CreateImageButtonOk(this.ButtonOkText, this.ButtonOkStyle)
                                : this.CreateButtonOk(this.ButtonOkText, this.ButtonOkStyle);
            Control button2 = (!this.ButtonCancelStyle.IsEmpty && !string.IsNullOrEmpty(this.ButtonCancelStyle.ImageUrl))
                                ? this.CreateImageButtonCancel(this.ButtonCancelText, this.ButtonCancelStyle)
                                : this.CreateButtonCancel(this.ButtonCancelText, this.ButtonCancelStyle);

            Panel panel1 = new Panel();
            panel1.Attributes.Add("style", "margin:2px;");

            panel1.Controls.Add(button1);
            panel1.Controls.Add(new LiteralControl("&nbsp;"));
            panel1.Controls.Add(button2);

            return panel1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_text"></param>
        /// <param name="_style"></param>
        /// <returns></returns>
        private Control CreateButtonOk(string _text, TPopupButtonStyle _style)
        {
            Button button1 = (Button)this.CreateButton(_text, _style);
            button1.ID = string.Concat(this.ID, "_ButtonOk");
            button1.TabIndex = this.GetTabIndex(EButton.ButtonOk);

            button1.Click += new System.EventHandler(delegate(object sender, EventArgs e)
            {
                this.OnClickOk();
            });

            return button1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_text"></param>
        /// <param name="_style"></param>
        /// <returns></returns>
        private Control CreateButtonCancel(string _text, TPopupButtonStyle _style)
        {
            Button button1 = (Button)this.CreateButton(_text, _style);
            button1.ID = string.Concat(this.ID, "_ButtonCancel");
            button1.TabIndex = this.GetTabIndex(EButton.ButtonCancel);

            button1.Click += new System.EventHandler(delegate(object sender, EventArgs e)
            {
                this.OnClickCancel();
            });

            return button1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_text"></param>
        /// <param name="_style"></param>
        /// <returns></returns>
        private Control CreateButton(string _text, TPopupButtonStyle _style)
        {
            Button buttond = new Button();
            buttond.Text = _text;
            buttond.ToolTip = _text;

            if (!_style.IsEmpty)
            {
                buttond.ApplyStyle(_style);
            }

            return buttond;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_text"></param>
        /// <param name="_style"></param>
        /// <returns></returns>
        private Control CreateImageButtonOk(string _text, TPopupButtonStyle _style)
        {
            ImageButton imagebutton1 = (ImageButton)this.CreateImageButton(_text, _style);
            imagebutton1.ID = string.Concat(this.ID, "_ButtonOk");
            imagebutton1.TabIndex = this.GetTabIndex(EButton.ButtonOk);

            imagebutton1.Click += new ImageClickEventHandler(delegate(object sender, ImageClickEventArgs e)
            {
                this.OnClickOk();
            });

            return imagebutton1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_text"></param>
        /// <param name="_style"></param>
        /// <returns></returns>
        private Control CreateImageButtonCancel(string _text, TPopupButtonStyle _style)
        {
            ImageButton imagebutton1 = (ImageButton)this.CreateImageButton(_text, _style);
            imagebutton1.ID = string.Concat(this.ID, "_ButtonCancel");
            imagebutton1.TabIndex = this.GetTabIndex(EButton.ButtonCancel);

            imagebutton1.Click += new ImageClickEventHandler(delegate(object sender, ImageClickEventArgs e)
            {
                this.OnClickCancel();
            });

            return imagebutton1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_text"></param>
        /// <param name="_style"></param>
        /// <returns></returns>
        private Control CreateImageButton(string _text, TPopupButtonStyle _style)
        {
            ImageButton imagebuttond = new ImageButton();
            imagebuttond.ImageUrl = _style.ImageUrl;
            imagebuttond.ToolTip = _text;

            imagebuttond.Click += new ImageClickEventHandler(delegate(object sender, ImageClickEventArgs e)
            {
                this.OnClickOk();
            });

            imagebuttond.ApplyStyle(_style);

            return imagebuttond;
        }

        /// <summary>
        /// Método que recupera o tabindex do botão
        /// </summary>
        /// <param name="button">O botão</param>
        /// <returns>int</returns>
        private short GetTabIndex(EButton button)
        {
            if (button == EButton.ButtonOk)
            {
                return (short)(this.DefaultButton == EButton.ButtonOk ? 1 : 2);
            }
            else
            {
                return (short)(this.DefaultButton == EButton.ButtonCancel ? 1 : 2);
            }
        }

        #endregion

        #region Eventos

        #region Declaração

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        public event TConfirmEventHandler ClickOk;

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        public event TConfirmEventHandler ClickCancel;

        #endregion

        #region Implementação

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        public void OnClickOk()
        {
            if (this.ClickOk != null)
            {
                this.ClickOk(this, TConfirmEventArgs.Empty);
            }

            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        public void OnClickCancel()
        {
            if (this.ClickCancel != null)
            {
                this.ClickCancel(this, TConfirmEventArgs.Empty);
            }

            this.Close();
        }

        #endregion

        #endregion
    }
}
