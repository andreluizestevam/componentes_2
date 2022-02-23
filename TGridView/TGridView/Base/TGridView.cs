using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Arquitetura.TechBiz.BS;
using Arquitetura.TechBiz.Utils;

namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// Componente que customiza o GridView.
    /// </summary>
    [ToolboxData("<{0}:TGridView runat=\"server\"></{0}:TGridView>")]
    public sealed class TGridView : GridView
    {
        #region Atributos

        /// <summary>
        /// Atributo para reflection do método interno do GridView
        /// </summary>
        private MethodInfo _methodInfo = typeof(GridView).GetMethod("BuildCallbackArgument", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.CreateInstance, null, new Type[] { typeof(int) }, null);

        /// <summary>
        /// Atributo para reflection do propriedadeinterno do GridView
        /// </summary>
        private PropertyInfo _propInfoSortExpression = typeof(GridView).GetProperty("SortExpressionInternal", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.CreateInstance);

        /// <summary>
        /// Atributo para reflection do propriedadeinterno do GridView
        /// </summary>
        private PropertyInfo _propInfoSortDirection = typeof(GridView).GetProperty("SortDirectionInternal", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.CreateInstance);

        /// <summary>
        /// Indica se o grid é um bussines service
        /// </summary>
        private bool isEnumerable;

        #endregion


        #region Propriedades

        /// <summary>
        /// Propriedade para modo da paginação customizado
        /// </summary>
        [Browsable(true)]
        [Category("Paging")]
        [DefaultValue(TPagerButtons.NumericNextPrevious)]
        public TPagerButtons CustomPagerMode
        {
            get
            {
                if (this.ViewState["_!CustomPagerMode"] == null)
                {
                    this.PagerSettings.Mode = PagerButtons.Numeric;
                    this.ViewState["_!CustomPagerMode"] = TPagerButtons.NumericNextPrevious;
                }

                return (TPagerButtons)this.ViewState["_!CustomPagerMode"];
            }
            set
            {
                this.ViewState["_!CustomPagerMode"] = value;

                if (value == TPagerButtons.NextPrevious
                    || value == TPagerButtons.Numeric
                    || value == TPagerButtons.NextPreviousFirstLast
                    || value == TPagerButtons.NumericFirstLast)
                {
                    this.PagerSettings.Mode = (PagerButtons)EnumUtil.GetValor(value);
                }
            }
        }

        /// <summary>
        /// Propriedade para habilitar cache da fonte de dados.
        /// </summary>
        [Browsable(true)]
        [Category("Behavior")]
        [DefaultValue(false)]
        public bool EnableCaching
        {
            get
            {
                return Convert.ToBoolean(this.ViewState["_!EnableCaching"]);
            }
            set
            {
                this.ViewState["_!EnableCaching"] = value;
            }
        }

        /// <summary>
        /// Propriedade para habilitar cache da fonte de dados.
        /// </summary>
        [Browsable(true)]
        [Category("Behavior")]
        [DefaultValue(false)]
        public bool ShowInfraeroHeader
        {
            get
            {
                return Convert.ToBoolean(this.ViewState["_!ShowInfraeroHeader"]);
            }
            set
            {
                this.ViewState["_!ShowInfraeroHeader"] = value;
            }
        }



        /// <summary>
        /// Propriedade para habilitar a exibição de grupos (...) da paginação
        /// </summary>
        [Browsable(true)]
        [Category("Paging")]
        [DefaultValue(true)]
        public bool CustomPagerShowDots
        {
            get
            {
                return (bool)this.ViewState["_!CustomPagerShowDots"];
            }
            set
            {
                this.ViewState["_!CustomPagerShowDots"] = value;
            }
        }

        /// <summary>
        /// Propriedade para a fonte de dados
        /// </summary>
        [Browsable(true)]
        [Category("Data")]
        [DefaultValue("")]
        public override object DataSource
        {
            get
            {
                return this.EnableCaching ? this.ViewState["_!DataSourceObj"] : base.DataSource;
            }
            set
            {
                if (EnableCaching)
                {
                    this.ViewState["_!DataSourceObj"] = value;
                }

                base.DataSource = value;
            }
        }


        /// <summary>
        /// Usada para armazenar o CustomSortDirection
        /// </summary>
        [Browsable(false)]
        public SortDirection CustomSortDirection
        {
            get
            {
                return (SortDirection)this.ViewState["_!CustomSortDirection"];
            }
            set
            {
                this.ViewState["_!CustomSortDirection"] = value;
            }
        }

        /// <summary>
        /// Propriedade para armazenar o CustomSortExpression
        /// </summary>
        [Browsable(false)]
        public string CustomSortExpression
        {
            get
            {
                return this.ViewState["_!CustomSortExpression"].ToString();
            }
            set
            {
                this.ViewState["_!CustomSortExpression"] = value;
            }
        }

        #endregion

        /// <summary>
        /// Construtor
        /// </summary>
        public TGridView()
        {
            this.CustomSortDirection = SortDirection.Ascending;
            this.CustomSortExpression = string.Empty;
            this.EnableCaching = false;
            this.CustomPagerShowDots = true;
            this.ShowInfraeroHeader = false;
        }

        #region Metodos

        #region Paginação

        /// <summary>
        /// Método de customização de paginação
        /// </summary>
        /// <param name="row">A coluna</param>
        /// <param name="columnSpan">O índice</param>
        /// <param name="pagedDataSource">O datasource paginado</param>
        protected override void InitializePager(GridViewRow row, int columnSpan, PagedDataSource pagedDataSource)
        {
            if (this.CustomPagerMode == TPagerButtons.NumericNextPrevious)
            {
                base.InitializePager(row, columnSpan, pagedDataSource);

                this.CreateNumericNextPrev(row, pagedDataSource);
            }
            else if (this.CustomPagerMode == TPagerButtons.NumericNextPreviousFirstLast)
            {
                base.InitializePager(row, columnSpan, pagedDataSource);

                this.CreateNumericNextPrevFirstLast(row, pagedDataSource);
            }
            else
            {
                base.InitializePager(row, columnSpan, pagedDataSource);
            }

            row.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Center;

            this.CheckPagerDots(row, pagedDataSource);
        }

        /// <summary>
        /// Método que customiza a paginação para retirar o dots
        /// </summary>
        /// <param name="row">A linha do GridView</param>
        /// <param name="pagedDataSource">A fonte de dados paginada.</param>
        private void CheckPagerDots(GridViewRow row, PagedDataSource pagedDataSource)
        {
            if ((this.CustomPagerMode == TPagerButtons.Numeric
                || this.CustomPagerMode == TPagerButtons.NumericFirstLast
                || this.CustomPagerMode == TPagerButtons.NumericNextPrevious
                || this.CustomPagerMode == TPagerButtons.NumericNextPreviousFirstLast)
                && !this.CustomPagerShowDots)
            {
                int indexStart = 0;
                int indexLast = 0;

                switch (this.CustomPagerMode)
                {
                    case TPagerButtons.Numeric:
                        {
                            indexStart = 0;
                            indexLast = row.Cells[0].Controls[0].Controls[0].Controls.Count - 1;
                            break;
                        }
                    case TPagerButtons.NumericFirstLast:
                    case TPagerButtons.NumericNextPrevious:
                        {
                            indexStart = 1;
                            indexLast = row.Cells[0].Controls[0].Controls[0].Controls.Count - 2;
                            break;
                        }
                    case TPagerButtons.NumericNextPreviousFirstLast:
                        {
                            indexStart = 2;
                            indexLast = row.Cells[0].Controls[0].Controls[0].Controls.Count - 3;
                            break;
                        }
                }

                if (!pagedDataSource.IsFirstPage
                    && string.Equals(((LinkButton)row.Cells[0].Controls[0].Controls[0].Controls[indexStart].Controls[0]).Text, "..."))
                {
                    row.Cells[0].Controls[0].Controls[0].Controls[indexStart].Visible = false;
                }

                if (!pagedDataSource.IsLastPage
                    && string.Equals(((LinkButton)row.Cells[0].Controls[0].Controls[0].Controls[indexLast].Controls[0]).Text, "..."))
                {
                    row.Cells[0].Controls[0].Controls[0].Controls[indexLast].Visible = false;
                }
            }
        }

        /// <summary>
        /// Método que customização a paginação para primeiro, anterior, numeros, próximo e último
        /// </summary>
        /// <param name="row">A linha do GridView</param>
        /// <param name="pagedDataSource">A fonte de dados paginada.</param>
        private void CreateNumericNextPrevFirstLast(GridViewRow row, PagedDataSource pagedDataSource)
        {
            if (!pagedDataSource.IsFirstPage)
            {
                TableCell cell1 = this.CreateCustomPager(this.PagerSettings.FirstPageImageUrl,
                                                            this.PagerSettings.FirstPageText, "Page", "First", 0);

                row.Cells[0].Controls[0].Controls[0].Controls.AddAt(0, cell1);

                TableCell cell2 = this.CreateCustomPager(this.PagerSettings.PreviousPageImageUrl,
                                                            this.PagerSettings.PreviousPageText, "Page", "Prev", pagedDataSource.CurrentPageIndex - 1);

                row.Cells[0].Controls[0].Controls[0].Controls.AddAt(1, cell2);
            }

            if (!pagedDataSource.IsLastPage)
            {
                TableCell cell1 = this.CreateCustomPager(this.PagerSettings.NextPageImageUrl,
                                                            this.PagerSettings.NextPageText, "Page", "Next", pagedDataSource.CurrentPageIndex + 1);

                row.Cells[0].Controls[0].Controls[0].Controls.Add(cell1);

                TableCell cell2 = this.CreateCustomPager(this.PagerSettings.LastPageImageUrl,
                                                            this.PagerSettings.LastPageText, "Page", "Last", pagedDataSource.PageCount - 1);

                row.Cells[0].Controls[0].Controls[0].Controls.Add(cell2);
            }
        }

        /// <summary>
        /// Método que customização a paginação para anterior, numeros e próximo.
        /// </summary>
        /// <param name="row">A linha do GridView</param>
        /// <param name="pagedDataSource">A fonte de dados paginada.</param>
        private void CreateNumericNextPrev(GridViewRow row, PagedDataSource pagedDataSource)
        {
            if (!pagedDataSource.IsFirstPage)
            {
                TableCell cell1 = this.CreateCustomPager(this.PagerSettings.PreviousPageImageUrl,
                                                            this.PagerSettings.PreviousPageText, "Page", "Prev", pagedDataSource.CurrentPageIndex - 1);

                row.Cells[0].Controls[0].Controls[0].Controls.AddAt(0, cell1);
            }

            if (!pagedDataSource.IsLastPage)
            {
                TableCell cell2 = this.CreateCustomPager(this.PagerSettings.NextPageImageUrl,
                                                            this.PagerSettings.NextPageText, "Page", "Next", pagedDataSource.CurrentPageIndex + 1);

                row.Cells[0].Controls[0].Controls[0].Controls.Add(cell2);
            }
        }

        /// <summary>
        /// Método que cria as células customizadas do gridview
        /// </summary>
        /// <param name="imageUrl">A url da imagem.</param>
        /// <param name="text">O texto.</param>
        /// <param name="commandName">O nome do comando.</param>
        /// <param name="commandArgument">O argumento do comando.</param>
        /// <param name="pageIndex">indice da página a ser chamada</param>
        /// <returns>TableCell</returns>
        private TableCell CreateCustomPager(string imageUrl, string text, string commandName, string commandArgument, int pageIndex)
        {
            IButtonControl control;
            TableCell cell = new TableCell();

            if (imageUrl.Length > 0)
            {
                control = new TDataControlImageButton(this);
                ((TDataControlImageButton)control).ImageUrl = imageUrl;
                ((TDataControlImageButton)control).AlternateText = HttpUtility.HtmlDecode(text);
                ((TDataControlImageButton)control).EnableCallback(this.BuildCallbackArgument(pageIndex));
            }
            else
            {
                control = new TDataControlPagerLinkButton(this);
                ((TDataControlPagerLinkButton)control).Text = text;
                ((TDataControlPagerLinkButton)control).EnableCallback(this.BuildCallbackArgument(pageIndex));
            }

            control.CommandName = commandName;
            control.CommandArgument = commandArgument;

            cell.Controls.Add((Control)control);

            return cell;
        }

        /// <summary>
        /// Paginação 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPageIndexChanging(GridViewPageEventArgs e)
        {
            if (this.EnableCaching)
            {
                this.PageIndex = e.NewPageIndex;
                this.DataBind();
            }
            else
            {
                base.OnPageIndexChanging(e);
            }
        }

        /// <summary>
        /// Método que cria os scripts callback
        /// </summary>
        /// <param name="pageIndex">O índice da página</param>
        /// <returns>string</returns>
        private string BuildCallbackArgument(int pageIndex)
        {
            return _methodInfo.Invoke(this, new object[] { pageIndex }).ToString();
        }

        #endregion

        #region Ordenação

        /// <summary>
        /// Evento de ordenação
        /// </summary>
        /// <param name="e">O evento.</param>
        protected override void OnSorting(GridViewSortEventArgs e)
        {
            if ((this.DataSource != null && this.DataSource is IEnumerable) && !string.IsNullOrEmpty((e.SortExpression)))
            {
                if (CustomSortExpression == e.SortExpression)
                {
                    CustomSortDirection = CustomSortDirection == SortDirection.Ascending ? SortDirection.Descending :
                    SortDirection.Ascending;
                }
                else
                {
                    CustomSortDirection = SortDirection.Ascending;
                }

                CustomSortExpression = e.SortExpression;

                IEnumerable list = (IEnumerable)this.DataSource;

                this.DataSource = this.ApplyOrder(list, CustomSortExpression, CustomSortDirection == SortDirection.Ascending ? "OrderBy" : "OrderByDescending");

                this.DataBind();
            }
            else
            {
                base.OnSorting(e);
            }
        }

        /// <summary>
        /// Método que aplica dinamicamente a ordenação
        /// </summary>
        /// <typeparam name="T">O tipo do parametro</typeparam>
        /// <param name="source">A fonte de dados</param>
        /// <param name="propertyName">O nome da propriedade</param>
        /// <param name="methodName">O nome do método de ordenação</param>
        /// <returns>IEnumerable_T</returns>
        private IEnumerable ApplyOrder(IEnumerable source, string propertyName, string methodName)
        {
            Type type = Util.GetTypeFirstItem(source);

            if (type == null)
            {
                return null;
            }

            string[] pNames = propertyName.Split('.');

            ParameterExpression argument = Expression.Parameter(type, "p");

            Expression expDepth = argument;

            Type typeDepth = type;

            foreach (string pName in pNames)
            {
                PropertyInfo pInfo = typeDepth.GetProperty(pName);

                expDepth = Expression.Property(expDepth, pInfo);

                typeDepth = pInfo.PropertyType;
            }

            Type delegateType = typeof(Func<,>).MakeGenericType(type, typeDepth);

            LambdaExpression lambda = Expression.Lambda(delegateType, expDepth, argument);

            MethodInfo mInfo1 = typeof(Enumerable).GetMethods().Single(method => method.Name == methodName
                                                                        && method.IsGenericMethodDefinition
                                                                        && method.GetGenericArguments().Length == 2
                                                                        && method.GetParameters().Length == 2);
            mInfo1 = mInfo1.MakeGenericMethod(type, typeDepth);

            IEnumerable result1 = (IEnumerable)mInfo1.Invoke(null, new object[] { source, lambda.Compile() });

            MethodInfo mInfo2 = typeof(Enumerable).GetMethods().Single(method => method.Name == "ToList"
                                                                        && method.IsGenericMethodDefinition);
            mInfo2 = mInfo2.MakeGenericMethod(type);

            IEnumerable result2 = (IEnumerable)mInfo2.Invoke(null, new object[] { result1 });

            return result2;
        }

        #endregion

        #endregion


        protected override void Render(HtmlTextWriter writer)
        {
            if (!DesignMode && this.ShowInfraeroHeader)
            {
                writer.RenderBeginTag(HtmlTextWriterTag.Div);
                writer.RenderBeginTag(HtmlTextWriterTag.H2);
                writer.Write("Resultado da pesquisa");
                writer.RenderEndTag();
                writer.RenderBeginTag(HtmlTextWriterTag.Div);
                writer.RenderBeginTag(HtmlTextWriterTag.Div);
                writer.WriteAttribute("class", "XXXX");
                writer.RenderBeginTag(HtmlTextWriterTag.H4);
                writer.Write(string.Concat("Total de registros:", this.Rows.Count));
            }

            base.Render(writer);
        }
    }
}
