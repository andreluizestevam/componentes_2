using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Arquitetura.TechBiz.BS;
using Arquitetura.TechBiz.Common;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Dados> dados = new List<Dados>();

                for (int i = 0; i < 1000; i++)
                {
                    dados.Add(new Dados() { NOM_ARQUIVO = string.Concat("arquivo", i), NOM_ARQUIVO_SERVIDOR = string.Concat("arquivoServidor", i) });
                }

                this.GridView1.EnableCaching = true;
                this.GridView1.DataSource = dados;
                this.GridView1.DataBind();
            }
            //    CmaWebContext context = EF4Manager.GetObjectContext<CmaWebContext>();

            //    IQueryable<CAD_ARQUIVO> query = from item in context.CreateObjectSet<CAD_ARQUIVO>()
            //                                    select item;

            //    VOPaging p = new VOPaging(this.GridView1.PageIndex, this.GridView1.PageSize);
            //    VOSorting s = new VOSorting("CAD_ARQUIVO.NOM_ARQUIVO", VOSortDirection.Ascending);

            //    List<CAD_ARQUIVO> list = EF4Manager.ListAll(context, query, p, s);

            //    BusinessService bs = new BusinessService();
            //    bs.Options.Paging = p;
            //    bs.Options.Sorting = s;
            //    bs.AddNamedVos("TESTE", list);

            //    this.GridView1.DataSource = bs;
            //    this.GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //CmaWebContext context = EF4Manager.GetObjectContext<CmaWebContext>();

            //IQueryable<CAD_ARQUIVO> query = context.CAD_ARQUIVO;

            //VOPaging p = new VOPaging(e.NewPageIndex, this.GridView1.PageSize);
            //VOSorting s = new VOSorting(this.GridView1.SortExpression, (VOSortDirection)this.GridView1.SortDirection);

            //List<CAD_ARQUIVO> list = EF4Manager.ListAll(context, query, p, s);

            //BusinessService bs = new BusinessService();
            //bs.Options.Paging = p;
            //bs.Options.Sorting = s;
            //bs.AddNamedVos("TESTE", list);

            //this.GridView1.DataSource = bs;
            //this.GridView1.DataBind();
        }
    }


    [Serializable]
    public class Dados
    {
        public string NOM_ARQUIVO { get; set; }
        public string NOM_ARQUIVO_SERVIDOR { get; set; }
    }
}