using System.Collections;
using System.Web.UI;
using Arquitetura.TechBiz.BS;

namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// Classe TBusinessServiceDataSourceView
    /// </summary>
    internal sealed class TBusinessServiceDataSourceView : DataSourceView
    {
        #region Atributos

        /// <summary>
        /// Atributo da fonte de dados
        /// </summary>
        private IEnumerable _dataSource;

        /// <summary>
        /// Atributo com o provider da fonte de dados
        /// </summary>
        private TBusinessServiceDataSource _owner;

        #endregion

        #region Propriedades

        /// <summary>
        /// Propriedade que habilita o suporte a paginação
        /// </summary>
        public override bool CanPage
        {
            get { return false; }
        }

        /// <summary>
        /// Propriedade que habilita o suporte recuperar a quantidade total
        /// </summary>
        public override bool CanRetrieveTotalRowCount
        {
            get { return false; }
        }

        #endregion

        #region Construtores

        /// <summary>
        /// Construtor padrão
        /// </summary>
        /// <param name="owner">O adaptador da fonte de dados</param>
        /// <param name="name">O nome da propriedade</param>
        /// <param name="dataSource">A fonte de dados</param>
        public TBusinessServiceDataSourceView(TBusinessServiceDataSource owner, IEnumerable dataSource)
            : base(owner, "DefaultView")
        {
            this._owner = owner;
            this._dataSource = dataSource;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Método que executa o select no datasource
        /// </summary>
        /// <param name="arguments">Os argumentos</param>
        /// <returns>IEnumerable</returns>
        protected override IEnumerable ExecuteSelect(DataSourceSelectArguments arguments)
        {
            BusinessService bService = this._owner.GetBS();

            if (bService.Options.Paging.IsPaging)
            {
                IEnumerable newDataSource = Util.CreatePaggedEnumerable(this._dataSource,
                                                                        bService.Options.Paging.PageIndex,
                                                                        bService.Options.Paging.PageSize,
                                                                        bService.Options.Paging.ItemsCount);

                return newDataSource;
            }

            return this._dataSource;
        }

        /// <summary>
        /// Método que recupera o businessService.
        /// </summary>
        /// <returns>BusinessService</returns>
        internal BusinessService GetBS()
        {
            return this._owner.GetBS();
        }

        #endregion
    }
}
