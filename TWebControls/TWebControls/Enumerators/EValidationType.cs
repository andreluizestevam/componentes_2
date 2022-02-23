
namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// Tipos de validação disponíveis.
    /// </summary>
    public enum EValidationType
    {
        /// <summary>
        /// Validação CPNJ.
        /// </summary>
        CNPJ,

        /// <summary>
        /// Validação CPF.
        /// </summary>
        CPF,

        /// <summary>
        /// Validação de data.
        /// </summary>
        Date,

        /// <summary>
        /// Validação de hora.
        /// </summary>
        HourDay,
        
        /// <summary>
        /// Validação de data e hora.
        /// </summary>
        DateTime,

        /// <summary>
        /// Validação de quantidade de hora.
        /// </summary>
        HourAmount,

        /// <summary>
        /// Validação de e-mail.
        /// </summary>
        Email,

        /// <summary>
        /// Nenhuma validação.
        /// </summary>
        None,
    }
}
