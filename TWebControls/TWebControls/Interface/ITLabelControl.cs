
namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// Interface para ser usada na descrição dos controles
    /// </summary>
    public interface ILabelControl : ITControl
    {
        /// <summary>
        /// Define as informações do label do controle.
        /// </summary>
        LabelOptions Label { get; }
    }
}
