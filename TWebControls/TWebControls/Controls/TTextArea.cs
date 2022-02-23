using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using Arquitetura.Web.WebControls.JavaScript;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// Componente TextArea customizado.
    /// </summary>
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:TTextArea runat=\"server\"></{0}:TTextArea>")]
    public class TTextArea : TBaseTextBox
    {
        #region Construtores

        /// <summary>
        /// Construtor
        /// </summary>
        public TTextArea()
            : base()
        {
            this.TextMode = TextBoxMode.MultiLine;
            this.CountersCssClass = string.Empty;
            this.ShowCounters = false;
        }

        #endregion

        #region Propriedades

        /// <summary>
        /// Define o modo de exibição do controle. Permite somente MultiLine.
        /// </summary>
        [DefaultValue("MultiLine")]
        public override TextBoxMode TextMode
        {
            get
            {
                return TextBoxMode.MultiLine;
            }
            set
            {
            }
        }

        /// <summary>
        /// Define a classe CSS para os contadores.
        /// </summary>
        [Category("Tbiz Appearance")]
        [CssClassProperty]
        [NotifyParentProperty(true), PersistenceMode(PersistenceMode.Attribute)]
        [DefaultValue("")]
        [Description("Define a classe CSS para os contadores.")]
        public string CountersCssClass
        {
            get
            {
                return this.ViewState["_!TotalCssClass"].ToString();
            }
            set
            {
                this.ViewState["_!TotalCssClass"] = value;
            }
        }

        /// <summary>
        /// Define se o contador será exibido.
        /// </summary>
        [Category("Tbiz Behavior")]
        [DefaultValue(false)]
        [NotifyParentProperty(true), PersistenceMode(PersistenceMode.Attribute)]
        [Description("Define se o contador será exibido.")]
        public bool ShowCounters
        {
            get
            {
                return Convert.ToBoolean(this.ViewState["_!ShowCounters"]);
            }
            set
            {
                this.ViewState["_!ShowCounters"] = value;
            }
        }

        #endregion

        #region Eventos

        /// <summary>
        /// Exibe no controle o contador de caracteres.
        /// </summary>
        /// <param name="writer">O escritor HTML.</param>
        private void ShowLegend(HtmlTextWriter writer)
        {
            if (this.DesignMode || !this.ShowCounters)
            {
                return;
            }

            writer.WriteBeginTag("label");
            writer.WriteAttribute("id", string.Concat(this.ClientID, "lbl"));
            writer.WriteAttribute("class", string.IsNullOrEmpty(this.CountersCssClass) ? "ContaCaracteres" : String.Concat("ContaCaracteres ", this.CountersCssClass));
            writer.Write(">");
            writer.WriteEncodedText("Caracteres restantes: ");
            writer.WriteEndTag("label");
        }

        /// <summary>
        /// Renderiza o componente.
        /// </summary>
        /// <param name="writer">O escritor HTML.</param>
        protected override void Render(HtmlTextWriter writer)
        {
            if (!this.DesignMode)
            {
                ControlUtils.ConfigureDivContainer(writer, this);

                var tp = new CustomTextArea()
                {
                    maxLength = this.MaxLength.ToString()
                };

                string gOpt = JsonConvert.SerializeObject(tp, Formatting.None, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });

                if (gOpt != "{}")
                {
                    writer.AddAttribute("-tbzTpComp", gOpt);
                }

                Arquitetura.Web.WebControls.JavaScript.ClientValidation objValidacaoCliente = ControlUtils.CreateClientValidation(this);

                var jsonSerializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    NullValueHandling = NullValueHandling.Ignore
                };

                string gVal = JsonConvert.SerializeObject(objValidacaoCliente, Formatting.None, jsonSerializerSettings);

                if (gVal != "{}")
                {
                    writer.AddAttribute("-tbzValdt", gVal);
                }
            }

            ControlUtils.ConfigureLabel(writer, this);

            base.Render(writer);

            this.ShowLegend(writer);

            if (!this.DesignMode)
            {
                writer.WriteEndTag("div");
            }
        }

        #endregion
    }
}
