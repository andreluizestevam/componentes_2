using System;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class TPopupIconStyle : TPopupStyle
    {
        /// <summary>
        /// 
        /// </summary>
        [Category("Appearance")]
        [NotifyParentProperty(true)]
        [DefaultValue("")]
        [UrlProperty]
        public string ErrorImageUrl
        {
            get
            {
                return Convert.ToString(this.ViewState["ErrorImageUrl"]);
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                base.ViewState["ErrorImageUrl"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Appearance")]
        [NotifyParentProperty(true)]
        [DefaultValue("")]
        public string ErrorBackgroundCssClass
        {
            get
            {
                return Convert.ToString(this.ViewState["ErrorBackgroundCssClass"]);
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                base.ViewState["ErrorBackgroundCssClass"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Appearance")]
        [NotifyParentProperty(true)]
        [DefaultValue("")]
        [UrlProperty]
        public string WarningImageUrl
        {
            get
            {
                return Convert.ToString(this.ViewState["WarningImageUrl"]);
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                base.ViewState["WarningImageUrl"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Appearance")]
        [NotifyParentProperty(true)]
        [DefaultValue("")]
        public string WarningBackgroundCssClass
        {
            get
            {
                return Convert.ToString(this.ViewState["WarningBackgroundCssClass"]);
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                base.ViewState["WarningBackgroundCssClass"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Appearance")]
        [NotifyParentProperty(true)]
        [DefaultValue("")]
        [UrlProperty]
        public string InformationImageUrl
        {
            get
            {
                return Convert.ToString(this.ViewState["InformationImageUrl"]);
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                base.ViewState["InformationImageUrl"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Appearance")]
        [NotifyParentProperty(true)]
        [DefaultValue("")]
        public string InformationBackgroundCssClass
        {
            get
            {
                return Convert.ToString(this.ViewState["InformationBackgroundCssClass"]);
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                base.ViewState["InformationBackgroundCssClass"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Appearance")]
        [NotifyParentProperty(true)]
        [DefaultValue("")]
        [UrlProperty]
        public string QuestionImageUrl
        {
            get
            {
                return Convert.ToString(this.ViewState["QuestionImageUrl"]);
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                base.ViewState["QuestionImageUrl"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Appearance")]
        [NotifyParentProperty(true)]
        [DefaultValue("")]
        public string QuestionBackgroundCssClass
        {
            get
            {
                return Convert.ToString(this.ViewState["QuestionBackgroundCssClass"]);
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                base.ViewState["QuestionBackgroundCssClass"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Appearance")]
        [NotifyParentProperty(true)]
        [DefaultValue("")]
        [UrlProperty]
        public string SuccessImageUrl
        {
            get
            {
                return Convert.ToString(this.ViewState["SuccessImageUrl"]);
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                base.ViewState["SuccessImageUrl"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Appearance")]
        [NotifyParentProperty(true)]
        [DefaultValue("")]
        public string SuccessBackgroundCssClass
        {
            get
            {
                return Convert.ToString(this.ViewState["SuccessBackgroundCssClass"]);
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                base.ViewState["SuccessBackgroundCssClass"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ReadOnly(true)]
        [Obsolete]
        public new Unit Width
        {
            get { return base.Width; }
            private set { }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ReadOnly(true)]
        [Obsolete]
        public new Unit Height
        {
            get { return base.Height; }
            private set { }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ReadOnly(true)]
        [Obsolete]
        public new Color BackColor
        {
            get { return base.BackColor; }
            private set { }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ReadOnly(true)]
        [Obsolete]
        public new Color BorderColor
        {
            get { return base.BorderColor; }
            private set { }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ReadOnly(true)]
        [Obsolete]
        public new BorderStyle BorderStyle
        {
            get { return base.BorderStyle; }
            private set { }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ReadOnly(true)]
        [Obsolete]
        public new Unit BorderWidth
        {
            get { return base.BorderWidth; }
            private set { }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ReadOnly(true)]
        [Obsolete]
        public new FontInfo Font
        {
            get { return base.Font; }
            private set { }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ReadOnly(true)]
        [Obsolete]
        public new Color ForeColor
        {
            get { return base.ForeColor; }
            private set { }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ReadOnly(true)]
        [Obsolete]
        public new string RegisteredCssClass
        {
            get { return base.RegisteredCssClass; }
            private set { }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ReadOnly(true)]
        [Obsolete]
        public new string CssClass
        {
            get { return base.CssClass; }
            private set { }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ReadOnly(true)]
        [Obsolete]
        public new HorizontalAlign HorizontalAlign
        {
            get { return base.HorizontalAlign; }
            private set { }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ReadOnly(true)]
        [Obsolete]
        public new VerticalAlign VerticalAlign
        {
            get { return base.VerticalAlign; }
            private set { }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ReadOnly(true)]
        [Obsolete]
        public new bool Wrap
        {
            get { return base.Wrap; }
            private set { }
        }
    }
}
