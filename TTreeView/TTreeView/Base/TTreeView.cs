using System;
using System.ComponentModel;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// Componente TTreeView
    /// </summary>
    [ParseChildren(true)]
    [PersistChildren(true)]
    [Themeable(true)]
    [ToolboxData("<{0}:TTreeView runat=\"server\"></{0}:TTreeView>")]
    public class TTreeView : TreeView
    {
        #region Propriedades

        /// <summary>
        /// Propriedade que define o auto check para os nós filhos
        /// </summary>
        [DefaultValue(false)]
        [Category("Behavior")]
        public bool AutoCheck
        {
            get
            {
                if (this.ViewState["AutoCheck"] == null)
                {
                    this.ViewState["AutoCheck"] = false;
                }

                return (bool)this.ViewState["AutoCheck"];
            }
            set
            {
                this.ViewState["AutoCheck"] = value;
            }
        }

        /// <summary>
        /// Propriedade que define a classe usada pelo node
        /// </summary>
        [DefaultValue(null)]
        [Category("Appearance")]
        public Type NodeType
        {
            get
            {
                if (this.ViewState["NodeType"] != null)
                {
                    return (Type)this.ViewState["NodeType"];
                }

                return null;
            }
            set
            {
                this.ViewState["NodeType"] = value;
            }
        }

        #endregion

        #region Eventos

        /// <summary>
        /// Evento prerender
        /// </summary>
        /// <param name="e">O evento.</param>
        protected override void OnPreRender(EventArgs e)
        {
            if (this.ShowCheckBoxes != TreeNodeTypes.None)
            {
                // script que dispara __doPostBack somente quando clicado no checkbox 
                // ('event.target' for um input do tipo checkbox)
                StringBuilder script = new StringBuilder();

                script.Append("var src = window.event != window.undefined ? window.event.srcElement : window.event.target; ");
                script.Append("var isChkBoxClick = (src.tagName.toLowerCase() == 'input' && src.type == 'checkbox'); ");
                script.Append("if (isChkBoxClick) {  " + this.Page.ClientScript.GetPostBackClientHyperlink(this, string.Empty) + " };");

                this.Attributes.Add("onclick", script.ToString());
            }

            base.OnPreRender(e);
        }

        /// <summary>
        /// Evento TreeNodeCheckChanged
        /// </summary>
        /// <param name="e">O evento.</param>
        protected override void OnTreeNodeCheckChanged(TreeNodeEventArgs e)
        {
            if (this.AutoCheck)
            {
                this.CheckUnCheckChilds(e.Node);
            }

            base.OnTreeNodeCheckChanged(e);
        }

        #endregion eventos

        #region Métodos

        /// <summary>
        /// Checka os nós filhos recursivamente quando o pai é checkado
        /// </summary>
        /// <param name="nodePai">nó pai</param>
        private void CheckUnCheckChilds(TreeNode nodePai)
        {
            foreach (TreeNode node in nodePai.ChildNodes)
            {
                node.Checked = nodePai.Checked;

                this.CheckUnCheckChilds(node);
            }
        }

        /// <summary>
        /// Cria um node específico quando nodeType é setado
        /// </summary>
        /// <returns>TreeNode</returns>
        protected override TreeNode CreateNode()
        {
            if (this.NodeType == null)
            {
                return base.CreateNode();
            }
            else
            {
                try
                {
                    return (TreeNode)Activator.CreateInstance(this.NodeType);
                }
                catch
                {
                    return base.CreateNode();
                }
            }
        }

        #endregion
    }
}
