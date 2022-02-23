using System.Web.UI.Design;

namespace Arquitetura.Web.WebControls.Designer
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class TLoginNameDesigner : ControlDesigner
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
            if (!(base.Component is TLoginName))
            {
                return base.CreateErrorDesignTimeHtml("TLoginNameDesigner só pode ser utilizado por um TLoginName.");
            }
            return base.CreatePlaceHolderDesignTimeHtml(string.Format(((TLoginName)base.Component).FormatString, "[Usuário]"));
        }
    }
}
