using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using Arquitetura.Web.WebControls.JavaScript;
using Newtonsoft.Json;

namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// Componente TRadioButton customizado.
    /// </summary>
    [ToolboxData("<{0}:TCheckBoxList runat=\"server\"></{0}:TCheckBoxList>")]
    public class TCheckBoxList : CheckBoxList, ILabelControl
    {
        #region Construtores

        /// <summary>
        /// Construtor
        /// </summary>
        public TCheckBoxList()
        {
            this.Label = new LabelOptions();
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

        ///// <summary>
        ///// Define as informações de validação do controle.
        ///// </summary>
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Content), PersistenceMode(PersistenceMode.Attribute)]
        //[Description("Define as informações de validação do controle.")]
        //public ValidationOptions Validation
        //{
        //    get
        //    {
        //        return this.ViewState["_!Validation"] as ValidationOptions;
        //    }

        //    private set
        //    {
        //        this.ViewState["_!Validation"] = value;
        //    }
        //}

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

        #region Métodos

        /// <summary>
        /// Método que retorna uma lista de ListItem selecionados do check box.
        /// </summary>
        /// <returns>Items selecionados</returns>
        public List<ListItem> GetSelectedItems()
        {
            List<ListItem> selectedItems = new List<ListItem>();

            if (this.Items != null && this.Items.Count > 0)
            {
                foreach (ListItem item in this.Items)
                {
                    if (item.Selected)
                    {
                        selectedItems.Add(item);
                    }
                }
            }

            return selectedItems;
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

            ControlUtils.ConfigureLabel(writer, this);

            base.Render(writer);

            if (!this.DesignMode)
            {
                writer.WriteEndTag("div");
            }
        }

        ///// <summary>
        ///// Configura a validação do componente
        ///// </summary>
        //private void ConfigureValidation()
        //{
        //    ClientValidation objValidacaoCliente = ControlUtils.CreateClientValidation(this);
        //    objValidacaoCliente.minCheck = 2;
        //    string gOpt = JsonConvert.SerializeObject(objValidacaoCliente, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

        //    if (gOpt != "{}")
        //    {
        //        this.Attributes.Add("-tbzValdt", gOpt);
        //    }
        //}

        #endregion
    }
}
