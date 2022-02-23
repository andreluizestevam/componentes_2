using System.ComponentModel;
using System.Web.UI.WebControls;

namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class TPopupBodyStyle : TPopupStyle
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
    }
}
