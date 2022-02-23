using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<Teste> testes = new List<Teste>();

            testes.Add(new Teste() { Text = "Gabriela", Value = 2 });
            testes.Add(new Teste() { Text = "Cláudia", Value = 5 });
            testes.Add(new Teste() { Text = "Bruna", Value = 6 });
            testes.Add(new Teste() { Text = "Débora", Value = 4 });
            testes.Add(new Teste() { Text = "Amanda", Value = 7 });
            testes.Add(new Teste() { Text = "Emengarda", Value = 0 });
            testes.Add(new Teste() { Text = "Helena", Value = 3 });
            testes.Add(new Teste() { Text = "Fernanda", Value = 1 });

            //this.TDropDownList1.DataSource = testes;
            //this.TDropDownList1.DataTextField = "Text";
            //this.TDropDownList1.DataValueField = "Value";
            //this.TDropDownList1.DataBind();
            //this.TDropDownList1.Items.Add(new ListItem() { Text = "teste", Value = "aaaa" });
            //this.TDropDownList1.Items.Add(new ListItem() { Text = "teste2", Value = "aaaa1" });
            //this.TDropDownList1.Items.Add(new ListItem() { Text = "teste3", Value = "aaaa2" });
            //this.TDropDownList1.Items.Add(new ListItem() { Text = "teste4", Value = "aaaa3" });
            //this.TDropDownList1.Items.Add(new ListItem() { Text = "teste5", Value = "aaaa4" });
            

            //this.TMultiSelect1.DataSourceAvaliable = testes;
            //this.TMultiSelect1.TextField = "Text";
            //this.TMultiSelect1.ValueField = "Value";
            //this.TMultiSelect1.DataBind();

            //this.TMultiSelect2.DataSourceAvaliable = testes;
            //this.TMultiSelect2.TextField = "Text";
            //this.TMultiSelect2.ValueField = "Value";
            //this.TMultiSelect2.DataBind();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //var a = this.TMultiSelect1.Selecteds;

        //string selecionadosA = string.Empty;

        //foreach (ListItem item in this.TMultiSelect1.Selecteds)
        //{
        //    selecionadosA = selecionadosA + item.Text + " - " + item.Value + "\n";
        //}

        //this.TextBox1.Text = selecionadosA;

        //var b = this.TMultiSelect2.Selecteds;

        //string selecionadosB = string.Empty;

        //foreach (ListItem item in this.TMultiSelect2.Selecteds)
        //{
        //    selecionadosB = selecionadosB + item.Text + " - " + item.Value + "\n";
        //}

        //this.TextBox2.Text = selecionadosB;
    }

    protected void Button2_Click(object sender, EventArgs e)
    {

    }
}

[Serializable]
public class Teste
{
    public string Text { get; set; }

    public int Value { get; set; }
}