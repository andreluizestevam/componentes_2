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
    [ToolboxData("<{0}:TGridViewBase runat=\"server\"></{0}:TGridViewBase>")]
    public sealed class TGridViewBase : GridView
    {
        #region Atributos

        /// <summary>
        /// Atributo para reflection do método interno do GridView
        /// </summary>
        private MethodInfo _methodInfo = typeof(GridView).GetMethod("BuildCallbackArgument", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.CreateInstance, null, new Type[] { typeof(int) }, null);

        /// <summary>
        /// Atributo para reflection do propriedadeinterno do GridView
        /// </summary>
        private PropertyInfo _propInfo1 = typeof(GridView).GetProperty("SortExpressionInternal", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.CreateInstance);

        /// <summary>
        /// Atributo para reflection do propriedadeinterno do GridView
        /// </summary>
        private PropertyInfo _propInfo2 = typeof(GridView).GetProperty("SortDirectionInternal", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.CreateInstance);

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
        /// Propriedade para habilitar a exibição de grupos (...) da paginação
        /// </summary>
        [Browsable(true)]
        [Category("Paging")]
        [DefaultValue(true)]
        public bool CustomPagerShowDots
        {
            get
            {
                if (this.ViewState["_!CustomPagerShowDots"] == null)
                {
                    this.ViewState["_!CustomPagerShowDots"] = true;
                }

                return (bool)this.ViewState["_!CustomPagerShowDots"];
            }
            set { this.ViewState["_!CustomPagerShowDots"] = value; }
        }

        #endregion

        #region Paginação

        /// <summary>
        /// Evento de paginação
        /// </summary>
        /// <param name="e">O evento.</param>
        protected override void OnPageIndexChanging(GridViewPageEventArgs e)
        {
            DataSourceView view = this.GetData();

            if (view.CanPage)
            {
                base.OnPageIndexChanging(e);

                return;
            }

            this.PageIndex = e.NewPageIndex;

            if (this.DataSource == null
                && string.IsNullOrEmpty(this.DataSourceID))
            {
                base.OnPageIndexChanging(e);
            }

            if (!view.CanRetrieveTotalRowCount
                && this.RequiresDataBinding)
            {
                this.DataBind();
            }
        }

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
        /// Método que cria os scripts callback
        /// </summary>
        /// <param name="pageIndex">O índice da página</param>
        /// <returns>string</returns>
        private string BuildCallbackArgument(int pageIndex)
        {
            return _methodInfo.Invoke(this, new object[] { pageIndex }).ToString();
        }

        #endregion
    }
}
