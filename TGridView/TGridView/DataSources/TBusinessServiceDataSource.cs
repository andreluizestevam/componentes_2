using System;
using System.Collections;
using System.Web.UI;
using Arquitetura.TechBiz.BS;

namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// Classe TBusinessServiceDataSource
    /// </summary>
    internal sealed class TBusinessServiceDataSource : IDataSource
    {
        #region Eventos

        /// <summary>
        /// Evento
        /// </summary>
        public event EventHandler DataSourceChanged;

        /// <summary>
        /// Método do evento.
        /// </summary>
        /// <param name="e">O evento</param>
        public void OnDataSourceChanged(EventArgs e)
        {
            if (this.DataSourceChanged != null)
            {
                this.DataSourceChanged(this, e);
            }
        }

        #endregion

        #region Atributos

        /// <summary>
        /// Atributo com nome das views
        /// </summary>
        private string[] _viewNames;

        /// <summary>
        /// Atributo com o businessService
        /// </summary>
        private BusinessService _dataSource;

        #endregion

        #region Construtores

        /// <summary>
        /// Construtor padrão
        /// </summary>
        /// <param name="dataSource">A fonte de dados</param>
        /// <param name="dataMember">A propriedade da fonte de dados</param>
        public TBusinessServiceDataSource(BusinessService dataSource)
        {
            this._dataSource = dataSource;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Método que recupera o businessService.
        /// </summary>
        /// <returns>BusinessService</returns>
        internal BusinessService GetBS()
        {
            return this._dataSource;
        }

        /// <summary>
        /// Método que recupera uma view.
        /// </summary>
        /// <param name="viewName">O nome da view</param>
        /// <returns></returns>
        public DataSourceView GetView(string viewName)
        {
            return new TBusinessServiceDataSourceView(this, this._dataSource.Vos);
        }

        /// <summary>
        /// Método que retorna os nomes das views.
        /// </summary>
        /// <returns>ICollection</returns>
        public ICollection GetViewNames()
        {
            if (this._viewNames == null)
            {
                this._viewNames = new string[] { "DefaultView" };
            }

            return this._viewNames;
        }

        #endregion
    }
}
