using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// Componente TMultiSelect customizado.
    /// </summary>
    [ToolboxData("<{0}:TMultiSelect runat=\"server\"></{0}:TMultiSelect>")]
    public class TMultiSelect : Panel, ITControl
    {
        #region Atributos

        /// <summary>
        /// List box de origem(Esquerda)
        /// </summary>
        private ListBox avaliableList;

        /// <summary>
        /// List box de destino(Direita)
        /// </summary>
        private ListBox selectedList;

        /// <summary>
        /// Botão vai um registro para o destino
        /// </summary>
        private HtmlButton btnRightOne;

        /// <summary>
        /// Botão vai todos registros para o destino
        /// </summary>
        private HtmlButton btnRightAll;

        /// <summary>
        /// Botão volta um registro para a origem
        /// </summary>
        private HtmlButton btnLeftOne;

        /// <summary>
        /// Botão volta todos os registros para a origem
        /// </summary>
        private HtmlButton btnLeftAll;

        /// <summary>
        /// Hidden field que armazena os values selecionados.
        /// </summary>
        private HiddenField hdn;

        /// <summary>
        /// Armazena se ja foi movido ou não os items.
        /// TODO: Não está legal. Recomendo utilizar o evento OnLoadComplete para carregar os itens selecionados.
        /// </summary>
        private bool moved = false;

        #endregion

        #region Construtores

        /// <summary>
        /// Construtor
        /// </summary>
        public TMultiSelect()
        {
            this.LabelAvaliableList = new LabelOptions();
            this.LabelSelectedList = new LabelOptions();
            this.ContainerCssClass = string.Empty;
            this.RowsListBox = 4;
            this.TextField = string.Empty;
            this.ValueField = string.Empty;
            this.AutoTransfer = false;
            this.ReadOnly = false;
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
        /// Define as informações do label de items disponíveis.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), PersistenceMode(PersistenceMode.Attribute)]
        [Description("Define as informações do label de items disponíveis.")]
        public LabelOptions LabelAvaliableList
        {
            get
            {
                return this.ViewState["_!LabelAvaliableList"] as LabelOptions;
            }
            private set
            {
                this.ViewState["_!LabelAvaliableList"] = value;
            }
        }

        /// <summary>
        /// Define as informações do label de items selecionados.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), PersistenceMode(PersistenceMode.Attribute)]
        [Description("Define as informações do label de items selecionados.")]
        public LabelOptions LabelSelectedList
        {
            get
            {
                return this.ViewState["_!LabelSelectedList"] as LabelOptions;
            }
            private set
            {
                this.ViewState["_!LabelSelectedList"] = value;
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
        /// Define o dataSource do ListBox de items disponíveis.
        /// </summary>
        [Category("Tbiz Data")]
        [NotifyParentProperty(true), PersistenceMode(PersistenceMode.Attribute)]
        [DefaultValue(null)]
        [Description("Define o dataSource do ListBox de items disponíveis.")]
        public object DataSourceAvaliable
        {
            get
            {
                return this.ViewState["_!DataSourceAvaliable"];
            }
            set
            {
                this.ViewState["_!DataSourceAvaliable"] = value;
            }
        }

        /// <summary>
        /// Define o TextField dos ListBox de items disponíveis e de items selecionados.
        /// </summary>
        [Category("Tbiz Data")]
        [NotifyParentProperty(true), PersistenceMode(PersistenceMode.Attribute)]
        [DefaultValue("")]
        [Description("Define o TextField dos ListBox de items disponíveis e de items selecionados.")]
        public string TextField
        {
            get
            {
                return this.ViewState["_!TextField"].ToString();
            }
            set
            {
                this.ViewState["_!TextField"] = value;
            }
        }

        /// <summary>
        /// Define o ValueField dos ListBox de items disponíveis e items selecionados.
        /// </summary>
        [Category("Tbiz Data")]
        [NotifyParentProperty(true), PersistenceMode(PersistenceMode.Attribute)]
        [DefaultValue("")]
        [Description("Define o ValueField dos ListBox de items disponíveis e items selecionados.")]
        public string ValueField
        {
            get
            {
                return this.ViewState["_!ValueField"].ToString();
            }
            set
            {
                this.ViewState["_!ValueField"] = value;
            }
        }

        /// <summary>
        /// Define o dataSource do ListBox de items selecionados.
        /// </summary>
        [Category("Tbiz Data")]
        [NotifyParentProperty(true), PersistenceMode(PersistenceMode.Attribute)]
        [DefaultValue(null)]
        [Description("Define o dataSource do ListBox de items selecionados.")]
        public object DataSourceSelected
        {
            get
            {
                return this.ViewState["_!DataSourceSelected"];
            }
            set
            {
                this.ViewState["_!DataSourceSelecionados"] = value;
            }
        }

        /// <summary>
        /// GDefine a quantidade de linhas dos ListBoxes.
        /// </summary>
        [Category("Tbiz Appearance")]
        [NotifyParentProperty(true), PersistenceMode(PersistenceMode.Attribute)]
        [DefaultValue(4)]
        [Description("Define a quantidade de linhas dos ListBoxes.")]
        public int RowsListBox
        {
            get
            {
                return int.Parse(this.ViewState["_!RowsListBox"].ToString());
            }
            set
            {
                this.ViewState["_!RowsListBox"] = value;
            }
        }

        /// <summary>
        /// Gets or sets Transfere automaticamente para selecionado se tiver somente um item disponível.
        /// </summary>
        [Category("Tbiz Behavior")]
        [NotifyParentProperty(true), PersistenceMode(PersistenceMode.Attribute)]
        [DefaultValue(false)]
        [Description("Transfere automaticamente para selecionado se tiver somente um item disponível.")]
        public bool AutoTransfer
        {
            get
            {
                return Convert.ToBoolean(this.ViewState["_!AutoTransfer"].ToString());
            }
            set
            {
                this.ViewState["_!AutoTransfer"] = value;
            }
        }

        /// <summary>
        /// Define o modo de visualização do controle.
        /// </summary>
        [Category("Tbiz Behavior")]
        [NotifyParentProperty(true), PersistenceMode(PersistenceMode.Attribute)]
        [DefaultValue(false)]
        [Description("Define o modo de visualização do controle.")]
        public bool ReadOnly
        {
            get
            {
                return Convert.ToBoolean(this.ViewState["_!ReadOnly"].ToString());
            }
            set
            {
                this.ViewState["_!ReadOnly"] = value;
            }
        }

        /// <summary>
        /// Itens selecionados do listbox
        /// </summary>
        [Browsable(false)]
        public ListItemCollection Selecteds
        {
            get
            {
                if (!this.moved)
                {
                    this.MoveItems();
                    this.moved = true;
                }

                return this.selectedList.Items;
            }
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Limpa os ListBoxes.
        /// </summary>
        public void Clear()
        {
            this.avaliableList.Items.Clear();
            this.selectedList.Items.Clear();
        }

        /// <summary>
        /// Configura o label do controle.
        /// </summary>
        /// <param name="listBox">O listBox que necessita de label.</param>
        /// <param name="label">O label com o text.</param>
        public void ConfigureLabel(ListBox listBox, LabelOptions label)
        {
            HtmlGenericControl lbl = new HtmlGenericControl("label");
            lbl.InnerText = label.LabelText;
            lbl.Attributes.Add("for", listBox.ID);
            lbl.Attributes.Add("class", string.IsNullOrEmpty(label.LabelCssClass) ? "labelClass" : label.LabelCssClass);
            this.Controls.Add(lbl);
        }

        /// <summary>
        /// Método que adiciona os controles de listboxes e botões.
        /// </summary>
        private void AddControls()
        {
            this.avaliableList = new ListBox();
            this.avaliableList.CssClass = "multiListAvaliable";
            this.avaliableList.ID = "multiListAvaliable";
            this.avaliableList.SelectionMode = ListSelectionMode.Multiple;
            this.avaliableList.Rows = this.RowsListBox;

            if (this.LabelAvaliableList.ShowLabel)
            {
                this.ConfigureLabel(this.avaliableList, this.LabelAvaliableList);
            }

            this.Controls.Add(this.avaliableList);

            this.btnRightOne = new HtmlButton();
            this.btnRightOne.InnerText = ">";
            this.btnRightOne.Attributes.Add("class", "btnRightOne multiListButtons");
            this.Controls.Add(this.btnRightOne);

            this.btnRightAll = new HtmlButton();
            this.btnRightAll.InnerText = ">>";
            this.btnRightAll.Attributes.Add("class", "btnRightAll multiListButtons");
            this.Controls.Add(this.btnRightAll);

            this.btnLeftAll = new HtmlButton();
            this.btnLeftAll.InnerText = "<<";
            this.btnLeftAll.Attributes.Add("class", "btnLeftAll multiListButtons");
            this.Controls.Add(this.btnLeftAll);

            this.btnLeftOne = new HtmlButton();
            this.btnLeftOne.InnerText = "<";
            this.btnLeftOne.Attributes.Add("class", "btnLeftOne multiListButtons");
            this.Controls.Add(this.btnLeftOne);

            this.selectedList = new ListBox();
            this.selectedList.CssClass = "multiListSelected";
            this.selectedList.ID = "multiListSelected";
            this.selectedList.Rows = this.RowsListBox;
            this.selectedList.SelectionMode = ListSelectionMode.Multiple;

            if (this.LabelSelectedList.ShowLabel)
            {
                this.ConfigureLabel(this.selectedList, this.LabelSelectedList);
            }

            this.Controls.Add(this.selectedList);

            this.hdn = new HiddenField();
            this.hdn.ID = string.Concat(this.ID, "_hdnSel");
            this.hdn.ClientIDMode = System.Web.UI.ClientIDMode.Static;

            this.Controls.Add(this.hdn);
        }

        /// <summary>
        /// Método que move os items selecionados.
        /// </summary>
        private void MoveItems()
        {
            if (!string.IsNullOrEmpty(this.hdn.Value))
            {
                string[] values = this.hdn.Value.Remove(0, 1).Split(',');

                List<ListItem> items = new List<ListItem>();

                foreach (ListItem item in this.avaliableList.Items)
                {
                    items.Add(item);
                }

                foreach (ListItem item in this.selectedList.Items)
                {
                    items.Add(item);
                }

                this.avaliableList.Items.Clear();
                this.selectedList.Items.Clear();

                foreach (string item in values)
                {
                    ListItem encontrado = items.Find(x => x.Value == item);

                    if (encontrado != null)
                    {
                        this.selectedList.Items.Add(encontrado);
                        items.Remove(encontrado);
                    }
                }

                this.avaliableList.Items.AddRange(items.ToArray());
            }
            else
            {
                ListItemCollection items = this.selectedList.Items;

                foreach (ListItem item in items)
                {
                    this.avaliableList.Items.Add(item);
                }

                this.selectedList.Items.Clear();
            }
        }

        /// <summary>
        /// Método que desabilita os componentes.
        /// </summary>
        /// <param name="disable">Desabilitar?</param>
        private void Disable(bool disable = true)
        {
            this.btnLeftAll.Disabled = disable;
            this.btnLeftOne.Disabled = disable;
            this.btnRightAll.Disabled = disable;
            this.btnRightOne.Disabled = disable;
        }

        /// <summary>
        /// Evento override do DataBind que preenche os listboxes caso tenha sido preenchido os datasource's
        /// </summary>
        public override void DataBind()
        {
            base.DataBind();

            this.avaliableList.DataSource = this.DataSourceAvaliable;
            this.avaliableList.DataTextField = this.TextField;
            this.avaliableList.DataValueField = this.ValueField;
            this.avaliableList.DataBind();

            this.selectedList.DataTextField = this.TextField;
            this.selectedList.DataValueField = this.ValueField;

            if (this.DataSourceSelected != null)
            {
                this.selectedList.DataSource = this.DataSourceSelected;
                this.selectedList.DataBind();
            }

            if (this.AutoTransfer)
            {
                // Caso só tenha um item na origem o mesmo é transferido para destino e o controle é desabilitado
                if (this.avaliableList.Items.Count == 1)
                {
                    if (this.selectedList.Items.Count == 0)
                    {
                        ListItem item = this.avaliableList.Items[0];

                        this.selectedList.Items.Add(item);
                        this.avaliableList.Items.Clear();

                        this.Disable();
                    }
                    else
                    {
                        this.Disable(false);
                    }
                }
                else
                {
                    this.Disable(false);
                }
            }

            if (this.avaliableList.Items.Count == 0 && this.selectedList.Items.Count <= 1)
            {
                this.Disable();
            }
            else
            {
                this.Disable(false);
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
            }

            base.Render(writer);

            if (!this.DesignMode)
            {
                writer.WriteEndTag("div");
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
            this.AddControls();
        }

        /// <summary>
        /// Evento pre render.
        /// </summary>
        /// <param name="e">AO evento.</param>
        protected override void OnPreRender(EventArgs e)
        {
            if (this.moved == false)
            {
                this.MoveItems();
            }

            this.moved = false;

            base.OnPreRender(e);
        }

        #endregion
    }
}
