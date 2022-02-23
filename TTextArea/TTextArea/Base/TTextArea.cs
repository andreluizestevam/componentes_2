using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// 
    /// </summary>
    [ParseChildren(true)]
    [PersistChildren(true)]
    [Themeable(true)]
    public sealed class TTextArea : TextBox
    {
        #region Propriedades

        /// <summary>
        /// Propriedade que define o textboxmode do textarea.
        /// </summary>
        [DefaultValue(TextBoxMode.MultiLine)]
        public override TextBoxMode TextMode
        {
            get { return TextBoxMode.MultiLine; }
            set { base.TextMode = value; }
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Evento load
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            if (this.MaxLength > 0)
            {
                // register scripts
                this.Page.ClientScript.RegisterClientScriptResource(this.GetType(), "Arquitetura.Web.WC.TTextArea.Resources.textarea.js");
            }

            base.OnLoad(e);
        }

        /// <summary>
        /// Evento prerender
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreRender(EventArgs e)
        {
            if (this.MaxLength > 0)
            {
                this.Attributes.Add("onkeypress", "javascript:doKeypress(this);");
                this.Attributes.Add("onbeforepaste", "javascript:doBeforePaste(this);");
                this.Attributes.Add("onpaste", "javascript:doPaste(this);");
                this.Attributes.Add("maxLength", this.MaxLength.ToString());
            }

            base.OnPreRender(e);
        }

       #endregion
    }
}
