using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if(this.ViewState["ListNames"] == null)
        {
            this.ViewState["ListNames"] = new List<string>();
        }

        List<string> list = (List<string>)this.ViewState["ListNames"];

        list.Add(TextBox1.Text);

        this.ViewState["ListNames"] = list;

        this.GridView1.DataSource = list;
        this.GridView1.DataBind();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (this.ViewState["ListNames2"] == null)
        {
            this.ViewState["ListNames2"] = new List<string>();
        }

        List<string> list = (List<string>)this.ViewState["ListNames2"];

        list.Add(TextBox1.Text);

        this.ViewState["ListNames2"] = list;

        this.GridView2.DataSource = list;
        this.GridView2.DataBind();
    }
}
