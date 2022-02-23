using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class PagerTeste : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindList();
            }
        }

        private void BindList()
        {
            List<Dados1> dados = new List<Dados1>();

            for (int i = 0; i < 60; i++)
            {
                dados.Add(new Dados1() { Valor = i });
            }

            ListView1.DataSource = dados;
            ListView1.DataBind();
        }

        protected void ListView1_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {
            
        }

        protected void ListView1_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            pagerTeste.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            BindList();
        }
    }


    public class Dados1
    {
        public int Valor { get; set; }
    }
}