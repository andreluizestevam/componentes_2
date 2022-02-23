using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            //this.trvClassificacao.NodeType = typeof(TreeNodeClassificacao);
            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.trvClassificacao.NodeType = typeof(TreeNodeClassificacao);

            if (!this.IsPostBack)
            {
                TreeNode nodePai = new TreeNode();
                nodePai.Text = "Nó Pai";
                nodePai.Value = "1";
                TreeNode nodeFilha = new TreeNode();
                nodeFilha.Text = "Nó Filho";
                nodeFilha.Value = "2";
                TreeNode nodeNeta = new TreeNode();
                nodeNeta.Text = "Nó Neto";
                nodeNeta.Value = "3";

                nodeFilha.ChildNodes.Add(nodeNeta);
                nodePai.ChildNodes.Add(nodeFilha);

                tv.Nodes.Add(nodePai);


                TreeNodeClassificacao nodePai2 = new TreeNodeClassificacao();
                nodePai2.Text = "Nó Pai2";
                nodePai2.Value = "4";

                TreeNodeClassificacao noFilha2 = new TreeNodeClassificacao();
                noFilha2.CssClass = "treeviewClassificacao";
                noFilha2.Text = "Nó Filho2";
                noFilha2.Value = "5";

                nodePai2.ChildNodes.Add(noFilha2);

                trvClassificacao.Nodes.Add(nodePai2);
                
                

            }
        }
    }
}