using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class GridNormal : System.Web.UI.Page
    {
        List<DadosGrid> dados = new List<DadosGrid>();

           
        protected void Page_Load(object sender, EventArgs e)
        {

            for (int i = 0; i < 100; i++)
            {
                dados.Add(new DadosGrid { Nome = string.Concat("dado", i), Valor = i });
            }
            
            GridView1.DataSource = dados;
            GridView1.DataBind();

            GridView1.Sorting += new GridViewSortEventHandler(GridView1_Sorting);

        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            GridView1.DataSource = dados;
            GridView1.DataBind();
        }
    }

    public class DadosGrid
    {
        public string Nome { get; set; }
        public int Valor { get; set; }
    }
}