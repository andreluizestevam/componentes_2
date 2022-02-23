
namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// Tipos de Máscara disponíveis.
    /// </summary>
    public enum EMaskType
    {
        /// <summary>
        /// Mascará para CEP
        /// </summary>
        CEP,

        /// <summary>
        /// Mascará para CNPJ
        /// </summary>
        CNPJ,

        /// <summary>
        /// Mascará para CPF
        /// </summary>
        CPF,

        /// <summary>
        /// Mascará customizada.
        /// </summary>
        Custom,

        /// <summary>
        /// Mascará para data.
        /// </summary>
        Date,

        /// <summary>
        /// Mascará para data e hora.
        /// </summary>
        DateTime,

        /// <summary>
        /// Mascará para decimal.
        /// </summary>
        Decimal,

        /// <summary>
        /// Mascará para hora.
        /// </summary>
        HourDay,

        /// <summary>
        /// Mascará para quantidade de horas.
        /// </summary>
        HourAmount,

        /// <summary>
        /// Mascará para inteiro.
        /// </summary>
        Integer,

        /// <summary>
        /// Mascará para mês e ano.
        /// </summary>
        MonthAndYear,

        /// <summary>
        /// Mascará para decimal com sinal.
        /// </summary>
        SignedDecimal,

        /// <summary>
        /// Mascará para inteiro com sinal.
        /// </summary>
        SignedInteger,

        /// <summary>
        /// Mascará para ano
        /// </summary>
        Year,

        /// <summary>
        /// Mascará para telefone.
        /// </summary>
        Telefone,

        /// <summary>
        /// Nenhuma mascará.
        /// </summary>
        None
    }
}