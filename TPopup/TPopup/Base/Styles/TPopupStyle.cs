using System.ComponentModel;
using System.Web.UI.WebControls;

namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class TPopupStyle : TableItemStyle
    {
        /// <summary>
        /// 
        /// </summary>
        internal TPopupStyle() { }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ReadOnly(true)]
        public new string RegisteredCssClass
        {
            get { return base.RegisteredCssClass; }
            private set { }
        }
    }
}
