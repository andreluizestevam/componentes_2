using System.Web.UI;

namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// 
    /// </summary>
    [ParseChildren(true)]
    [PersistChildren(true)]
    [Themeable(true)]
    public sealed class TMailBox : TMultiBox
    {
        /// <summary>
        /// Método que adiciona as propriedades no descritor
        /// </summary>
        /// <param name="descriptor"></param>
        protected override void GetScriptDescriptorChildren(ScriptControlDescriptor descriptor)
        {
            descriptor.AddProperty("Mask", "");
            descriptor.AddProperty("MaskExp", @"^([a-zA-Z0-9])+([a-zA-Z0-9_\.\-])*\@([a-zA-Z0-9]){1}(([a-zA-Z0-9\-])+\.)*([a-zA-Z0-9]{2,4})+$");
            descriptor.AddProperty("MaskType", (int)AjaxControlToolkit.MaskedEditType.None);
            descriptor.AddProperty("InputDirection", (int)AjaxControlToolkit.MaskedEditInputDirection.LeftToRight);
        }
    }
}
