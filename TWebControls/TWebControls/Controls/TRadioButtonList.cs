﻿using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using Arquitetura.TechBiz.Web.Bindables;

namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// Controle TRadioButtonList customizado.
    /// </summary>
    [ToolboxData("<{0}:TRadioButtonList runat=\"server\"></{0}:TRadioButtonList>")]
    public class TRadioButtonList : RadioButtonList, IValidationControl, ILabelControl, IBindControl
    {
        #region Contrutores

        /// <summary>
        /// Construtor
        /// </summary>
        public TRadioButtonList()
        {
            this.Label = new LabelOptions();
            this.Validation = new ValidationOptions();
            this.DataFieldName = string.Empty;
            this.ContainerCssClass = string.Empty;
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
        /// Define o valor do campo.
        /// </summary>
        /// <param name="valor">O valor do campo.</param>
        public void SetValue(object valor)
        {
            //if (valor.Equals(0))
            //{
            //    return;
            //}

            this.SelectedValue = valor.ToString();
        }

        /// <summary>
        /// Retorna o valor do campo.
        /// </summary>
        /// <returns>O valor do campo.</returns>
        public object GetValue()
        {
            return this.SelectedValue;
        }

        /// <summary>
        /// Retorna se o campo é nulo.
        /// </summary>
        /// <returns>Se o campo é nulo</returns>
        public bool HasValue()
        {
            return this.SelectedIndex >= 0;
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
        /// <param name="writer">writer</param>
        protected override void Render(HtmlTextWriter writer)
        {
            if (!this.DesignMode)
            {
                ControlUtils.ConfigureDivContainer(writer, this);
            }

            ControlUtils.ConfigureLabel(writer, this);

            base.Render(writer);

            if (!this.DesignMode)
            {
                writer.WriteEndTag("div");
            }
        }

        #endregion
    }
}
