using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Web.Services;

namespace WebApplication1
{
    public partial class Buttons : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static void TesteAjax()
        {
            Thread.Sleep(30000);
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            Thread.Sleep(3000);
        }
    }
}