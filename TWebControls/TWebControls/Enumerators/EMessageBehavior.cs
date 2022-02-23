
namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// Tipos de comportamentos da mensagem.
    /// </summary>
    public enum EMessageBehavior
    {
        /// <summary>
        /// Não faz nada apenas fecha a mensagem
        /// </summary>
        None,

        /// <summary>
        /// Mantem o comportamento definido na página.
        /// </summary>
        PageDefault,

        /// <summary>
        /// Permanecer no campo (On exit abortado).
        /// </summary>
        StayOnField,

        /// <summary>
        /// Permanecer no campo e limpar o valor dele (On exit abortado).
        /// </summary>
        StayOnFieldAndClear,

        /// <summary>
        /// Passa o fluxo de controle para outra ação.
        /// </summary>
        Redirect,

        /// <summary>
        /// Envia a página para o servidor
        /// </summary>
        SubmitPage
    }
}
