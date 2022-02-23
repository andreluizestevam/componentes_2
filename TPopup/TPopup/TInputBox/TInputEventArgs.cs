using System;

namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// 
    /// </summary>
    public class TInputEventArgs : EventArgs
    {
        #region Propriedades

        /// <summary>
        /// 
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public new static TInputEventArgs Empty = new TInputEventArgs();

        #endregion
    }
}
