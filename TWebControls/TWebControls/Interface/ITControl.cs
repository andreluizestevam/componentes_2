
namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// Interface para ser usada nos controles
    /// </summary>
    public interface ITControl
    {
        /// <summary>
        /// Define o css que será usado na DIV container do controle.
        /// </summary>
        string ContainerCssClass { get; set; }

        /// <summary>
        /// Define um método client-side (javascript) customizado a ser usado no controle.
        /// </summary>
        string CustomClientBehavior { get; set; }
    }
}
