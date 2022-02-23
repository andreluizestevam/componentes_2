using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Arquitetura.Web.WebControls.Messages
{
    /// <summary>
    /// Classe para os botões da mensagem.
    /// </summary>
    public sealed class TMessageButton
    {
        public event EventHandler onSetFocus;

        /// <summary>
        /// Construtor padrão.
        /// </summary>
        public TMessageButton()
        {
            this.Behavior = EMessageBehavior.None;
            this.Text = "Ok";
        }

        /// <summary>
        /// Define o comportamento do botão após receber o clique.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public EMessageBehavior Behavior { get; set; }

        /// <summary>
        /// Define a url para redirecionamento.
        /// </summary>
        public string UrlForRedirect { get; set; }

        /// <summary>
        /// Define o texto do botão.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Informa se este é o botão com o foco
        /// </summary>
        public bool ButtonFoco { get; internal set; }

        /// <summary>
        /// Id no cliente
        /// </summary>
        public string Id { get; internal set; }

        /// <summary>
        /// Define se este botão receberá o foco
        /// </summary>
        public void SetFocus()
        {
            if (this.onSetFocus != null)
            {
                this.onSetFocus(this, EventArgs.Empty);
                this.ButtonFoco = true;
            }
        }

        /// <summary>
        /// Define o dado a ser enviado quando o botão receber o clique.
        /// </summary>
        public string DataReturn { get; set; }

        /// <summary>
        /// Define a função a ser chamada quando o botão receber o clique.
        /// </summary>
        public string CallBackFuncion { get; set; }
    }
}
