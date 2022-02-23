using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// 
    /// </summary>
    [ToolboxData("<{0}:TTabView runat=\"server\"></{0}:TTabView>")]
    [ParseChildren(typeof(TTab))]
    [Themeable(true)]
    public class TTabView : MultiView, IPostBackDataHandler
    {
        #region Propriedades

        /// <summary>
        /// 
        /// </summary>
        public string ContainerCssClass
        {
            get { return Convert.ToString(this.ViewState["_!ContainerCssClass"]); }
            set { this.ViewState["_!ContainerCssClass"] = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ActiveTabCssClass
        {
            get { return Convert.ToString(this.ViewState["_!ActiveTabCssClass"]); }
            set { this.ViewState["_!ActiveTabCssClass"] = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string DeactiveTabCssClass
        {
            get { return Convert.ToString(this.ViewState["_!DeactiveTabCssClass"]); }
            set { this.ViewState["_!DeactiveTabCssClass"] = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ContentTabCssClass
        {
            get { return Convert.ToString(this.ViewState["_!ContentTabCssClass"]); }
            set { this.ViewState["_!ContentTabCssClass"] = value; }
        }

        #endregion

        #region Metodos

        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        protected override void Render(HtmlTextWriter writer)
        {
            // check visible
            if (!this.Visible)
            {
                return;
            }

            // begin div container
            writer.Write("<div");
            writer.WriteAttribute("id", string.Concat(this.ClientID, "_Container"));

            if (!string.IsNullOrEmpty(this.ContainerCssClass))
            {
                writer.WriteAttribute("class", this.ContainerCssClass);
            }

            writer.Write(">");

            // begin div headers
            writer.Write("<div");
            writer.WriteAttribute("id", string.Concat(this.ClientID, "_Header"));
            writer.Write(">");

            for (int i = 0; i < this.Views.Count; i++)
            {
                // get view
                TTab view = (TTab)this.Views[i];

                // create tab
                Button b = new Button();
                b.ID = string.Concat(this.ClientID, "_Button_", view.ClientID);
                b.Text = view.Name;
                b.Enabled = !view.Visible;
                b.Visible = view.Enabled;
                b.UseSubmitBehavior = false;
                b.Attributes.Add("onclick", this.Page.ClientScript.GetPostBackEventReference(b, i.ToString()));

                if (!string.IsNullOrEmpty(this.ActiveTabCssClass)
                    && !string.IsNullOrEmpty(this.DeactiveTabCssClass))
                {
                    b.CssClass = (view.Visible)
                                    ? this.ActiveTabCssClass
                                    : this.DeactiveTabCssClass;
                }

                // render tab
                b.RenderControl(writer);
            }
            // end div headers
            writer.Write("</div>");

            // begin div content
            writer.Write("<div");
            writer.WriteAttribute("id", string.Concat(this.ClientID, "_Content"));

            if (!string.IsNullOrEmpty(this.ContentTabCssClass))
            {
                writer.WriteAttribute("class", this.ContentTabCssClass);
            }

            writer.Write(">");

            // render content
            base.Render(writer);

            // end div content
            writer.Write("</div>");

            // end div container
            writer.Write("</div>");
        }

        #endregion

        #region Eventos

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(System.EventArgs e)
        {
            base.Page.RegisterRequiresPostBack(this);

            base.OnInit(e);
        }

        /// <summary>
        /// 
        /// </summary>
        private int _tabIndexSelected = -1;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="postDataKey"></param>
        /// <param name="postCollection"></param>
        /// <returns></returns>
        public bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
        {
            if (!string.Equals(postDataKey, this.UniqueID))
            {
                return false;
            }

            string keyTarget = postCollection["__EVENTTARGET"];

            if (!string.IsNullOrEmpty(keyTarget)
                && (keyTarget.StartsWith(this.UniqueID)
                    || keyTarget.StartsWith(this.ClientID)))
            {
                string keyArgument = postCollection["__EVENTARGUMENT"];

                _tabIndexSelected = int.Parse(keyArgument);

                return true;
            }

            string keyEvent = postCollection.Keys[postCollection.Count - 1];

            if (!string.IsNullOrEmpty(keyEvent)
                && (keyTarget.StartsWith(this.UniqueID)
                    || keyTarget.StartsWith(this.ClientID)))
            {
                string keyArgument = postCollection["__EVENTARGUMENT"];

                _tabIndexSelected = int.Parse(keyArgument);

                return true;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        public void RaisePostDataChangedEvent()
        {
            this.SetActiveView(this.Views[_tabIndexSelected]);
        }

        #endregion
    }
}
