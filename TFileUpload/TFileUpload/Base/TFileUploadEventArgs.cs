using System;

namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public sealed class TFileUploadEventArgs : EventArgs
    {
        #region Propriedades

        /// <summary>
        /// O arquivo.
        /// </summary>
        public TFileUploadItem Item { get; set; }

        /// <summary>
        /// O estado do upload.
        /// </summary>
        public TFileUploadState State { get; set; }

        /// <summary>
        /// A mensagem de status. 
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Se o arquivo é para ser armazenado.
        /// </summary>
        public bool PersistFile { get; set; }

        #endregion
    }
}
