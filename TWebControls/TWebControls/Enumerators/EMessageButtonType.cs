
namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// Tipos de botões da mensagem.
    /// </summary>
    public enum EMessageButtonType
    {
       /// <summary>
       /// Tipo de caixa de diálogo de notificação (apenas botão de OK).
       /// </summary>
        OK, 

        /// <summary>
        /// Tipo de caixa de diálogo de decisão (botões de Sim e Não).
        /// </summary>
        YesOrNo,

        /// <summary>
        /// Tipo de caixa de diálogo de decisão (botões de Sim e Não).
        /// </summary>
        YesOrNoOrCancel,

        /// <summary>
        /// Tipo de caixa de diálogo para exibição de mensagens de erro.
        /// </summary>
        Error,

        /// <summary>
        /// Mensagens do tipo alerta
        /// </summary>
        Alert,

        /// <summary>
        /// Caixa de diálogo para exibição de mensagens na tela.
        /// </summary>
        Board
    }
}
