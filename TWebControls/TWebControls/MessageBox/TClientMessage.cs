using System;
using System.Collections.Generic;
using System.Drawing;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Arquitetura.Web.WebControls.Messages
{
    /// <summary>
    /// Classe para mensagem cliente.
    /// </summary>
    public sealed class TClientMessage
    {
        #region Atributos

        /// <summary>
        /// O tipo da mensagem.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        private EMessageButtonType messageType;

        #endregion

        #region Construtores

        /// <summary>
        /// Construtor de mensagem de erro.
        /// </summary>
        /// <param name="errorMessage">A mensagem contendo o erro.</param>
        public TClientMessage(string errorMessage)
            : this(EMessageButtonType.Error)
        {
            if (!string.IsNullOrEmpty(errorMessage))
            {
                if (errorMessage.IndexOf("<html>") > 0)
                {
                    errorMessage = errorMessage.Remove(errorMessage.IndexOf("<html>"));
                }
            }

            this.Message = errorMessage;
        }

        /// <summary>
        /// Construtor.
        /// </summary>
        /// <param name="messageType">O tipo da mensagen.</param>
        /// <param name="message">A mensagem.</param>
        public TClientMessage(EMessageButtonType messageType, string message)
            : this(messageType)
        {
            this.Message = message;
        }

        private TMessageButton CreateButton(string text, int id)
        {
            var btn = new TMessageButton() { Text = text, Id = string.Concat("_idBtn", id) };

            btn.onSetFocus += new EventHandler(btn_onSetFocus);

            return btn;
        }


        /// <summary>
        /// Construtor.
        /// </summary>
        /// <param name="messageType">O tipo da mensagem.</param>
        public TClientMessage(EMessageButtonType messageType)
        {
            this.Buttons = new List<TMessageButton>();
            this.WindowSize = new Size(250, 350);
            this.messageType = messageType;

            switch (messageType)
            {
                case EMessageButtonType.OK:
                case EMessageButtonType.Error:
                case EMessageButtonType.Alert:
                    {
                        this.Buttons.Add(this.CreateButton("Ok", 1));
                        break;
                    }
                case EMessageButtonType.YesOrNo:
                    {
                        this.Buttons.Add(this.CreateButton("Sim", 1));
                        this.Buttons.Add(this.CreateButton("Não", 2));
                        break;
                    }
                case EMessageButtonType.YesOrNoOrCancel:
                    {
                        this.Buttons.Add(this.CreateButton("Sim", 1));
                        this.Buttons.Add(this.CreateButton("Não", 2));
                        this.Buttons.Add(this.CreateButton("Cancelar", 3));
                        break;
                    }
                case EMessageButtonType.Board:
                default:
                    {
                        break;
                    }
            }
        }

        /// <summary>
        /// Remove o foco de todos os botões
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btn_onSetFocus(object sender, EventArgs e)
        {
            this.Buttons.ForEach(x => x.ButtonFoco = false);
        }

        #endregion

        #region Propriedades

        /// <summary>
        /// Define a lista de botões.
        /// </summary>
        public List<TMessageButton> Buttons { get; private set; }

        /// <summary>
        /// Define o botão OK usado na mensagem.
        /// </summary>
        public TMessageButton ButtonOk
        {
            get
            {
                if (this.messageType == EMessageButtonType.YesOrNo || this.messageType == EMessageButtonType.YesOrNoOrCancel)
                {
                    return this.Buttons[0];
                }
                return null;
            }
        }

        /// <summary>
        /// Define o botão Yes usado na mensagem.
        /// </summary>
        public TMessageButton ButtonYes
        {
            get
            {
                if (this.ButtonExist())
                {
                    return this.Buttons[0];
                }
                return null;
            }
        }

        /// <summary>
        /// Define o botão No usado na mensagem.
        /// </summary>
        public TMessageButton ButtonNo
        {
            get
            {
                if (this.ButtonExist())
                {
                    return this.Buttons[1];
                }

                return null;
            }
        }

        /// <summary>
        /// Define o botão Cancel usado na mensagem.
        /// </summary>
        public TMessageButton ButtonCancel
        {
            get
            {
                if (this.messageType == EMessageButtonType.YesOrNoOrCancel)
                {
                    return this.Buttons[2];
                }

                return null;
            }
        }

        /// <summary>
        /// Define o título de caixa de diálogo para exibição da mensagem para o usuário.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Define a mensagem a ser exibida para o usuário.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Define a quantidade de mensagens que devem ficar na tela. Utilizado quando MessageType igual a Board. 
        /// </summary>
        public string Limiter { get; set; }

        /// <summary>
        /// Define o abre/fecha aberto no caso do Board.
        /// </summary>
        public bool StayBoardOpen { get; set; }

        /// <summary>
        /// Define a exibição da imagem do tipo da mensagem junto com a mensagem.
        /// </summary>
        public bool ShowImage { get; set; }

        /// <summary>
        /// Define o tamanho da tela que será mostrada.
        /// </summary>
        public Size WindowSize { get; set; }

        #endregion

        #region Metodos

        /// <summary>
        /// Verifica o tipo de mensagem.
        /// </summary>
        private bool ButtonExist()
        {
            return this.messageType == EMessageButtonType.YesOrNo || this.messageType == EMessageButtonType.YesOrNoOrCancel;
        }

        /// <summary>
        /// Retorna um objeto para ser interpretado pelo lado cliente.
        /// </summary>
        /// <returns>Um objeto interpretável pelo cliente.</returns>
        public string ToJson()
        {
            var tipo = new
            {
                messageType = this.messageType.ToString(),
                title = string.IsNullOrEmpty(this.Title) ? "Atenção" : this.Title,
                message = this.Message,
                buttons = this.Buttons.ToArray(),
                limiter = this.Limiter,
                showImage = this.ShowImage,
                width = this.WindowSize.Width,
                height = this.WindowSize.Height,
                manterFormAberto = this.StayBoardOpen
            };

            var jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            };

            return JsonConvert.SerializeObject(tipo, Formatting.None, jsonSerializerSettings);
        }

        #endregion
    }
}
