using System;
using System.Drawing;
using System.IO;
using HtmlAgilityPack;

namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// Classe para resultado da solicitacao
    /// </summary>
    public sealed class TWebRequestEventArgs : EventArgs
    {
        /// <summary>
        /// Propriedade Url.
        /// </summary>
        public Uri Url { get; set; }

        /// <summary>
        /// Propriedade Exception
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        /// Propriedade Html Document
        /// </summary>
        public HtmlDocument Document { get; set; }

        /// <summary>
        /// Propriedade Response Stream
        /// </summary>
        public Stream Stream { get; set; }

        /// <summary>
        /// Propriedade Image
        /// </summary>
        public Image Image { get; set; }
    }
}
