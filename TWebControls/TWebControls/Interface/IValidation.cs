
namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// Interface para ser usada na validação dos controles
    /// </summary>
    public interface IValidation
    {
        /// <summary>
        /// Define o texto do erro customizado para o controle.
        /// </summary>
        string ErrorText { get; set; }

        /// <summary>
        /// Define a expressão regular para validar o controle.
        /// </summary>
        string RegularExpression { get; set; }

        /// <summary>
        /// Define um método client-side (javascript) customizado a ser usado para validar o controle.
        /// </summary>
        string CustomClientValidator { get; set; }

        /// <summary>
        /// Define se o controle é obrigatório.
        /// </summary>
        bool Required { get; set; }

        /// <summary>
        /// Define a classe CSS para o indicador de obrigatoriedade.
        /// </summary>
        string RequiredCssClass { get; set; }

        /// <summary>
        /// Define o texto do indicador de obrigatoriedade para o controle.
        /// </summary>
        string RequiredErrorIndicator { get; set; }

        /// <summary>
        /// Define o texto do indicador de obrigatoriedade para o controle.
        /// </summary>
        string RequiredErrorText { get; set; }
    }
}
