using System;

namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// 
    /// </summary>
    public class TMessageEventArgs : EventArgs
    {
        #region Propriedades

        ///// <summary>
        ///// 
        ///// </summary>
        //public string Message { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //public TMessageOption MessageOption { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public new static TMessageEventArgs Empty = new TMessageEventArgs();

        #endregion
    }
}
