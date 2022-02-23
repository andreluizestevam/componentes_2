using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Web.UI.HtmlControls;

namespace Arquitetura.Web.WebControls.Grid
{
    /// <summary>
    /// Classe para gerar o grid do jquery
    /// </summary>
    public struct GridSettings
    {
        private bool editavel;
        private bool formEditCustomizado;

        /// <summary>
        /// Caso informado o grid será editado em um form customizado que receberá a pk do registro que está sendo utilizado
        /// </summary>
        public bool FormEditCustomizado
        {
            get
            {
                return formEditCustomizado;
            }
            set
            {
                formEditCustomizado = value;
                if (!formEditCustomizado)
                {
                    GridOptionsValues.EditOptions.beforeShowForm = null;
                }
            }
        }

        /// <summary>
        /// Indica se o Grid pode ser editado
        /// </summary>
        public bool Editavel
        {
            get
            {
                return editavel;
            }
            set
            {
                editavel = value;
                if (editavel)
                {
                    GridOptionsValues.PagerOptions.Add = editavel;
                    GridOptionsValues.PagerOptions.Del = editavel;
                    GridOptionsValues.PagerOptions.Edit = editavel;
                }
            }
        }

        /// <summary>
        /// Propriedade
        /// </summary>
        public TGrid GridOptionsValues { get; set; }

        /// <summary>
        /// Informa se o grid será editado via formulário ou na linha do grid mesmo
        /// </summary>
        public bool EditInLine { get; set; }

        /// <summary>
        /// Tamanho do grid
        /// </summary>
        public int Width { get; set; }
    }

    /// <summary>
    /// Classe de opções do grid, como ela é serializada para javascript as propriedade tem que ser minusculas
    /// </summary>
    [ToolboxData("<{0}:TGrid runat=\"server\"></{0}:TGrid>")]
    public class TGrid : Panel
    {
        /// <summary>
        /// Url a ser chamada pelo jquery para requisiçoes no servidor
        /// </summary>
        public string DataSourceUrl { get; set; }

        /// <summary>
        /// Modelo que define as propriedades das colunas
        /// </summary>
        public List<TGridColModel> Columns { get; set; }

        /// <summary>
        /// Número da row
        /// </summary>
        public int RowNum { get; set; }

        /// <summary>
        /// Lista de registros a serem exibidos no grid
        /// </summary>
        public List<int> RowList { get; set; }

        /// <summary>
        /// Pagina que está sendo exibida
        /// </summary>
        public string Pager { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool ViewRecords { get; set; }

        /// <summary>
        /// Url para chamar os dados da adicionar
        /// </summary>
        public string AddUrl { get; set; }

        /// <summary>
        /// Url para chamar os dados da edição
        /// </summary>
        public string EditUrl { get; set; }

        /// <summary>
        /// Url para chamar os dados da exclusão
        /// </summary>
        public string DelUrl { get; set; }

        /// <summary>
        /// Caption do grid
        /// </summary>
        public String Caption { get; set; }

        /// <summary>
        /// Coluna de orndenação
        /// </summary>
        public String SortName { get; set; }

        /// <summary>
        /// Ordem da ordenação ASC DESC
        /// </summary>
        public String SortOrder { get; set; }

        /// <summary>
        /// Permitir seleção múltipla
        /// </summary>
        public bool MultiSelect { get; set; }

        /// <summary>
        /// Opções da paginação
        /// </summary>
        public TGridPagerOption PagerOptions { get; set; }

        /// <summary>
        /// Opções da edição do grid
        /// </summary>
        public TGridEditOptions EditOptions { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool AutoWidth { get; set; }
        /// <summary>
        /// Construtor
        /// </summary>
        public TGrid()
        {
            this.PagerOptions = new TGridPagerOption();
            this.RowNum = 10;

            this.MultiSelect = false;
            this.RowList = new List<int>() { 10, 20, 30 };
            this.ViewRecords = true;
            this.SortOrder = "asc";
            this.AutoWidth = true;
            this.Columns = new List<TGridColModel>();
        }


        private string ToJson()
        {
            List<string> colNames = new List<string>();
            this.Columns.ForEach(x => colNames.Add(x.Name));

            var gridOptions = new
            {
                datatype = "json",
                colNames = colNames,
                colModel = this.Columns,
                rowNum = this.RowNum,
                rowList = this.RowList,
                caption = this.Caption,
                sortorder = this.SortOrder,
                sortname = this.SortName,
                viewrecords = this.ViewRecords,
                height = "100%",
                sortName = this.Columns[0].Name,
                url = this.DataSourceUrl
            };

            var jsonSerializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    NullValueHandling = NullValueHandling.Ignore
                };

            string gOpt = JsonConvert.SerializeObject(gridOptions, Formatting.None, jsonSerializerSettings);

            return gOpt;
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            string jsFunction = string.Concat("$(document).ready(function(){$('#", string.Concat("grid-", this.ID), "').jqGrid(", this.ToJson(), ");});");

            //this.Page.ClientScript.RegisterClientScriptBlock(typeof(String), string.Concat("grid", this.ID), jsFunction, true);
        }

        protected override void Render(HtmlTextWriter writer)
        {
            //Grid
            this.Controls.Add(new HtmlTable
            {
                ID = string.Concat("grid-", this.ID),
                ClientIDMode = System.Web.UI.ClientIDMode.Static
            });

            //Paginação
            this.Controls.Add(new Panel
            {
                ID = string.Concat("pager-", this.ID),
                ClientIDMode = System.Web.UI.ClientIDMode.Static
            });
            
            base.Render(writer);
        }
    }
}
