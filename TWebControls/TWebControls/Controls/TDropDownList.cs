using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Arquitetura.TechBiz.Web.Bindables;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// Componente TDropDownList customizado.
    /// </summary>
    [ToolboxData("<{0}:TDropDownList runat=\"server\"></{0}:TDropDownList>")]
    public class TDropDownList : DropDownList, IValidationControl, ILabelControl, IBindControl
    {
        #region Construtor

        /// <summary>
        /// Construtor do componente
        /// </summary>
        public TDropDownList()
        {
            this.Label = new LabelOptions();
            this.DataFieldName = string.Empty;
            this.ContainerCssClass = string.Empty;
            this.Validation = new ValidationOptions();
            this.FirstTextItem = "Selecione...";
            this.TextItemTodos = false;
            this.SortItems = false;
        }

        #endregion

        #region Propriedades

        #region Javascript

        /// <summary>
        /// Nome da função javascript que será executada no cliente para alterar algum comportamente da tela.
        /// </summary>
        [Category("Tbiz Client")]
        [DefaultValue("")]
        [Description("Nome da função javascript que será executada no cliente para alterar algum comportamente da tela.")]
        public string CustomClientBehavior
        {
            get
            {
                return this.ViewState["_!ClientBehaviorFuncion"].ToString();
            }
            set
            {
                this.ViewState["_!ClientBehaviorFuncion"] = value;
            }
        }

        #endregion


        /// <summary>
        /// Gets or sets Define o nome da propriedade que este campo será bindado.
        /// </summary>
        [Category("Tbiz")]
        [DefaultValue("")]
        [Description("Define o nome da propriedade que este campo será bindado")]
        public string DataFieldName
        {
            get
            {
                return this.ViewState["_!fieldName"].ToString();
            }

            set
            {
                this.ViewState["_!fieldName"] = value;
            }
        }

        /// <summary>
        /// Gets or sets Define a Classe CSS para a DIV que contém todos os controles.
        /// </summary>
        [Category("Tbiz")]
        [CssClassProperty]
        [NotifyParentProperty(true), PersistenceMode(PersistenceMode.Attribute)]
        [DefaultValue("")]
        [Description("Define a Classe CSS para a DIV que contém todos os controles.")]
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
        /// Gets or sets Define a Classe CSS para a DIV que contém todos os controles de TTextBox.
        /// </summary>
        [Category("Tbiz")]
        [NotifyParentProperty(true), PersistenceMode(PersistenceMode.Attribute)]
        [DefaultValue("Selecione...")]
        [Description("Define o text do primeiro item para o DropDown. Default: Selecione...")]
        public string FirstTextItem
        {
            get
            {
                return this.ViewState["_!DefaultTextItem"].ToString();
            }

            set
            {
                this.ViewState["_!DefaultTextItem"] = value;
            }
        }

        /// <summary>
        /// Define a Classe CSS para a DIV que contém todos os controles de TTextBox.
        /// </summary>
        [Category("Tbiz")]
        [NotifyParentProperty(true), PersistenceMode(PersistenceMode.Attribute)]
        [DefaultValue(false)]
        [Description("Exibir o item Todos, default value = -1.")]
        public bool TextItemTodos
        {
            get;
            set;
        }

        /// <summary>
        /// Define a Classe CSS para a DIV que contém todos os controles de TTextBox.
        /// </summary>
        [Category("Tbiz")]
        [NotifyParentProperty(true), PersistenceMode(PersistenceMode.Attribute)]
        [DefaultValue(false)]
        [Description("Ordenar os items do DropDownList pelo text")]
        public bool SortItems
        {
            get;
            set;
        }

        /// <summary>
        /// Gets Define o label do controle.
        /// </summary>
        [Category("Tbiz Label")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), PersistenceMode(PersistenceMode.Attribute)]
        [Description("Define a Classe com as informações do Label.")]
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

        /// <summary>
        /// Gets Define a validação do controle.
        /// </summary>
        [Category("Tbiz Validation")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), PersistenceMode(PersistenceMode.Attribute)]
        [Description("Define a classe com as informações de validação.")]
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

        #endregion

        #region Métodos

        /// <summary>
        /// Somente para manter a compatiblidade com a interface
        /// </summary>
        /// <returns>True / False</returns>
        public bool HasValue()
        {
            return this.SelectedIndex >= 0 && !String.IsNullOrEmpty(this.SelectedValue);
        }

        /// <summary>
        /// Define o valor do campo
        /// </summary>
        /// <param name="valor">Valor a Setar</param>
        public void SetValue(object valor)
        {
            //Para o bind automático é preciso verificar se o valor não é Zero pois as propriedade do tipo int o 0 é o default
            if (valor.Equals(0))
            {
                return;
            }

            this.SelectedValue = valor.ToString();
        }

        /// <summary>
        /// Retorna o valor informado pelo usuário
        /// </summary>
        /// <returns>Object value</returns>
        public object GetValue()
        {
            if (String.IsNullOrEmpty(this.SelectedValue))
            {
                return null;
            }

            return this.SelectedValue;
        }

        /// <summary>
        /// Método que ordena os itens do DropDown pelo text.
        /// </summary>
        private void Sort()
        {
            List<ListItem> itemsOrdenados = new List<ListItem>();

            foreach (ListItem item in this.Items)
            {
                itemsOrdenados.Add(item);
            }

            this.Items.Clear();

            this.Items.AddRange(itemsOrdenados.OrderBy(x => x.Text).ToArray());
        }

        /// <summary>
        /// Método que adiciona os items default do dropdown
        /// </summary>
        private void AddDefaultItems()
        {
            if (this.TextItemTodos)
            {
                this.Items.Insert(0, new ListItem() { Text = "Todos", Value = "-1" });
                this.SelectedIndex = 0;
            }

            if (!string.IsNullOrEmpty(this.FirstTextItem))
            {
                this.Items.Insert(0, new ListItem() { Text = this.FirstTextItem, Value = string.Empty });
                this.SelectedIndex = 0;
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
        /// Renderiza o componente.
        /// </summary>
        /// <param name="writer">O escritor HTML.</param>
        protected override void Render(HtmlTextWriter writer)
        {
            if (!this.DesignMode)
            {
                ControlUtils.ConfigureDivContainer(writer, this);

                Arquitetura.Web.WebControls.JavaScript.ClientValidation objValidacaoCliente = ControlUtils.CreateClientValidation(this);

                var jsonSerializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    NullValueHandling = NullValueHandling.Ignore
                };

                string gOpt = JsonConvert.SerializeObject(objValidacaoCliente, Formatting.None, jsonSerializerSettings);

                if (gOpt != "{}")
                {
                    writer.AddAttribute("-tbzValdt", gOpt);
                }
            }

            ControlUtils.ConfigureLabel(writer, this);

            base.Render(writer);

            // Fecha a tag do configure div container
            if (!this.DesignMode)
            {
                writer.WriteEndTag("div");
            }
        }

        /// <summary>
        /// Override do evento OnPreRender.
        /// </summary>
        /// <param name="e">Argumento do evento.</param>
        protected override void OnPreRender(System.EventArgs e)
        {
            base.OnPreRender(e);

            if (this.DataSource == null && this.Items.Count > 0)
            {
                if (this.SortItems)
                {
                    this.Sort();
                }

                if (!this.Page.IsPostBack)
                {
                    this.AddDefaultItems();
                }
            }
            else if (this.DataSource == null && this.Items.Count == 0)
            {
                if (!this.Page.IsPostBack)
                {
                    this.AddDefaultItems();
                }
            }
        }

        /// <summary>
        /// Override do DataBind para setar o valor default.
        /// </summary>
        public override void DataBind()
        {
            base.DataBind();

            if (this.SortItems)
            {
                this.Sort();
            }

            this.AddDefaultItems();
        }

        #endregion
    }
}