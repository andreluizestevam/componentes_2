using System.Collections.Generic;
using System.Web.SessionState;

namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// 
    /// </summary>
    internal sealed class TFileUploadSessionStrategy : TFileUploadStrategy
    {
        /// <summary>
        /// 
        /// </summary>
        private HttpSessionState Session { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        public TFileUploadSessionStrategy(TFileUpload container)
            : base(container)
        {
            this.Session = this.Page.Session;

            this.Session[TFileUploadStrategy.STRATEGY_PAGE_ID] = this.Page.AppRelativeVirtualPath;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public override List<TFileUploadItem> GetFiles()
        {
            if (this.Session[TFileUploadStrategy.STRATEGY_FILE_ID] == null)
            {
                
                this.Session[TFileUploadStrategy.STRATEGY_FILE_ID] = new List<TFileUploadItem>();
            }

            return (List<TFileUploadItem>)this.Session[TFileUploadStrategy.STRATEGY_FILE_ID];
        }

        /// <summary>
        /// 
        /// </summary>
        public override void ClearFiles()
        {
            this.Session.Remove(TFileUploadStrategy.STRATEGY_PAGE_ID);
            this.Session.Remove(TFileUploadStrategy.STRATEGY_FILE_ID);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void RefreshFiles()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public override void AddFile(TFileUploadItem item)
        {
            List<TFileUploadItem> itens = this.GetFiles();

            itens.Add(item);

            this.Session[TFileUploadStrategy.STRATEGY_FILE_ID] = itens;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public override void RemoveFile(TFileUploadItem item)
        {
            List<TFileUploadItem> itens = this.GetFiles();

            itens.Remove(item);

            this.Session[TFileUploadStrategy.STRATEGY_FILE_ID] = itens;
        }
    }
}
