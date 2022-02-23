using System.Web.UI;

namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// 
    /// </summary>
    [ParseChildren(true)]
    [PersistChildren(true)]
    [Themeable(true)]
    public sealed class TPhoneBox : TMultiBox
    {
        /// <summary>
        /// Método que adiciona as propriedades no descritor
        /// </summary>
        /// <param name="descriptor"></param>
        protected override void GetScriptDescriptorChildren(ScriptControlDescriptor descriptor)
        {
            descriptor.AddProperty("Mask", @"(99) 9999-9999");
            descriptor.AddProperty("MaskExp", @"^\(\d{2}\) \d{4}-\d{4}$");
            descriptor.AddProperty("MaskType", (int)AjaxControlToolkit.MaskedEditType.Number);
            descriptor.AddProperty("InputDirection", (int)AjaxControlToolkit.MaskedEditInputDirection.LeftToRight);
        }
    }
}
