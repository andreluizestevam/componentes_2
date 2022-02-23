using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Arquitetura.Web.WebControls;

public partial class _Default : System.Web.UI.Page
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void TConfirmBox1_ClickOk(object sender, TConfirmEventArgs e)
    {
        this.Label3.Text = "ConfirmOK";
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void TConfirmBox1_ClickCancel(object sender, TConfirmEventArgs e)
    {
        this.Label3.Text = "ConfirmCancel";
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void TInputBox1_ClickOk(object sender, TInputEventArgs e)
    {
        this.Label3.Text = "InputOK";
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void TInputBox1_ClickCancel(object sender, TInputEventArgs e)
    {
        this.Label3.Text = "InputCancel";
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button5_Click(object sender, EventArgs e)
    {
        if (this.ViewState["List"] == null)
        {
            this.ViewState["List"] = new List<string>();
        }

        List<string> list = (List<string>)this.ViewState["List"];

        list.Add(TextBox1.Text);

        this.GridView1.DataSource = list;
        this.GridView1.DataBind();

        this.ViewState["List"] = list;

        this.TMessageBox2.Message = "Adicionando 1";
        this.TMessageBox2.Show();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button6_Click(object sender, EventArgs e)
    {
        if (this.ViewState["List"] == null)
        {
            return;
        }

        List<string> list = (List<string>)this.ViewState["List"];

        list.RemoveAt(0);

        this.GridView1.DataSource = list;
        this.GridView1.DataBind();

        this.ViewState["List"] = list;
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        this.TPopupBox1.Show();
    }

    protected void Button7_Click(object sender, EventArgs e)
    {
        this.TPopupBox2.Show();
    }

    protected void TPopupBox1_Closing(object sender, TPopupEventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        this.TMessageBox1.Show();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        this.TConfirmBox1.Show();
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        this.TInputBox1.Show();
    }


}
