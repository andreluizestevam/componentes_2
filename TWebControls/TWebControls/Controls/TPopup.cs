// -----------------------------------------------------------------------
// <copyright file="TPopup.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Arquitetura.Web.WebControls.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Drawing;
    using System.Web.UI.WebControls;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class TPopup : Panel
    {

        /// <summary>
        /// Construtor
        /// </summary>
        public TPopup()
        {
            this.WindowSize = new Size(600, 800);
            this.Url = string.Empty;
            this.CloseFuncion = string.Empty;
        }

        /// <summary>
        /// Define o tamanho da tela que será mostrada.
        /// </summary>
        public Size WindowSize { get; set; }

        /// <summary>
        /// Url a ser aberta pelo Popup
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Função a ser chamada no close do popup
        /// </summary>
        public string CloseFuncion { get; set; }


        protected override void OnPreRender(EventArgs e)
        {

            base.OnPreRender(e);
        }

    }
}
