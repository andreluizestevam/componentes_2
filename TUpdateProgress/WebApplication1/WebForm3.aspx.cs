using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

namespace WebApplication1
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!this.IsPostBack)
            //{
            //    this.ddl1.SelectedIndex = 1;
            //    this.ddl1_SelectedIndexChanged(this.ddl1, EventArgs.Empty);
            //}
        }

        protected void ddl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ddl2.Items.Clear();

            if (this.ddl1.SelectedIndex > 0)
            {
                string t = this.ddl1.SelectedValue;

                for (int i = 0; i < 10; i++)
                {
                    this.ddl2.Items.Insert(i, t);
                }
            }

            Thread.Sleep(1000);
        }
    }
}