
namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// Enumeração de modos de paginação
    /// </summary>
    public enum TPagerButtons
    {
        /// <summary>
        /// Enumerador para anterior e proximo
        /// </summary>
        NextPrevious = 0,

        /// <summary>
        /// Enumerador para numeros
        /// </summary>
        Numeric = 1,

        /// <summary>
        /// Enumerador para anterior/proximo e primeiro/ultimo
        /// </summary>
        NextPreviousFirstLast = 2,

        /// <summary>
        /// Enumerador para numeros e primeiro/ultimo
        /// </summary>
        NumericFirstLast = 3,

        /// <summary>
        /// Enumerador para numeros e anterior/proximo
        /// </summary>
        NumericNextPrevious = 4,

        /// <summary>
        /// Enumerador para numeros e anterior/proximo e primeiro/ultimo
        /// </summary>
        NumericNextPreviousFirstLast = 5,
    }
}
