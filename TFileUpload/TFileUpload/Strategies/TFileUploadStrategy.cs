using System.Collections.Generic;
using System.Web.UI;

namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// 
    /// </summary>
    internal abstract class TFileUploadStrategy
    {
        #region Constantes

        /// <summary>
        /// 
        /// </summary>
        public const string STRATEGY_FILE_ID = "#TFU_FILE#";

        /// <summary>
        /// 
        /// </summary>
        public const string STRATEGY_PAGE_ID = "#TFU_PAGE#";

        #endregion

        #region Propriedades

        /// <summary>
        /// 
        /// </summary>
        protected TFileUpload Container { get; set; }

        /// <summary>
        /// 
        /// </summary>
        protected Page Page { get; set; }

        #endregion

        #region Construtores

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        public TFileUploadStrategy(TFileUpload container)
        {
            this.Container = container;
            this.Page = container.Page;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// 
        /// 
        /// </summary>
        public abstract List<TFileUploadItem> GetFiles();

        /// <summary>
        /// 
        /// 
        /// </summary>
        public abstract void ClearFiles();

        /// <summary>
        /// 
        /// 
        /// </summary>
        public abstract void RefreshFiles();

        /// <summary>
        /// 
        /// </summary>
        public abstract void AddFile(TFileUploadItem item);

        /// <summary>
        /// 
        /// </summary>
        public abstract void RemoveFile(TFileUploadItem item);

        #endregion
    }
}
