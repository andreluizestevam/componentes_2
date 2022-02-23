
namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// Interface para ser usada na validação dos controles
    /// </summary>
    public interface IValidationControl : ITControl
    {
        /// <summary>
        /// Define as informações de validação do controle.
        /// </summary>
        ValidationOptions Validation { get; }
    }
}
