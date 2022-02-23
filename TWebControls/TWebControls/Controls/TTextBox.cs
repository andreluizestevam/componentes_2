using System;
using System.ComponentModel;
using System.Web.UI;
using Arquitetura.Web.WebControls.JavaScript;
using Newtonsoft.Json;

namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// Componente TextBox customizado.
    /// </summary>
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:TTextBox runat=\"server\"></{0}:TTextBox>")]
    public class TTextBox : TBaseTextBox
    {
        #region Construtores

        /// <summary>
        /// Construtor
        /// </summary>
        public TTextBox()
        {
            this.ValidationType = EValidationType.None;
            this.CustomMask = string.Empty;
            this.MaskType = EMaskType.None;
            this.CustomMask = string.Empty;
        }

        #endregion

        #region Propriedades

        /// <summary>
        /// Define o tipo de validação que será aplicado ao controle.
        /// </summary>
        [Category("Tbiz Behavior")]
        [DefaultValue(EValidationType.None)]
        [NotifyParentProperty(true), PersistenceMode(PersistenceMode.Attribute)]
        [Description("Define o tipo de validação que será aplicado ao controle.")]
        public EValidationType ValidationType
        {
            get
            {
                return (EValidationType)this.ViewState["_!ValidationType"];
            }
            set
            {
                this.ViewState["_!ValidationType"] = value;
            }
        }

        /// <summary>
        /// Define a máscara customizada para o controle. Só é funcional caso MaskType esteja definida como Custom.
        /// </summary>
        [Category("Tbiz Behavior")]
        [DefaultValue("")]
        [NotifyParentProperty(true), PersistenceMode(PersistenceMode.Attribute)]
        [Description("Define a máscara customizada para o controle. Só é funcional caso MaskType esteja definida como Custom.")]
        public string CustomMask
        {
            get
            {
                return this.ViewState["_!Mask"].ToString();
            }
            set
            {
                this.ViewState["_!Mask"] = value;
            }
        }

        /// <summary>
        /// Define o tipo de máscara a ser aplicada ao controle.
        /// </summary>
        [Category("Tbiz Behavior")]
        [DefaultValue(EMaskType.None)]
        [NotifyParentProperty(true), PersistenceMode(PersistenceMode.Attribute)]
        [Description("Define o tipo de máscara a ser aplicada ao controle.")]
        public EMaskType MaskType
        {
            get
            {
                return (EMaskType)this.ViewState["_MaskType"];
            }
            set
            {
                if (value != EMaskType.Custom)
                {
                    this.CustomMask = string.Empty;
                }

                this.ViewState["_MaskType"] = value;
            }
        }
        #endregion

        #region Métodos

        /// <summary>
        /// Define o css baseado no tipo da máscara.
        /// </summary>
        private void DefineCss()
        {
            switch (this.MaskType)
            {
                case EMaskType.CEP:
                case EMaskType.CNPJ:
                case EMaskType.CPF:
                case EMaskType.DateTime:
                case EMaskType.Telefone:
                    {
                        this.CssClass = this.ConcatCss("cp_11a15");
                        break;
                    }
                case EMaskType.Date:
                    {
                        this.CssClass = this.ConcatCss("cp_6a8");
                        break;
                    }
                case EMaskType.HourDay:
                case EMaskType.HourAmount:
                    {
                        this.CssClass = this.ConcatCss("cp_3a5");
                        break;
                    }
                case EMaskType.MonthAndYear:
                    {
                        this.CssClass = this.ConcatCss("cp_6a8");
                        break;
                    }
                case EMaskType.Year:
                    {
                        this.CssClass = this.ConcatCss("cp_3a5");
                        break;
                    }
                case EMaskType.Custom:
                case EMaskType.Decimal:
                case EMaskType.Integer:
                case EMaskType.SignedDecimal:
                case EMaskType.SignedInteger:
                case EMaskType.None:
                default:
                    {
                        this.DefineCustomCss();
                        break;
                    }
            }
        }

        /// <summary>
        /// Método que concatena o css default com o css colocado no aspx.
        /// Se for um postback e já existir o css default no componente, ele não é adicionado novamente.
        /// </summary>
        /// <param name="defaultCss">O default Css</param>
        /// <returns>Css concatenado</returns>
        private string ConcatCss(string defaultCss)
        {
            return this.CssClass.Contains(defaultCss) ? this.CssClass : string.Concat(defaultCss, " ", this.CssClass);
        }

        /// <summary>
        /// Define o css customizado baseado na quantidade de caracteres permitido.
        /// </summary>
        private void DefineCustomCss()
        {
            if (this.MaxLength <= 2)
            {
                this.CssClass = this.ConcatCss("cp_1a2");
            }
            else if (this.MaxLength <= 5)
            {
                this.CssClass = this.ConcatCss("cp_3a5");
            }
            else if (this.MaxLength <= 8)
            {
                this.CssClass = this.ConcatCss("cp_6a8");
            }
            else if (this.MaxLength <= 10)
            {
                this.CssClass = this.ConcatCss("cp_9a10");
            }
            else if (this.MaxLength <= 15)
            {
                this.CssClass = this.ConcatCss("cp_11a15");
            }
            else if (this.MaxLength <= 20)
            {
                this.CssClass = this.ConcatCss("cp_16a20");
            }
            else if (this.MaxLength <= 30)
            {
                this.CssClass = this.ConcatCss("cp_21a30");
            }
            else if (this.MaxLength <= 40)
            {
                this.CssClass = this.ConcatCss("cp_31a40");
            }
            else if (this.MaxLength <= 50)
            {
                this.CssClass = this.ConcatCss("cp_41a50");
            }
            else if (this.MaxLength <= 60)
            {
                this.CssClass = this.ConcatCss("cp_51a60");
            }
            else if (this.MaxLength <= 70)
            {
                this.CssClass = this.ConcatCss("cp_61a70");
            }
            else if (this.MaxLength <= 80)
            {
                this.CssClass = this.ConcatCss("cp_71a80");
            }
            else if (this.MaxLength <= 90)
            {
                this.CssClass = this.ConcatCss("cp_81a90");
            }
            else if (this.MaxLength <= 100)
            {
                this.CssClass = this.ConcatCss("cp_91a100");
            }
            else if (this.MaxLength <= 120)
            {
                this.CssClass = this.ConcatCss("cp_100a120");
            }
            else
            {
                this.CssClass = this.ConcatCss("cp_1a2");
            }
        }

        /// <summary>
        /// Configura a máscara a ser utilizada pelo controle, caso definida.
        /// </summary>
        /// <param name="writer">O escritor HTML.</param>
        private void ConfigureMask(HtmlTextWriter writer)
        {
            if (this.MaskType != EMaskType.None && this.MaskType != EMaskType.Custom)
            {
                writer.AddAttribute("-tbzMsk", string.Format("{0}Mask", this.MaskType));
            }
            else if (this.MaskType == EMaskType.Custom)
            {
                writer.AddAttribute("-tbzCMsk", this.CustomMask);
            }
        }

        /// <summary>
        /// Configura validações pré-definidas.
        /// </summary>
        /// <param name="writer">O escritor HTML.</param>
        private void ConfigureValidation(HtmlTextWriter writer)
        {
            ClientValidation objValidacaoCliente = ControlUtils.CreateClientValidation(this);

            switch (this.ValidationType)
            {
                case EValidationType.CNPJ:
                    {
                        objValidacaoCliente.cnpj = true;
                        break;
                    }
                case EValidationType.CPF:
                    {
                        objValidacaoCliente.cpf = true;
                        break;
                    }
                case EValidationType.Date:
                    {
                        objValidacaoCliente.date = true;
                        break;
                    }
                case EValidationType.HourDay:
                    {
                        objValidacaoCliente.hourDay = true;
                        break;
                    }
                case EValidationType.HourAmount:
                    {
                        objValidacaoCliente.hourAmount = true;
                        break;
                    }
                case EValidationType.Email:
                    {
                        objValidacaoCliente.email = true;
                        break;
                    }
                case EValidationType.None:
                default:
                    {
                        break;
                    }
            }

            if (this.MaskType == EMaskType.Telefone)
            {
                objValidacaoCliente.telefone = true;
            }

            string gOpt = JsonConvert.SerializeObject(objValidacaoCliente, Formatting.None, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });

            if (gOpt != "{}")
            {
                writer.AddAttribute("-tbzValdt", gOpt);
            }
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
                this.ConfigureMask(writer);
                this.ConfigureValidation(writer);
            }

            ControlUtils.ConfigureLabel(writer, this);

            base.Render(writer);

            if (!this.DesignMode)
            {
                writer.WriteEndTag("div");
            }
        }

        #endregion

        #region Eventos

        /// <summary>
        /// Evento pre render.
        /// </summary>
        /// <param name="e">O evento.</param>
        protected override void OnPreRender(EventArgs e)
        {
            this.DefineCss();

            base.OnPreRender(e);
        }

        #endregion
    }
}