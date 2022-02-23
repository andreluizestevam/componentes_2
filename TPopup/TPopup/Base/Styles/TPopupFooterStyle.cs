using System;
using System.ComponentModel;
using System.Web.UI.WebControls;

namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class TPopupFooterStyle : TPopupStyle
    {
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
