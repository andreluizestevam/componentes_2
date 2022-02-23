using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using Arquitetura.TechBiz.Web.Bindables;
using Arquitetura.Web.WebControls.JavaScript;
using Newtonsoft.Json;

namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// Componente TRadioButton customizado.
    /// </summary>
    [ToolboxData("<{0}:TRadioButton runat=\"server\"></{0}:TRadioButton>")]
    public class TRadioButton : RadioButton, ITControl, IValidationControl, IBindControl
    {
        #region Construtores

        /// <summary>
        /// Construtor
        /// </summary>
        public TRadioButton()
        {
            this.DataFieldName = string.Empty;
            this.ContainerCssClass = string.Empty;
            //this.Validation = new ValidationOptions();
            this.ValueCheckedFalse = "0";
            this.ValueCheckedTrue = "1";
            this.CssClass = "radioButtonClass";
        }

        #endregion

        #region Propriedades

        /// <summary>
        /// Define um método client-side (javascript) customizado a ser usado no controle.
        /// </summary>
        [Category("Tbiz Behavior")]
        [DefaultValue("")]
        [Description("Define um método client-side (javascript) customizado a ser usado no controle.")]
        public string CustomClientBehavior
        {
            get
            {
                return this.ViewState["_!CustomClientBehavior"].ToString();
            }
            set
            {
                this.ViewState["_!CustomClientBehavior"] = value;
            }
        }

        /// <summary>
        /// Define o nome do campo de dados para fazer o bind automático.
        /// </summary>
        [Category("Tbiz Data")]
        [DefaultValue("")]
        [Description("Define o nome do campo de dados para fazer o bind automático.")]
        public string DataFieldName
        {
            get
            {
                return this.ViewState["_!DataFieldName"].ToString();
            }
            set
            {
                this.ViewState["_!DataFieldName"] = value;
            }
        }

        /// <summary>
        /// Define o css que será usado na DIV container do controle.
        /// </summary>
        [Category("Tbiz Appearance")]
        [CssClassProperty]
        [NotifyParentProperty(true), PersistenceMode(PersistenceMode.Attribute)]
        [DefaultValue("")]
        [Description("Define o css que será usado na DIV container do controle.")]
        public string ContainerCssClass
        {
            get
            {
                return this.ViewState["_!ContainerCssClass"].ToString();
            }
            set
            {
                this.ViewState["_!ContainerCssClass"] = value;
            }
        }

        /// <summary>
        /// Define o valor Não Checked.
        /// </summary>
        [Category("Tbiz")]
        [NotifyParentProperty(true), PersistenceMode(PersistenceMode.Attribute)]
        [DefaultValue("0")]
        [Description("Define o valor Não Checked.")]
        public string ValueCheckedFalse
        {
            get
            {
                return this.ViewState["_!ValueFalse"].ToString();
            }
            set
            {
                this.ViewState["_!ValueFalse"] = value;
            }
        }

        /// <summary>
        /// Define o valor Checked.
        /// </summary>
        [Category("Tbiz")]
        [NotifyParentProperty(true), PersistenceMode(PersistenceMode.Attribute)]
        [DefaultValue("1")]
        [Description("Define o valor Checked.")]
        public string ValueCheckedTrue
        {
            get
            {
                return this.ViewState["_!ValueTrue"].ToString();
            }
            set
            {
                this.ViewState["_!ValueTrue"] = value;
            }
        }

        /// <summary>
        /// Define as informações de validação do controle.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), PersistenceMode(PersistenceMode.Attribute)]
        [Description("Define as informações de validação do controle.")]
        public ValidationOptions Validation
        {
            get
            {
                if (this.ViewState["_!Validation"] == null)
                {
                    this.ViewState["_!Validation"] = new ValidationOptions();
                }

                return this.ViewState["_!Validation"] as ValidationOptions;
            }
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Retorna se o campo é nulo.
        /// </summary>
        /// <returns>Se o campo é nulo</returns>
        public bool HasValue()
        {
            //Radio sempre tem valor
            return true;
        }

        /// <summary>
        /// Define o valor do campo.
        /// </summary>
        /// <param name="value">O valor do campo.</param>
        public void SetValue(object value)
        {
            if (value is bool)
            {
                this.Checked = bool.Parse(value.ToString());
            }
            else
            {
                if (value.ToString() == this.ValueCheckedTrue)
                {
                    this.Checked = true;
                }
                else if (value.ToString() == this.ValueCheckedFalse)
                {
                    this.Checked = false;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        /// <summary>
        /// Retorna o valor do campo.
        /// </summary>
        /// <returns>O valor do campo.</returns>
        public object GetValue()
        {
            return this.Checked ? this.ValueCheckedTrue : this.ValueCheckedFalse;
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
            }

            base.Render(writer);

            if (!this.DesignMode)
            {
                writer.WriteEndTag("div");
            }
        }

        /// <summary>
        /// Configura a validação do componente
        /// </summary>
        private void ConfigureValidation()
        {
            ClientValidation objValidacaoCliente = ControlUtils.CreateClientValidation(this);

            string gOpt = JsonConvert.SerializeObject(objValidacaoCliente, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
           
            if (gOpt != "{}")
            {
                this.InputAttributes.Add("-tbzValdt", gOpt);
            }
        }

        #endregion

        #region Eventos

        /// <summary>
        /// Método ao incializar a página para registrar os scripts e css
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            ControlUtils.RegisterStaticFiles(this.GetType(), this.Page);

            base.OnInit(e);
        }


        /// <summary>
        /// Evento pre render.
        /// </summary>
        /// <param name="e">O evento.</param>
        protected override void OnPreRender(EventArgs e)
        {
            this.ConfigureValidation();
            base.OnPreRender(e);
        }

        #endregion
    }
}
