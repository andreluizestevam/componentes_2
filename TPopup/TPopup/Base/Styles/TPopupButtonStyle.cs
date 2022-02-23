using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class TPopupButtonStyle : TPopupStyle
    {
        /// <summary>
        /// 
        /// </summary>
        [Category("Appearance")]
        [NotifyParentProperty(true)]
        [DefaultValue("")]
        [UrlProperty]
        public string ImageUrl
        {
            get
            {
                return Convert.ToString(this.ViewState["ImageUrl"]);
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                base.ViewState["ImageUrl"] = value;
            }
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
