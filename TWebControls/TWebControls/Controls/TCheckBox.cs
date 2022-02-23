using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using Arquitetura.TechBiz.Web.Bindables;

namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// Componente TCheckBox customizado.
    /// </summary>
    [ToolboxData("<{0}:TCheckBox runat=\"server\"></{0}:TCheckBox>")]
    public class TCheckBox : CheckBox, ITControl, IBindControl
    {
        #region Construtores

        /// <summary>
        /// Construtor
        /// </summary>
        public TCheckBox()
        {
            this.DataFieldName = string.Empty;
            this.ContainerCssClass = string.Empty;
            this.ValueCheckedFalse = "0";
            this.ValueCheckedTrue = "1";
            this.CssClass = "checkboxClass";
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

        #endregion

        #region Métodos

        /// <summary>
        /// Retorna se o campo é nulo.
        /// </summary>
        /// <returns>Se o campo é nulo</returns>
        public bool HasValue()
        {
            //O checkbox sempre tem valor
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

        #endregion
    }
}
