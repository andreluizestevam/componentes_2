using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Dynamic;

namespace WebApplication1
{
    public partial class Download : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Teste.Parameters = new Casa() { Nome = "lu" };
            //this.Teste.Parameters.Nome = "Luiz";
            //this.Teste.Parameters.SobreNome = "Oliveira";
        }
    }

    [Serializable]
    public class Casa
    {
        public string Nome { get; set; }
    }
}