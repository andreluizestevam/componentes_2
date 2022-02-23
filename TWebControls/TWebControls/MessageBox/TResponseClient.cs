using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Arquitetura.Web.WebControls.Messages
{
    /// <summary>
    /// Classe para resposta cliente.
    /// </summary>
    public sealed class TResponseClient
    {
        #region Construtores
        /// <summary>
        /// Construtor padrão
        /// </summary>
        public TResponseClient() { }

        /// <summary>
        /// Construtor para erro
        /// </summary>
        /// <param name="erroMgs">Mensagem de erro que será enviada para o cliente</param>
        public TResponseClient(string erroMgs)
        {
            this.Message = new TClientMessage(EMessageButtonType.Error, erroMgs);
        }
        #endregion

        /// <summary>
        /// Define a mensagem a ser exibida no cliente.
        /// </summary>
        public TClientMessage Message { get; set; }

        /// <summary>
        /// Define os dados que serão passados para a função javascript de callback.
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Define o nome da função a ser chamada no cliente.
        /// </summary>
        public string CallBackFuncion { get; set; }

        /// <summary>
        /// Retorna um objeto para ser interpretado pelo lado cliente.
        /// </summary>
        /// <returns>Um objeto interpretável pelo cliente.</returns>
        public string ToJson()
        {
            var jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            };

            var tipo = new { message = this.Message, data = this.Data, callBackFuncion = this.CallBackFuncion };
            return JsonConvert.SerializeObject(tipo, Formatting.None, jsonSerializerSettings);
        }
    }
}
