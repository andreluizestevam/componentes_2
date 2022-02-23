using System.Web.UI.Design;
using System.Web.UI.WebControls;

namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class TPopupBoxDesigner : ContainerControlDesigner
    {
        /// <summary>
        /// 
        /// </summary>
        public TPopupBoxDesigner()
        {
            base.FrameStyle.Width = Unit.Percentage(100);
        }

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
        /// <param name="regions"></param>
        /// <returns></returns>
        public override string GetDesignTimeHtml(DesignerRegionCollection regions)
        {
            return this.GetDesignTimeHtmlHelper(true, regions);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="useRegions"></param>
        /// <param name="regions"></param>
        /// <returns></returns>
        private string GetDesignTimeHtmlHelper(bool useRegions, DesignerRegionCollection regions)
        {
            TPopupBox component = (TPopupBox)base.Component;
            
            if (useRegions)
            {
                return base.GetDesignTimeHtml(regions);
            }
            
            return base.GetDesignTimeHtml();
        }
    }
}
