using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using Arquitetura.TechBiz.Web.Bindables;
using System.Web.UI.HtmlControls;

namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// Classe base para o textbox.
    /// </summary>
    public abstract class TBaseTextBox : TextBox, IValidationControl, ILabelControl, IBindControl
    {
        #region Construtores

        /// <summary>
        /// Construtor
        /// </summary>
        public TBaseTextBox()
        {
            this.Label = new LabelOptions();
            this.Validation = new ValidationOptions();
            this.DataFieldName = string.Empty;
            this.ContainerCssClass = string.Empty;
            this.CustomClientBehavior = string.Empty;
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
        [NotifyParentProperty(true), PersistenceMode(PersistenceMode.Attribute)]
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
        /// Define as informações de validação do controle.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), PersistenceMode(PersistenceMode.Attribute)]
        [Description("Define as informações de validação do controle.")]
        public ValidationOptions Validation
        {
            get
            {
                return this.ViewState["_!Validation"] as ValidationOptions;
            }

            private set
            {
                this.ViewState["_!Validation"] = value;
            }
        }

        /// <summary>
        /// Define as informações do label do controle.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), PersistenceMode(PersistenceMode.Attribute)]
        [Description("Define as informações do label do controle.")]
        public LabelOptions Label
        {
            get
            {
                return this.ViewState["_!Label"] as LabelOptions;
            }

            private set
            {
                this.ViewState["_!Label"] = value;
            }
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Retorna se o campo é nulo.
        /// </summary>
        /// <returns>Se o campo é nulo</returns>
        public bool HasValue()
        {
            return !string.IsNullOrWhiteSpace(this.Text);
        }

        /// <summary>
        /// Define o valor do campo.
        /// </summary>
        /// <param name="value">O valor do campo.</param>
        public void SetValue(object value)
        {
            this.Text = value.ToString();
        }

        /// <summary>
        /// Retorna o valor do campo.
        /// </summary>
        /// <returns>O valor do campo.</returns>
        public object GetValue()
        {
            return this.Text.Trim();
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
            if (this.MaxLength == 0)
            {
                throw new ArgumentNullException(string.Concat(this.ID, "A propriedade MaxLength não pode ter valor 0"));
            }

            base.OnPreRender(e);
        }

        #endregion
    }
}
