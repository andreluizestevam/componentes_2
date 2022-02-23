using System.Web.UI.Design;
using Arquitetura.Web.WebControls.Utils;

namespace Arquitetura.Web.WebControls.Designer
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class TLoginStatusDesigner : ControlDesigner
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string GetDesignTimeHtml()
        {
            return this.GetDesignTimeHtmlHelper(false, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_regions"></param>
        /// <returns></returns>
        public override string GetDesignTimeHtml(DesignerRegionCollection _regions)
        {
            return this.GetDesignTimeHtmlHelper(true, _regions);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_useRegions"></param>
        /// <param name="_regions"></param>
        /// <returns></returns>
        private string GetDesignTimeHtmlHelper(bool _useRegions, DesignerRegionCollection _regions)
        {
            if (!(base.Component is TLoginStatus))
            {
                return base.CreateErrorDesignTimeHtml("TLoginStatusDesigner só pode ser utilizado por um TLoginStatus.");
            }

            TLoginStatus control = (TLoginStatus)base.Component;

            return base.CreatePlaceHolderDesignTimeHtml(string.Concat(control.LoginText, " | ", control.LogoutText));
        }
    }
}
