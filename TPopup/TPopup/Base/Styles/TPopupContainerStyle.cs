using System;
using System.ComponentModel;
using System.Web.UI.WebControls;

namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class TPopupContainerStyle : TPopupStyle
    {
        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ReadOnly(true)]
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

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ReadOnly(true)]
        [Obsolete]
        public new System.Drawing.Color ForeColor
        {
            get { return base.ForeColor; }
            private set { }
        }
    }
}
