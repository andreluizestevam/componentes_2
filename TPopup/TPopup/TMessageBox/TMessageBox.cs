using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// 
    /// </summary>
    [ToolboxData("<{0}:TMessageBox runat=\"server\"></{0}:TMessageBox>")]
    public sealed class TMessageBox : TPopup
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
        [DefaultValue(true)]
        public bool Iconable
        {
            get
            {
                if (this.ViewState["_!Iconable"] == null)
                {
                    this.ViewState["_!Iconable"] = true;
                }
                return Convert.ToBoolean(this.ViewState["_!Iconable"]);
            }
            set
            {
                this.CheckPropertyChanged("Iconable", this.ViewState["_!Iconable"], value);

                this.ViewState["_!Iconable"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Behavior")]
        [DefaultValue(TMessageOption.Information)]
        public TMessageOption MessageOption
        {
            get
            {
                if (this.ViewState["_!MessageOption"] == null)
                {
                    this.ViewState["_!MessageOption"] = TMessageOption.Information;
                }
                return (TMessageOption)this.ViewState["_!MessageOption"];
            }
            set
            {
                this.CheckPropertyChanged("MessageOption", this.ViewState["_!MessageOption"], value);

                this.ViewState["_!MessageOption"] = value;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        [Category("Appearance")]
        [DefaultValue("OK")]
        public string ButtonText
        {
            get
            {
                if (this.ViewState["_!ButtonText"] == null)
                {
                    this.ViewState["_!ButtonText"] = "OK";
                }
                return Convert.ToString(this.ViewState["_!ButtonText"]);
            }
            set
            {
                this.CheckPropertyChanged("ButtonText", this.ViewState["_!ButtonText"], value);

                this.ViewState["_!ButtonText"] = value;
            }
        }

        #endregion

        #region Propriedades de Estilo

        #region Variaveis

        /// <summary>
        /// 
        /// </summary>
        private TPopupButtonStyle _buttonStyle;

        /// <summary>
        /// 
        /// </summary>
        private TPopupIconStyle _iconStyle;

        #endregion

        /// <summary>
        /// 
        /// </summary>
        [Category("Styles")]
        [NotifyParentProperty(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public TPopupButtonStyle ButtonStyle
        {
            get
            {
                if (this._buttonStyle == null)
                {
                    this._buttonStyle = new TPopupButtonStyle();
                    if (base.IsTrackingViewState)
                    {
                        ((IStateManager)this._buttonStyle).TrackViewState();
                    }
                }
                return this._buttonStyle;
            }
            set { this._buttonStyle = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Styles")]
        [NotifyParentProperty(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public TPopupIconStyle IconStyle
        {
            get
            {
                if (this._iconStyle == null)
                {
                    this._iconStyle = new TPopupIconStyle();
                    if (base.IsTrackingViewState)
                    {
                        ((IStateManager)this._iconStyle).TrackViewState();
                    }
                }
                return this._iconStyle;
            }
            set { this._iconStyle = value; }
        }

        #endregion

        #region Metodos de Exibição

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_message"></param>
        public void ShowError(string _message)
        {
            this.Show(_message, TMessageOption.Error);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_message"></param>
        public void ShowWarning(string _message)
        {
            this.Show(_message, TMessageOption.Warning);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_message"></param>
        public void ShowSuccess(string _message)
        {
            this.Show(_message, TMessageOption.Success);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_message"></param>
        public void ShowQuestion(string _message)
        {
            this.Show(_message, TMessageOption.Question);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_message"></param>
        public void ShowInformation(string _message)
        {
            this.Show(_message, TMessageOption.Information);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_message"></param>
        /// <param name="_option"></param>
        private void Show(string _message, TMessageOption _option)
        {
            this.Message = _message;
            this.MessageOption = _option;

            this.Show();
        }

        #endregion

        #region Metodos de Criação

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
                                    ? VerticalAlign.Middle
                                    : this.BodyStyle.VerticalAlign;

            if (this.Iconable)
            {
                this.CreateCellWithIcon(row1);
            }
            else
            {
                this.CreateCellWithoutIcon(row1);
            }

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
        /// <param name="row2"></param>
        private Control CreateButtonControls()
        {
            Panel panel1 = new Panel();
            panel1.Attributes.Add("style", "margin:2px;");

            if (!this.ButtonStyle.IsEmpty
                && !string.IsNullOrEmpty(this.ButtonStyle.ImageUrl))
            {
                panel1.Controls.Add(this.CreateImageButton());
            }
            else
            {
                panel1.Controls.Add(this.CreateButton());
            }

            return panel1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private Control CreateButton()
        {
            Button buttond = new Button();
            buttond.ID = string.Concat(this.ID, "_ButtonOK");
            buttond.Text = this.ButtonText;
            buttond.TabIndex = 1;

            buttond.Click += new System.EventHandler(delegate(object sender, EventArgs e)
            {
                this.OnClickOk();
            });

            if (!this.ButtonStyle.IsEmpty)
            {
                buttond.ApplyStyle(this.ButtonStyle);
            }

            return buttond;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private Control CreateImageButton()
        {
            ImageButton imagebuttond = new ImageButton();
            imagebuttond.ID = string.Concat(this.ID, "_ButtonOK");
            imagebuttond.ImageUrl = this.ButtonStyle.ImageUrl;
            imagebuttond.TabIndex = 1;

            imagebuttond.Click += new ImageClickEventHandler(delegate(object sender, ImageClickEventArgs e)
            {
                this.OnClickOk();
            });

            imagebuttond.ApplyStyle(this.ButtonStyle);

            return imagebuttond;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row1"></param>
        private void CreateCellWithIcon(TableRow _tableRow)
        {
            TableCell cell1 = new TableCell();
            cell1.Width = Unit.Percentage(20);
            cell1.HorizontalAlign = HorizontalAlign.Center;

            TableCell cell2 = new TableCell();
            cell2.Width = Unit.Percentage(80);
            cell2.HorizontalAlign = (this.BodyStyle.IsEmpty ||
                                     this.BodyStyle.HorizontalAlign == HorizontalAlign.NotSet)
                                        ? HorizontalAlign.Justify
                                        : this.BodyStyle.HorizontalAlign;
            cell2.Wrap = (this.BodyStyle.IsEmpty) ? false : this.BodyStyle.Wrap;

            Image image = new Image();
            image.BorderStyle = BorderStyle.None;
            image.BorderColor = System.Drawing.Color.Empty;
            image.BorderWidth = Unit.Pixel(0);

            switch (this.MessageOption)
            {
                case TMessageOption.Error:
                    {
                        image.ImageUrl = this.GetErrorImageUrl();
                        break;
                    }
                case TMessageOption.Warning:
                    {
                        image.ImageUrl = this.GetWarningImageUrl();
                        break;
                    }
                case TMessageOption.Success:
                    {
                        image.ImageUrl = this.GetSuccessImageUrl();
                        break;
                    }
                case TMessageOption.Question:
                    {
                        image.ImageUrl = this.GetQuestionImageUrl();
                        break;
                    }
                default:
                    {
                        image.ImageUrl = this.GetInformationImageUrl();
                        break;
                    }
            }

            this.ModalStyle.CssClass = this.GetBackgroundCssClass(this.MessageOption);

            LiteralControl label = new LiteralControl(this.Message);

            cell1.Controls.Add(image);
            cell2.Controls.Add(label);

            _tableRow.Cells.Add(cell1);
            _tableRow.Cells.Add(cell2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row1"></param>
        private void CreateCellWithoutIcon(TableRow _tableRow)
        {
            TableCell celld = new TableCell();
            celld.Width = Unit.Percentage(100);
            celld.HorizontalAlign = (this.BodyStyle.IsEmpty ||
                                     this.BodyStyle.HorizontalAlign == HorizontalAlign.NotSet)
                                        ? HorizontalAlign.Justify
                                        : this.BodyStyle.HorizontalAlign;
            celld.Wrap = (this.BodyStyle.IsEmpty) ? false : this.BodyStyle.Wrap;

            LiteralControl labeld = new LiteralControl(this.Message);

            celld.Controls.Add(labeld);

            _tableRow.Cells.Add(celld);
        }

        #endregion

        #region Eventos

        #region Declaração

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        public event TMessageEventHandler ClickOk;

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
                this.ClickOk(this, TMessageEventArgs.Empty);
            }

            this.Close();
        }

        #endregion

        #endregion

        #region Auxiliares

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string GetErrorImageUrl()
        {
            string imageUrl = this.Page.ClientScript.GetWebResourceUrl(this.GetType(), "Arquitetura.Web.WC.TPopup.Resources.error.gif");

            if (this.IconStyle != null
                && !string.IsNullOrEmpty(this.IconStyle.ErrorImageUrl))
            {
                imageUrl = this.IconStyle.ErrorImageUrl;
            }

            return imageUrl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string GetWarningImageUrl()
        {
            string imageUrl = this.Page.ClientScript.GetWebResourceUrl(this.GetType(), "Arquitetura.Web.WC.TPopup.Resources.warning.gif");

            if (this.IconStyle != null
                && !string.IsNullOrEmpty(this.IconStyle.WarningImageUrl))
            {
                imageUrl = this.IconStyle.WarningImageUrl;
            }

            return imageUrl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string GetSuccessImageUrl()
        {
            string imageUrl = this.Page.ClientScript.GetWebResourceUrl(this.GetType(), "Arquitetura.Web.WC.TPopup.Resources.success.gif");

            if (this.IconStyle != null
                && !string.IsNullOrEmpty(this.IconStyle.SuccessImageUrl))
            {
                imageUrl = this.IconStyle.SuccessImageUrl;
            }

            return imageUrl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string GetInformationImageUrl()
        {
            string imageUrl = this.Page.ClientScript.GetWebResourceUrl(this.GetType(), "Arquitetura.Web.WC.TPopup.Resources.information.gif");

            if (this.IconStyle != null
                && !string.IsNullOrEmpty(this.IconStyle.InformationImageUrl))
            {
                imageUrl = this.IconStyle.InformationImageUrl;
            }

            return imageUrl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string GetQuestionImageUrl()
        {
            string imageUrl = this.Page.ClientScript.GetWebResourceUrl(this.GetType(), "Arquitetura.Web.WC.TPopup.Resources.question.gif");

            if (this.IconStyle != null
                && !string.IsNullOrEmpty(this.IconStyle.QuestionImageUrl))
            {
                imageUrl = this.IconStyle.QuestionImageUrl;
            }

            return imageUrl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        private string GetBackgroundCssClass(TMessageOption option)
        {
            string cssClass = this.ModalStyle.CssClass;

            switch (option)
            {
                case TMessageOption.Error:
                    {
                        return !string.IsNullOrEmpty(this.IconStyle.ErrorBackgroundCssClass)
                                ? this.IconStyle.ErrorBackgroundCssClass
                                : cssClass;
                    }
                case TMessageOption.Warning:
                    {
                        return !string.IsNullOrEmpty(this.IconStyle.WarningBackgroundCssClass)
                                ? this.IconStyle.WarningBackgroundCssClass
                                : cssClass;
                    }
                case TMessageOption.Success:
                    {
                        return !string.IsNullOrEmpty(this.IconStyle.SuccessBackgroundCssClass)
                                ? this.IconStyle.SuccessBackgroundCssClass
                                : cssClass;
                    }
                case TMessageOption.Question:
                    {
                        return !string.IsNullOrEmpty(this.IconStyle.QuestionBackgroundCssClass)
                                ? this.IconStyle.QuestionBackgroundCssClass
                                : cssClass;
                    }
                default: return !string.IsNullOrEmpty(this.IconStyle.InformationBackgroundCssClass)
                               ? this.IconStyle.InformationBackgroundCssClass
                               : cssClass;
            }
        }

        #endregion
    }
}
