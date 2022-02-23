using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// 
    /// </summary>
    [ToolboxData("<{0}:TTab runat=\"server\"></{0}:TTab>")]
    public class TTab : View
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get { return Convert.ToString(this.ViewState["_!Name"]); }
            set { this.ViewState["_!Name"] = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(true)]
        public bool Enabled
        {
            get
            {
                if (this.ViewState["_!Enabled"] == null)
                {
                    this.ViewState["_!Enabled"] = true;
                }
                return Convert.ToBoolean(this.ViewState["_!Enabled"]);
            }
            set { this.ViewState["_!Enabled"] = value; }
        }
    }
}
