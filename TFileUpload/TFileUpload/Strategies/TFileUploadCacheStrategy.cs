using System;
using System.Collections.Generic;
using System.Web.Caching;

namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// 
    /// </summary>
    internal sealed class TFileUploadCacheStrategy : TFileUploadStrategy
    {
        /// <summary>
        /// 
        /// </summary>
        private const int EXPIRATION_MINUTES = 1;

        /// <summary>
        /// 
        /// </summary>
        private Cache Cache { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        public TFileUploadCacheStrategy(TFileUpload container)
            : base(container)
        {
            this.Cache = this.Page.Cache;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public override List<TFileUploadItem> GetFiles()
        {
            if (this.Cache[TFileUploadStrategy.STRATEGY_FILE_ID] == null)
            {
                return new List<TFileUploadItem>();
            }

            return (List<TFileUploadItem>)this.Cache[TFileUploadStrategy.STRATEGY_FILE_ID];
        }

        /// <summary>
        /// 
        /// </summary>
        public override void ClearFiles()
        {
            this.Cache.Remove(TFileUploadStrategy.STRATEGY_PAGE_ID);
            this.Cache.Remove(TFileUploadStrategy.STRATEGY_FILE_ID);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void RefreshFiles()
        {
            List<TFileUploadItem> itens = this.GetFiles();

            if (this.Cache[TFileUploadStrategy.STRATEGY_FILE_ID] != null)
            {
                this.ClearFiles();
            }

            this.Cache.Add(TFileUploadStrategy.STRATEGY_PAGE_ID, this.Page.AppRelativeVirtualPath, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, EXPIRATION_MINUTES, 0), CacheItemPriority.Default, null);
            this.Cache.Add(TFileUploadStrategy.STRATEGY_FILE_ID, itens, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, EXPIRATION_MINUTES, 0), CacheItemPriority.Default, null);
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

            if (this.Cache[TFileUploadStrategy.STRATEGY_FILE_ID] != null)
            {
                this.ClearFiles();
            }

            this.Cache.Add(TFileUploadStrategy.STRATEGY_PAGE_ID, this.Page.AppRelativeVirtualPath, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, EXPIRATION_MINUTES, 0), CacheItemPriority.Default, null);
            this.Cache.Add(TFileUploadStrategy.STRATEGY_FILE_ID, itens, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, EXPIRATION_MINUTES, 0), CacheItemPriority.Default, null);
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

            if (this.Cache[TFileUploadStrategy.STRATEGY_FILE_ID] != null)
            {
                this.ClearFiles();
            }

            this.Cache.Add(TFileUploadStrategy.STRATEGY_PAGE_ID, this.Page.AppRelativeVirtualPath, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, EXPIRATION_MINUTES, 0), CacheItemPriority.Default, null);
            this.Cache.Add(TFileUploadStrategy.STRATEGY_FILE_ID, itens, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, EXPIRATION_MINUTES, 0), CacheItemPriority.Default, null);
        }
    }
}
