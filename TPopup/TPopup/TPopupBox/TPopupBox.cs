using System.ComponentModel;
using System.Web.UI;

namespace Arquitetura.Web.WebControls
{
    [ToolboxData("<{0}:TPopupBox runat=\"server\"></{0}:TPopupBox>")]
    [Designer(typeof(TPopupBoxDesigner))]
    public sealed class TPopupBox : TPopup
    {
        #region Propriedades

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [DefaultValue(null)]
        [TemplateContainer(typeof(TPopupTemplate))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TemplateInstance(TemplateInstance.Single)]
        public ITemplate ContentTemplate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Category("Behavior")]
        [DefaultValue("ButtonCancel")]
        public new string DefaultButtonID
        {
            get { return base.DefaultButtonID; }
            set { base.DefaultButtonID = value; }
        }

        #endregion

        #region Metodos

        /// <summary>
        /// 
        /// </summary>
        /// <param name="container"></param>
        protected override Control CreateBodyChildControls()
        {
            if (this.ContentTemplate != null)
            {
                TPopupTemplate contentTemplate = new TPopupTemplate();

                this.ContentTemplate.InstantiateIn(contentTemplate);

                return contentTemplate;
            }
            return new LiteralControl("&nbsp;");
        }

        #endregion
    }
}
