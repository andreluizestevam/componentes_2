using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace WebApplication1
{
    public class TreeNodeClassificacao : TreeNode
    {
        /// <summary>
        /// Inicializa uma nova instância da classe TreeNodeClassificacao Sem texto ou um valor.
        /// </summary>
        public TreeNodeClassificacao()
            : base()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        private string _CssClass = null;

        /// <summary>
        /// Propriedade que armazena o CssClass do nodo.
        /// </summary>
        public string CssClass
        {
            get
            {
                if (_CssClass != null)
                {
                    return _CssClass;
                }
                else
                {
                    return String.Empty;
                }
            }

            set
            { _CssClass = value; }
        }

        /// <summary>
        /// Loads the previously saved view state of the node.
        /// </summary>
        /// <param name="savedState">An System.Object that represents the state of the node.</param>
        protected override void LoadViewState(Object savedState)
        {
            if (savedState != null)
            {
                object[] myState = (object[])savedState;

                if (myState[0] != null)
                {
                    base.LoadViewState(myState[0]);
                }

                if (myState[1] != null)
                {
                    CssClass = (String)myState[1];
                }
            }
        }

        /// <summary>
        /// Saves the current view state of the node.
        /// </summary>
        /// <returns>An System.Object that contains the saved state of the node.</returns>
        protected override Object SaveViewState()
        {
            object baseState = base.SaveViewState();
            object[] allStates = new object[3];
            allStates[0] = baseState;
            allStates[1] = CssClass;

            return allStates;
        }

        /// <summary>
        /// Allows control developers to add additional rendering to the node.
        /// </summary>
        /// <param name="writer">The System.Web.UI.HtmlTextWriter that represents the output stream used to write content to a Web page.</param>
        protected override void RenderPreText(HtmlTextWriter writer)
        {
            writer.AddAttribute("class", CssClass);
            base.RenderPreText(writer);
        }
    }
}